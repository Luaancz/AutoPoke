using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;
using System.Media;
using Luaan.AutoPoke.SearchTypes;
using System.Reflection;
using System.Globalization;

namespace Luaan.AutoPoke
{
	public partial class MainForm : Form
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="MainForm"/> class.
		/// </summary>
		public MainForm()
		{
			InitializeComponent();

			bwMemoryScan.DoWork += new DoWorkEventHandler(bwMemoryScan_DoWork);
			bwMemoryScan.ProgressChanged += new ProgressChangedEventHandler(bwMemoryScan_ProgressChanged);

			ddlSearchType.SelectedIndex = 0;
		}

		void bwMemoryScan_ProgressChanged(object sender, ProgressChangedEventArgs e)
		{
			pbScanProgress.Value = Math.Max(Math.Min(e.ProgressPercentage, 100), 0);
			if (e.UserState != null)
				lblMessage.Text = e.UserState as string;
			else
				lblMessage.Text = "Working...";
		}

		Dictionary<int, Process> processes;

		void bwMemoryScan_DoWork(object sender, DoWorkEventArgs e)
		{
			try
			{
				var search = e.Argument as SearchEngine;

				search.Search();

				if (search.LocationCount == 0)
					Invoke(new ThreadStart(() => { lvSearches.Items.Remove(lvSearches.SelectedItems[0]); }));
			}
			finally
			{
				Invoke(new ThreadStart(UpdateSearches));
			}
		}

		void UpdateSearches()
		{
			if (lvSearches.SelectedItems.Count > 0)
			{
				var lvi = lvSearches.SelectedItems[0];
				var engine = lvi.Tag as SearchEngine;

				lvi.SubItems[1].Text = engine.SearchData.GetText();
				lvi.SubItems[3].Text = engine.LocationCount.ToString();
			}

			Cursor = Cursors.Default;
			btnSearch.Enabled = true;
			lvSearches.Enabled = true;
		}

		string GetProcessName(Process p)
		{
			bool isDotNet = false;

			try
			{
				if (p.Modules.OfType<ProcessModule>().Any(i => i.ModuleName.ToLower() == "mscoree.dll"))
					isDotNet = true;
			}
			catch {}

			return string.Format("{0} ({1})", p.MainWindowTitle, p.Id) + (isDotNet ? " - .NET" : string.Empty);
		}

		private void btnReloadProcesses_Click(object sender, EventArgs e)
		{
			processes = Process.GetProcesses().Where(i => i.MainWindowHandle != IntPtr.Zero).ToDictionary(i => i.Id);
			
			ddlProcesses.DataSource = processes.Select(i => new ProcessListItem { Text = GetProcessName(i.Value), Id = i.Key }).ToList();
		}
		
		private void btnSearch_Click(object sender, EventArgs e)
		{
			if (bwMemoryScan.IsBusy)
			{
				toolTipError.Show("A search is alread underway. You have to wait for it to finish.", btnSearch, 1000);

				return;
			}

			if (lvSearches.SelectedItems.Count == 0)
			{
				toolTipError.Show("You have to select a search item to search a value of.", lvSearches, 1000);

				return;
			}

			var engine = lvSearches.SelectedItems[0].Tag as SearchEngine;

			SearchBase searchData;

			try
			{
				switch (engine.SearchType)
				{
					case "ΔSingle": searchData = new SingleSearch(tbxSearchValue.Text, float.Parse(tbxDelta.Text.Replace(",", "."), CultureInfo.InvariantCulture)); break;
					case "ΔDouble": searchData = new DoubleSearch(tbxSearchValue.Text, double.Parse(tbxDelta.Text.Replace(",", "."), CultureInfo.InvariantCulture)); break;
					case "ΔInt32": searchData = new Int32DeltaSearch(tbxSearchValue.Text, int.Parse(tbxDelta.Text)); break;
					case "Int16": searchData = new Int16Search(tbxSearchValue.Text); break;
                    case "Int32*": searchData = new Int32PrefixSearch(tbxSearchValue.Text); break;
					case "Int32":
					default:
						searchData = new Int32Search(tbxSearchValue.Text); break;
				}
			}
			catch (Exception ex)
			{
				toolTipError.Show(ex.Message, tbxSearchValue, 2000);

				return;
			}

			engine.SearchData = searchData;
			engine.PresumeAlignment = cbxPresumeAlignment.Checked;

			btnSearch.Enabled = false;

			bwMemoryScan.RunWorkerAsync(engine);

			Cursor = Cursors.WaitCursor;
		}

		private void btnAddToList_Click(object sender, EventArgs e)
		{
			if (lvSearches.SelectedItems.Count == 0)
			{
				toolTipError.Show("You have to select the search item you want to add to the data item list.", lvSearches, 1000);

				return;
			}

			SearchEngine engine = lvSearches.SelectedItems[0].Tag as SearchEngine;

			ScanResultInformation sri = engine.GetResults();

			var group = lvFound.Groups.OfType<ListViewGroup>().Where(i => (int)i.Tag == sri.ParentProcess.Id).FirstOrDefault();

			if (group == null)
				lvFound.Groups.Add(group = new ListViewGroup(sri.ParentProcess.MainWindowTitle + " (" + sri.ParentProcess.Id.ToString() + ")") { Tag = sri.ParentProcess.Id });

			ListViewItem lvi = new ListViewItem();
			lvi.Group = group;
			lvi.Text = engine.Name;
			lvi.SubItems.Add(sri.Value.ToString());
			lvi.SubItems.Add(string.Join(", ", sri.MemoryPointers.Select(i => "0x" + i.ToInt32().ToString("X8")).ToArray()));
			lvi.SubItems.Add(sri.MaintainValue.ToString());
			lvi.SubItems.Add(sri.Value.TypeName);

			lvi.Tag = sri;
			lvFound.Items.Add(lvi);

			lvSearches.Items.Remove(lvSearches.SelectedItems[0]);
		}

