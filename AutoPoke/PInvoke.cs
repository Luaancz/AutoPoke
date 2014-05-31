using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace Luaan.AutoPoke
{
	public class PInvoke
	{
		[DllImport("kernel32.dll", SetLastError = true)]
		public static extern bool ReadProcessMemory(
			IntPtr hProcess,
			IntPtr lpBaseAddress,
			[Out] byte[] lpBuffer,
			int dwSize,
			out int lpNumberOfBytesRead
		 );

		[DllImport("kernel32.dll")]
		public static extern int VirtualQueryEx(int hProcess, int lpAddress, out MEMORY_BASIC_INFORMATION lpBuffer, uint dwLength);

		[DllImport("kernel32.dll", SetLastError = true)]
		public static extern bool WriteProcessMemory(int hProcess, int lpBaseAddress, byte[] lpBuffer, uint nSize, out uint lpNumberOfBytesWritten);
	}

	public struct MEMORY_BASIC_INFORMATION
	{
		public uint BaseAddress;
		public uint AllocationBase;
		public AllocationProtectEnum AllocationProtect;
		public uint RegionSize;
		public StateEnum State;
		public AllocationProtectEnum Protect;
		public TypeEnum Type;
	}

	public enum AllocationProtectEnum : uint
	{
		PAGE_EXECUTE = 0x00000010,
		PAGE_EXECUTE_READ = 0x00000020,
		PAGE_EXECUTE_READWRITE = 0x00000040,
		PAGE_EXECUTE_WRITECOPY = 0x00000080,
		PAGE_NOACCESS = 0x00000001,
		PAGE_READONLY = 0x00000002,
		PAGE_READWRITE = 0x00000004,
		PAGE_WRITECOPY = 0x00000008,
		PAGE_GUARD = 0x00000100,
		PAGE_NOCACHE = 0x00000200,
		PAGE_WRITECOMBINE = 0x00000400
	}

	public enum StateEnum : uint
	{
		MEM_COMMIT = 0x1000,
		MEM_FREE = 0x10000,
		MEM_RESERVE = 0x2000
	}

	public enum TypeEnum : uint
	{
		MEM_IMAGE = 0x1000000,
		MEM_MAPPED = 0x40000,
		MEM_PRIVATE = 0x20000
	}
}
