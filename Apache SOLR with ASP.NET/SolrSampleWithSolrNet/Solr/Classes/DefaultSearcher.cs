using System.Collections.Generic;
using System.Linq;
using Microsoft.Practices.ServiceLocation;
using SolrNet;
using SolrNet.Commands.Parameters;

namespace Solr.Classes
{
	/// <summary>
	/// Default searcher
	/// </summary>
	public class DefaultSearcher
	{
		private readonly string _connString;
		private readonly string _solrUrl;

		public DefaultSearcher()
		{
			this._connString = Toolbox.ConnString;
			this._solrUrl = Toolbox.SolrUrl;
		}

		/// <summary>
		/// Do the search
		/// </summary>
		/// <param name="query">Search query</param>
		/// <param name="resultsPerPage">Number of results per page</param>
		/// <param name="pageNumber">Page number</param>
		/// <returns>Search result</returns>
		public SearchResult Search(string query, int resultsPerPage, int pageNumber)
		{
			new SolrBaseRepository.Instance<Player>().Start();

			var solr = ServiceLocator.Current.GetInstance<ISolrOperations<Player>>();

			var options = new QueryOptions
									{
										Rows = resultsPerPage,
										Start = (pageNumber - 1) * resultsPerPage
									};

			var results = solr.Query(query, options);
			var players = new PlayerRepository().GetPlayers(results.Select(r => r.Id));

			var searchResults = new SearchResult
			                    	{
			                    		Result = players,
			                    		QueryTime = results.Header.QTime,
			                    		TotalHits = results.Count
			                    	};

			return searchResults;
		}
	}
}