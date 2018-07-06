using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace HidApiNet
{
	public class HidDeviceInfoCollection : List<HidDeviceInfo>, IDisposable
	{
		private IntPtr devs = IntPtr.Zero;

		public HidDeviceInfoCollection()
		{
			var res = NativeMethods.hid_init();
			if (res != 0)
				return;

			this.devs = NativeMethods.hid_enumerate(0x00, 0x00);
			var curdev = new IntPtr(this.devs.ToInt32());
			while (curdev != IntPtr.Zero)
			{
				var info = (HidDeviceInfo)Marshal.PtrToStructure(curdev, typeof(HidDeviceInfo));
				this.Add(info);
				curdev = info.next;
			}
		}

		public void Dispose()
		{
			if (this.devs != IntPtr.Zero)
				NativeMethods.hid_free_enumeration(this.devs);
		}

	}

}
