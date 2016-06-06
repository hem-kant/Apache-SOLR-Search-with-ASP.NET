using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Solr.Classes;

namespace Solr
{
	public partial class WebForm1 : System.Web.UI.Page
	{
	
		protected override void  OnLoad(EventArgs e)
		{
 			base.OnLoad(e);

		}

		protected void ReIndex(object sender, EventArgs e)
		{
			new DefaultIndexer().IndexPlayers();

			Toolbox.Utilities.GetMasterLiteral(Page).Text = "<p>Re-index done.</p>";
		}
	}
}