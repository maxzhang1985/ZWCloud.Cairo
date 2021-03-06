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

namespace Cairo {

	public class PdfSurface : Surface
	{
		internal PdfSurface (IntPtr handle, bool owns) : base (handle, owns)
		{
		}

		public PdfSurface (string filename, double width, double height)
			: base (NativeMethods.cairo_pdf_surface_create (filename, width, height), true)
		{
		}

		public void SetSize (double width, double height)
		{
			CheckDisposed ();
			NativeMethods.cairo_pdf_surface_set_size (Handle, width, height);
		}
	}
}

