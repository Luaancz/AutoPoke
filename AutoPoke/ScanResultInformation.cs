using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using Luaan.AutoPoke.SearchTypes;

namespace Luaan.AutoPoke
{
	public class ScanResultInformation
	{
		public Process ParentProcess { get; set; }
		public IntPtr[] MemoryPointers { get; set; }

		public SearchBase Value { get; set; }
		public bool MaintainValue { get; set; }
	}
}
