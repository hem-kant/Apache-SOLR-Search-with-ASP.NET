using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Practices.ServiceLocation;
using Solr.Classes;
using SolrNet;

namespace Solr
{
	public partial class RemoveFromIndex : System.Web.UI.Page
	{
		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad(e);

			int id;

			if (int.TryParse(Request.QueryString["id"], out id) == false)
			{
				id = -1;
			}

			if (id != -1) RemovePlayer(id);
		}

		void RemovePlayer(int id)
		{
			new SolrBaseRepository.Instance<Player>().Start();

			var solr = ServiceLocator.Current.GetInstance<ISolrOperations<Player>>();
			var specificPlayer = new PlayerRepository().GetPlayer(id);
			solr.Delete(specificPlayer);
			solr.Commit();

			Toolbox.Utilities.GetMasterLiteral(Page).Text = "<p>The item removed from index.</p>";
		}
	}
}