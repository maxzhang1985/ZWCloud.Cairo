// Copyright (C) 2015  Zou Wei, zwcloud@yeah.net, http://zwcloud.net
// 
// This library is free software; you can redistribute it and/or
// modify it under the terms of the GNU Lesser General Public
// License as published by the Free Software Foundation; either
// version 3 of the License, or (at your option) any later version.
// 
// This library is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
// Lesser General Public License for more details.
// 
// You should have received a copy of the GNU Lesser General Public
// License along with this library; if not, write to the Free Software
// Foundation, Inc., 51 Franklin Street, Suite 500, Boston, MA 02110-1335, USA
//
using System;
using System.Runtime.InteropServices;
using Cairo;

namespace Cairo {

	public class Path : IDisposable
	{
		IntPtr handle = IntPtr.Zero;

		internal Path (IntPtr handle)
		{
			if (handle == IntPtr.Zero)
				throw new ArgumentException ("handle should not be NULL", "handle");

			this.handle = handle;
			if (CairoDebug.Enabled)
				CairoDebug.OnAllocated (handle);
		}

		~Path ()
		{
			Dispose (false);
		}

		public IntPtr Handle { get { return handle; } }

		public void Dispose ()
		{
			Dispose (true);
			GC.SuppressFinalize (this);
		}

		protected virtual void Dispose (bool disposing)
		{
			if (!disposing || CairoDebug.Enabled)
				CairoDebug.OnDisposed<Path> (handle, disposing);

			if (handle == IntPtr.Zero)
				return;

			NativeMethods.cairo_path_destroy (handle);
			handle = IntPtr.Zero;
		}
	}
}