		private void btnSet_Click(object sender, EventArgs e)
		{
			if (lvFound.SelectedItems.Count == 0)
			{
				toolTipError.Show("You have to select the data item you want to change the value of.", lvFound, 1000);

				return;
			}

			ScanResultInformation sri = lvFound.SelectedItems[0].Tag as ScanResultInformation;

			if (sri.ParentProcess.HasExited)
			{
				lvFound.Items.Remove(lvFound.SelectedItems[0]);
				return;
			}

			try
			{
				sri.Value = sri.Value.ChangeValue(tbxSetValue.Text);
				Write(sri);
			}
			catch (Exception ex)
			{
				toolTipError.Show(ex.Message, tbxSetValue, 2000);
			}
		}

		void Write(ScanResultInformation sri)
		{
			uint bytesWritten;

			foreach (var ptr in sri.MemoryPointers)
				PInvoke.WriteProcessMemory(sri.ParentProcess.Handle.ToInt32(), ptr.ToInt32(), sri.Value.GetBytes(), (uint)sri.Value.Length, out bytesWritten);
		}

		private void lvFound_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
		{
			btnRemoveFromList.Enabled = btnSet.Enabled = cbxMaintainValue.Enabled = lvFound.SelectedItems.Count > 0;

			if (lvFound.SelectedItems.Count > 0)
			{
				cbxMaintainValue.Checked = (lvFound.SelectedItems[0].Tag as ScanResultInformation).MaintainValue;
			}
		}

		void RefreshValues()
		{
			for (int i = 0; i < lvFound.Items.Count; i++)
			{
				var item = lvFound.Items[i];
				var sri = item.Tag as ScanResultInformation;

				if (sri.ParentProcess.HasExited)
				{
					lvFound.Items.Remove(item);
					i--;
					continue;
				}

				byte[] buf = new byte[sri.Value.Length];
				int bytesRead = 0;

				PInvoke.ReadProcessMemory(sri.ParentProcess.Handle, sri.MemoryPointers[0], buf, buf.Length, out bytesRead);

				var newValue = sri.Value.ChangeValue(buf);

				if (sri.MaintainValue && !sri.Value.Equals(newValue))
				{
					Write(sri);
				}
				else
					item.SubItems[1].Text = newValue.GetText();
			}
		}

		private void tbxSearchValue_KeyUp(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
				btnSearch.PerformClick();
		}

		private void tbxTitle_KeyUp(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
				btnAddSearch.PerformClick();
		}

		private void btnRemoveFromList_Click(object sender, EventArgs e)
		{
			if (lvFound.SelectedItems.Count > 0)
				lvFound.Items.Remove(lvFound.SelectedItems[0]);
			else
				toolTipError.Show("You have to select the data item you want to remove.", lvFound, 1000);
		}

		private void refreshTimer_Tick(object sender, EventArgs e)
		{
			RefreshValues();
		}

		private void cbxMaintainValue_CheckedChanged(object sender, EventArgs e)
		{
			if (lvFound.SelectedItems.Count == 0)
			{
				toolTipError.Show("You have to select the data item you want to maintain value of.", lvFound, 1000);

				return;
			}

			ScanResultInformation sri = lvFound.SelectedItems[0].Tag as ScanResultInformation;
			sri.MaintainValue = cbxMaintainValue.Checked;
			lvFound.SelectedItems[0].SubItems[3].Text = sri.MaintainValue.ToString();
		}

		private void btnTest_Click(object sender, EventArgs e)
		{

		}

		private void btnAddSearch_Click(object sender, EventArgs e)
		{
			if (ddlProcesses.SelectedItem == null)
			{
				toolTipError.Show("You have to select a process from the dropdown control.", ddlProcesses, 1000);

				return;
			}


			SearchEngine engine = new SearchEngine(processes[((ProcessListItem)ddlProcesses.SelectedItem).Id], ddlSearchType.SelectedItem as string);
			engine.ReportProgress += new ProgressChangedEventHandler((s, args) => { bwMemoryScan.ReportProgress(args.ProgressPercentage, args.UserState); });

			var group = lvSearches.Groups.OfType<ListViewGroup>().Where(i => (int)i.Tag == engine.Process.Id).FirstOrDefault();

			if (group == null)
				lvSearches.Groups.Add(group = new ListViewGroup(engine.Process.MainWindowTitle + " (" + engine.Process.Id.ToString() + ")") { Tag = engine.Process.Id });

			ListViewItem lvi = new ListViewItem();
			lvi.Group = group;
			lvi.Text = engine.Name =  tbxTitle.Text;
			lvi.SubItems.Add(string.Empty);
			lvi.SubItems.Add(engine.SearchType);
			lvi.SubItems.Add(string.Empty);
			lvi.Tag = engine;

			lvSearches.Items.Add(lvi);
		}

		private void btnSearchRemove_Click(object sender, EventArgs e)
		{
			if (lvSearches.SelectedItems.Count == 0)
			{
				toolTipError.Show("You have to select a search item to remove.", lvSearches, 1000);

				return;
			}

			lvSearches.Items.Remove(lvSearches.SelectedItems[0]);
		}

		private void tbxSetValue_KeyUp(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
				btnSet.PerformClick();
		}
	}
}
