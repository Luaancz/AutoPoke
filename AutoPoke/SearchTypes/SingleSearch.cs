using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;
using System.Runtime.InteropServices;

namespace Luaan.AutoPoke.SearchTypes
{
	public class SingleSearch : SearchBase
	{
		float originalValue;
		float delta;
		byte[] searchBytes;

		/// <summary>
		/// Initializes a new instance of the <see cref="SingleSearch"/> class.
		/// </summary>
		/// <param name="searchText">The search text.</param>
		/// <param name="delta">The delta.</param>
		public SingleSearch(string searchText, float delta) : base(searchText)
		{
			this.originalValue = float.Parse(searchText.Replace(",", "."), CultureInfo.InvariantCulture);
			this.searchBytes = BitConverter.GetBytes(this.originalValue);
			this.delta = delta;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="SingleSearch"/> class.
		/// </summary>
		/// <param name="bytes">The bytes.</param>
		/// <param name="delta">The delta.</param>
		public SingleSearch(byte[] bytes, float delta) : base(bytes)
		{
			this.searchBytes = (byte[])bytes.Clone();
			this.originalValue = BitConverter.ToSingle(this.searchBytes, 0);
			this.delta = delta;
		}

		/// <summary>
		/// Gets the memory alignment of this type.
		/// </summary>
		public override int Alignment
		{
			get { return 4; }
		}

		/// <summary>
		/// Gets the length of this type (if applicable).
		/// </summary>
		public override int Length
		{
			get { return 4; }
		}

		/// <summary>
		/// Gets the name of the type.
		/// </summary>
		/// <value>
		/// The name of the type.
		/// </value>
		public override string TypeName
		{
			get { return "ΔSingle"; }
		}

		/// <summary>
		/// Gets the textual representation of the search value.
		/// </summary>
		/// <returns></returns>
		public override string GetText()
		{
			return this.originalValue.ToString();
		}

		/// <summary>
		/// Gets the in-memory byte representation of the search value.
		/// </summary>
		/// <returns></returns>
		public override byte[] GetBytes()
		{
			return this.searchBytes;
		}

		/// <summary>
		/// Tries to find the search value in the specified byte array, starting at the specified offset.
		/// </summary>
		/// <param name="buf">The buf.</param>
		/// <param name="offset">The offset.</param>
		/// <returns></returns>
		public override bool Find(byte[] buf, int offset)
		{
			if (buf.Length - offset < Length)
				return false;

			var pomValue = BitConverter.ToSingle(buf, offset);

			return Math.Abs(pomValue - originalValue) <= delta;
		}

		/// <summary>
		/// Returns a new identical instance of the search class with a different search value.
		/// </summary>
		/// <param name="searchText">The search text.</param>
		/// <returns></returns>
		public override SearchBase ChangeValue(string searchText)
		{
			return new SingleSearch(searchText, delta);
		}

		/// <summary>
		/// Returns a new identical instance of the search class with a different search value.
		/// </summary>
		/// <param name="bytes">The bytes.</param>
		/// <returns></returns>
		public override SearchBase ChangeValue(byte[] bytes)
		{
			return new SingleSearch(bytes, delta);
		}

		/// <summary>
		/// Indicates whether the current object is equal to another object of the same type.
		/// </summary>
		/// <param name="other">An object to compare with this object.</param>
		/// <returns>
		/// true if the current object is equal to the <paramref name="other"/> parameter; otherwise, false.
		/// </returns>
		public override bool Equals(SearchBase other)
		{
			if (!(other is SingleSearch))
				return false;

			return Math.Abs(originalValue - (other as SingleSearch).originalValue) <= delta;
		}
	}
}
