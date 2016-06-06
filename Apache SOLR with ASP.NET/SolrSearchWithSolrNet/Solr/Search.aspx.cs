using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Solr.Classes;

namespace Solr
{
	public partial class Search : System.Web.UI.Page
	{
		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad(e);

			string q = Request.QueryString["q"];

			if (!String.IsNullOrEmpty(q))
			{
				BasicSearchResult(q);
			}
		}

		protected void DoSearch(object sender, EventArgs e)
		{
			string query = tbSearch.Text;
			Response.Redirect("Search.aspx?q=" + query);
		}

		/// <summary>
		/// Search the index
		/// </summary>
		/// <param name="query">Search query</param>
		protected void BasicSearchResult(string query)
		{
			var search = new DefaultSearcher()
				.Search(query, 10, 1);
            
			rptResults.DataSource = search.Result;
			rptResults.DataBind();

			litNoOfHits.Text = "<p><strong>" + search.TotalHits.ToString() + "</strong> hits for \"" + query + "\".</p>";
		}

	}
}