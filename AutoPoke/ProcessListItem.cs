using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Luaan.AutoPoke
{
	public class ProcessListItem
	{
		public int Id { get; set; }
		public string Text { get; set; }

		/// <summary>
		/// Returns a <see cref="System.String"/> that represents this instance.
		/// </summary>
		/// <returns>
		/// A <see cref="System.String"/> that represents this instance.
		/// </returns>
		public override string ToString()
		{
			return Text;
		}
	}
}
