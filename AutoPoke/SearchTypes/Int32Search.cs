﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace Luaan.AutoPoke.SearchTypes
{
	public class Int32Search : SearchBase
	{
		int originalValue;
		byte[] searchBytes;

		/// <summary>
		/// Initializes a new instance of the <see cref="Int32Search"/> class.
		/// </summary>
		/// <param name="searchText">The search text.</param>
		public Int32Search(string searchText) : base(searchText)
		{
			this.originalValue = int.Parse(searchText);
			this.searchBytes = BitConverter.GetBytes(this.originalValue);
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="Int32Search"/> class.
		/// </summary>
		/// <param name="bytes">The bytes.</param>
		public Int32Search(byte[] bytes) : base(bytes)
		{
			this.searchBytes = (byte[])bytes.Clone();
			this.originalValue = BitConverter.ToInt32(this.searchBytes, 0);
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
			get { return "Int32"; }
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
			
			for (int j = 0; j < searchBytes.Length; j++)
				if (buf[offset + j] != searchBytes[j])
					return false;

			return true;
		}

		/// <summary>
		/// Returns a new identical instance of the search class with a different search value.
		/// </summary>
		/// <param name="searchText">The search text.</param>
		/// <returns></returns>
		public override SearchBase ChangeValue(string searchText)
		{
			return new Int32Search(searchText);
		}

		/// <summary>
		/// Returns a new identical instance of the search class with a different search value.
		/// </summary>
		/// <param name="bytes">The bytes.</param>
		/// <returns></returns>
		public override SearchBase ChangeValue(byte[] bytes)
		{
			return new Int32Search(bytes);
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
			if (!(other is Int32Search))
				return false;

			return originalValue == (other as Int32Search).originalValue;
		}
	}
}
