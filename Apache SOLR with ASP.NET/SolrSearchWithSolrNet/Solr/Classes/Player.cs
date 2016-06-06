using SolrNet.Attributes;

namespace Solr.Classes
{
	/// <summary>
	/// Player object
	/// </summary>
	public class Player
	{
		[SolrUniqueKey("id")]
		public int Id { get; internal set; }

		[SolrField("firstname")]
		public string FirstName { get; internal set; }

		[SolrField("lastname")]
		public string LastName { get; internal set; }

		[SolrField("position")]
		public string Position { get; internal set; }
	}
}