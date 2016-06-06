using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Solr.Classes
{
	internal static class Extensions
	{
		public static IEnumerable<IEnumerable<T>> Batch<T>(this IEnumerable<T> source, int batchSize)
		{
			for (IEnumerable<T> s = source; s.Any(); s = s.Skip(batchSize))
			{
				yield return s.Take(batchSize);
			}
		}

		public static string ToDelimetedString<T>(this IEnumerable<T> source)
		{
			return ToDelimetedString(source, ",");
		}

		public static string ToDelimetedString<T>(this IEnumerable<T> source, string delimiter)
		{
			return ToDelimetedString(source, delimiter, i => i.ToString());
		}

		public static string ToDelimetedString<T>(this IEnumerable<T> source, string delimiter, Func<T, string> stringSelector)
		{
			var builder = new StringBuilder();
			var list = source.ToList();
			if (!list.Any()) { return String.Empty; }
			for (int i = 0; i < list.Count-1; i++)
			{
				builder.AppendFormat("{0}{1}", list[i], delimiter);
			}
			builder.AppendFormat("{0}", list[list.Count - 1]);

			return builder.ToString();
		}

	}
}