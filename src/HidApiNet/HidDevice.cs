using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace HidApiNet
{
	public class HidDevice : IDisposable
	{
		public HidDeviceInfo info;
		private IntPtr hid = IntPtr.Zero;

		public HidDevice(string path)
		{
			var res = NativeMethods.hid_init();
			if (res != 0)
				return;

		    this.hid = NativeMethods.hid_open_path(path);
		}

		public HidDevice(ushort vid, ushort pid)
		{
			var res = NativeMethods.hid_init();
			if (res != 0)
				return;
			//this.hid = HIDApi.hid_open(vid, pid, null);
			
			var ptr = NativeMethods.hid_enumerate(vid, pid);
			if (ptr == IntPtr.Zero)
				return;

			info = (HidDeviceInfo)Marshal.PtrToStructure(ptr, typeof(HidDeviceInfo));
			hid = NativeMethods.hid_open_path(info.path);
		}

		public bool IsOpen
		{
			get
			{
				return this.hid != IntPtr.Zero;
			}
		}

		private enum PropName
		{
			Unknown,
			ProductString,
			ManufacturerString,
			SerialNumberString,
			IndexedString
		}

		private string GetPropValue(PropName name, int index = 0)
		{
			int res;
			string s = new string('*', 128);
			switch (name)
			{
				case PropName.ProductString:
					res = NativeMethods.hid_get_product_string(this.hid, s, s.Length);
					break;
				case PropName.ManufacturerString:
					res = NativeMethods.hid_get_manufacturer_string(this.hid, s, s.Length);
					break;
				case PropName.SerialNumberString:
					res = NativeMethods.hid_get_serial_number_string(this.hid, s, s.Length);
					break;
				case PropName.IndexedString:
					res = NativeMethods.hid_get_indexed_string(this.hid, index, s, s.Length);
					break;
				default:
					return null;
			}
			if (res != 0)
				return null;
			else
				return s;
		}

		public string ProductString
		{
			get
			{
				return GetPropValue(PropName.ProductString);
			}
		}

		public string ManufacturerString
		{
			get
			{
				return GetPropValue(PropName.ManufacturerString);
			}
		}

		public string SerialNumberString
		{
			get
			{
				return GetPropValue(PropName.SerialNumberString);
			}
		}

		public string IndexedString(int index)
		{
			return GetPropValue(PropName.IndexedString, index);
		}

		public int SetNonBlocking()
		{
			return NativeMethods.hid_set_nonblocking(this.hid, 1);
		}

		public int Write(byte[] buffer)
		{
			return NativeMethods.hid_write(this.hid, buffer, buffer.Length);
		}

		public int Read(byte[] buffer, int len)
		{
			return NativeMethods.hid_read(this.hid, buffer, len);
		}

		public int ReadTimeOut(byte[] buffer, int t)
		{
			return NativeMethods.hid_read_timeout(this.hid, buffer, buffer.Length, t);
		}


		public void Dispose()
		{
			if (this.hid != IntPtr.Zero)
				NativeMethods.hid_close(hid);
			NativeMethods.hid_exit();
		}
	}
}
