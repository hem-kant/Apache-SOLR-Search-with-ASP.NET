using System.Collections.Generic;
using SolrNet;
using SolrNet.Impl;

namespace Solr.Classes
{
	public class SearchResult
	{
		public IEnumerable<Player> Result { get; set; }
		public int QueryTime { get; set; }
		public int TotalHits { get; set; }
	}
}