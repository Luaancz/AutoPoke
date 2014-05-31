using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;

namespace Luaan.AutoPoke.SearchTypes
{
	public class DecimalSearch : SearchBase
	{
		decimal originalValue;
		decimal delta;
		byte[] searchBytes;
		decimal decimalPoint = 1M;

		public DecimalSearch(string searchText, decimal delta) : base(searchText)
		{
			this.originalValue = decimal.Parse(searchText.Replace(",", "."), CultureInfo.InvariantCulture);
			this.delta = delta;
		}

		public DecimalSearch(byte[] bytes, decimal delta) : base(bytes)
		{
			this.searchBytes = (byte[])bytes.Clone();
			this.originalValue = BitConverter.ToInt32(this.searchBytes, 0);
			this.delta = delta;
		}

		public override int Alignment
		{
			get { return 4; }
		}

		public override int Length
		{
			get { return 4; }
		}

		public override string TypeName
		{
			get { return "Single"; }
		}

		public override string GetText()
		{
			return this.originalValue.ToString();
		}

		public override byte[] GetBytes()
		{
			if (this.searchBytes != null)
				return this.searchBytes;
			else
				return this.searchBytes = BitConverter.GetBytes((int)(originalValue * decimalPoint));
		}

		public override bool Find(byte[] buf, int offset)
		{
			if (buf.Length - offset < Length)
				return false;

			var pomValue = BitConverter.ToInt32(buf, offset);

			return Math.Abs((pomValue * decimalPoint) - originalValue) < delta;
		}
		
		public override SearchBase ChangeValue(string searchText)
		{
			return new DecimalSearch(searchText, delta);
		}

		public override SearchBase ChangeValue(byte[] bytes)
		{
			return new DecimalSearch(bytes, delta);
		}

		public override bool Equals(SearchBase other)
		{
			if (!(other is DecimalSearch))
				return false;

			return Math.Abs(originalValue - (other as DecimalSearch).originalValue) < delta;
		}
	}
}
