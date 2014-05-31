using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Luaan.AutoPoke.SearchTypes
{
	public abstract class SearchBase : IEquatable<SearchBase>
	{
		public SearchBase(string searchText) { }
		public SearchBase(byte[] bytes) { }

		/// <summary>
		/// Gets the memory alignment of this type.
		/// </summary>
		public abstract int Alignment { get; }
		/// <summary>
		/// Gets the length of this type (if applicable).
		/// </summary>
		public abstract int Length { get; }
		/// <summary>
		/// Gets the name of the type.
		/// </summary>
		/// <value>
		/// The name of the type.
		/// </value>
		public abstract string TypeName { get; }

		/// <summary>
		/// Gets the textual representation of the search value.
		/// </summary>
		/// <returns></returns>
		public abstract string GetText();
		/// <summary>
		/// Gets the in-memory byte representation of the search value.
		/// </summary>
		/// <returns></returns>
		public abstract byte[] GetBytes();
		/// <summary>
		/// Tries to find the search value in the specified byte array, starting at the specified offset.
		/// </summary>
		/// <param name="buf">The buf.</param>
		/// <param name="offset">The offset.</param>
		/// <returns></returns>
		public abstract bool Find(byte[] buf, int offset);
		/// <summary>
		/// Returns a new identical instance of the search class with a different search value.
		/// </summary>
		/// <param name="searchText">The search text.</param>
		/// <returns></returns>
		public abstract SearchBase ChangeValue(string searchText);
		/// <summary>
		/// Returns a new identical instance of the search class with a different search value.
		/// </summary>
		/// <param name="bytes">The bytes.</param>
		/// <returns></returns>
		public abstract SearchBase ChangeValue(byte[] bytes);

		/// <summary>
		/// Indicates whether the current object is equal to another object of the same type.
		/// </summary>
		/// <param name="other">An object to compare with this object.</param>
		/// <returns>
		/// true if the current object is equal to the <paramref name="other"/> parameter; otherwise, false.
		/// </returns>
		public abstract bool Equals(SearchBase other);
	}
}
