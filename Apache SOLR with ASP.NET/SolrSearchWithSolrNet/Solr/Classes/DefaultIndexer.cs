using Microsoft.Practices.ServiceLocation;
using SolrNet;

namespace Solr.Classes
{
	/// <summary>
	/// Default indexer
	/// </summary>
	public class DefaultIndexer
	{
		private readonly string _connString;
		private readonly string _solrUrl;

		public DefaultIndexer()
		{
			this._connString = Toolbox.ConnString;
			this._solrUrl = Toolbox.SolrUrl;
		}

		/// <summary>
		/// Add all players to the index
		/// </summary>
		public void IndexPlayers()
		{
			new SolrBaseRepository.Instance<Player>().Start();
			
			var solr = ServiceLocator.Current.GetInstance<ISolrOperations<Player>>();
			var players = new PlayerRepository().GetPlayers();
			
			solr.Add(players);
			solr.Commit();
		}

		/// <summary>
		/// Add specific player to the index
		/// </summary>
		/// <param name="player">Player</param>
		public void IndexPlayer(Player player)
		{
			new SolrBaseRepository.Instance<Player>().Start();

			var solr = ServiceLocator.Current.GetInstance<ISolrOperations<Player>>();
			var specificPlayer = new PlayerRepository().GetPlayer(player.FirstName, player.LastName, player.Position);
			
			solr.Add(specificPlayer);
			solr.Commit();
		}
	}
}