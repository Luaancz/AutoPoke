using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using Luaan.AutoPoke.SearchTypes;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Threading;
using System.Media;
using System.Threading.Tasks;

namespace Luaan.AutoPoke
{
	public class SearchEngine
	{
		bool firstSearchDone = false;
		Process lockedProcess;
		List<IntPtr> locations = new List<IntPtr>();
		int lastLocationCount = 0;

		public int LocationCount { get { return this.locations.Count; } }
		public Process Process { get { return this.lockedProcess; } }
		public string SearchType { get; private set; }
		public bool PresumeAlignment { get; set; }

		public ScanResultInformation GetResults()
		{
			ScanResultInformation sri = new ScanResultInformation();
			sri.ParentProcess = lockedProcess;
			sri.MemoryPointers = locations.ToArray();
			sri.Value = SearchData;

			return sri;
		}

		public SearchEngine(Process process, string searchType)
		{
			this.lockedProcess = process;
			this.SearchType = searchType;
		}

		public string Name { get; set; }
		public SearchBase SearchData { get; set; }

		public event ProgressChangedEventHandler ReportProgress;

		public void Search()
		{
			if (firstSearchDone)
				FilterSearch();
			else
				InitialSearch();
		}

		List<PageInfo> FindAllPages()
		{
			List<PageInfo> pages = new List<PageInfo>();

			MEMORY_BASIC_INFORMATION m;
			long MaxAddress = uint.MaxValue;// 0x7fffffffffffffffL;
			long address = 0;

			do
			{
				int result = PInvoke.VirtualQueryEx(lockedProcess.Handle.ToInt32(), (int)address, out m, (uint)Marshal.SizeOf(typeof(MEMORY_BASIC_INFORMATION)));

				if (m.RegionSize != 0)
					pages.Add(new PageInfo { PageStart = (long)m.BaseAddress, PageEnd = (long)(m.BaseAddress + m.RegionSize - 1) });

				if (address == (long)m.BaseAddress + m.RegionSize)
					break;

				address = (long)m.BaseAddress + m.RegionSize;
			}
			while (address <= MaxAddress);

			return pages;
		}

		void ScanPage(long start, long end, SearchBase searchData)
		{
			byte[] buf = new byte[Math.Max(Math.Min(unchecked(end - start), 65536), 0)];
			int bytesRead = 0;
			long currentPtr = start;

			int alignment = PresumeAlignment ? searchData.Alignment : 1;

			while (currentPtr < end)
			{
				// Ignore handles over x86
				if (currentPtr + buf.Length > int.MaxValue)
					break;

				if (PInvoke.ReadProcessMemory(lockedProcess.Handle, new IntPtr(currentPtr), buf, buf.Length, out bytesRead))
				{
					for (int i = 0; i < bytesRead - searchData.Length; i += alignment)
					{
						bool ok = searchData.Find(buf, i);

						if (ok)
							locations.Add(new IntPtr(currentPtr + i));
					}
				}

				currentPtr += (long)(buf.Length - searchData.Length);
			}
		}

		public void OnReportProgress(int progress, object userState)
		{
			if (ReportProgress != null)
				ReportProgress(this, new ProgressChangedEventArgs(progress, userState));
		}

		void InitialSearch()
		{
			Stopwatch sw = Stopwatch.StartNew();

			locations.Clear();

			// First search
			var pages = FindAllPages();

			long bytesCurrent = 0;
			long bytesTotal = pages.Sum(i => i.PageEnd - i.PageStart);

			Parallel.ForEach(pages, page =>
			//pages.AsParallel().WithExecutionMode(ParallelExecutionMode.ForceParallelism).WithDegreeOfParallelism(16).ForAll(page =>
			{
				ScanPage(page.PageStart, page.PageEnd, SearchData);

				Interlocked.Add(ref bytesCurrent, page.PageEnd - page.PageStart);

				OnReportProgress((int)((bytesCurrent * 100) / bytesTotal), null);
			});

			sw.Stop();

			SystemSounds.Beep.Play();
			OnReportProgress(100, string.Format("Found {0} occurences in {1:f2} s.", locations.Count, (float)sw.ElapsedMilliseconds / 1000f));

			firstSearchDone = true;
		}

		void FilterSearch()
		{
			OnReportProgress(0, null);

			byte[] buf = new byte[SearchData.Length];
			int bytesRead = 0;

			List<IntPtr> oldLocations = locations;
			locations = new List<IntPtr>();

			int lastPerc = 0;

			// Go through all the past occurences
			for (int idx = 0; idx < oldLocations.Count; idx++)
			{
				IntPtr locPtr = oldLocations[idx];

				if (PInvoke.ReadProcessMemory(lockedProcess.Handle, locPtr, buf, buf.Length, out bytesRead))
				{
					bool ok = SearchData.Find(buf, 0);

					if (ok)
					{
						locations.Add(locPtr);
						continue;
					}
				}

				int percComplete = (idx * 100) / oldLocations.Count;

				if (percComplete != lastPerc)
				{
					OnReportProgress(percComplete, null);
					lastPerc = percComplete;
				}
			}

			SystemSounds.Beep.Play();
			OnReportProgress(100, string.Format("{0} occurences remaining.", locations.Count));

			lastLocationCount = locations.Count;
		}
	}
}
