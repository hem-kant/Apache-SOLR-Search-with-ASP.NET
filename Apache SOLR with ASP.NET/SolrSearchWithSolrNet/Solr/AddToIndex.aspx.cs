using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Solr.Classes;

namespace Solr
{
	public partial class AddToIndex : System.Web.UI.Page
	{
		protected override void OnLoad(EventArgs e)
		{
			
			base.OnLoad(e);
		}

		/// <summary>
		/// Add player to database (and index)
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		protected void AddPlayer(object sender, EventArgs e)
		{
			string firstName, lastName, position;
			firstName = tbFirstName.Text;
			lastName = tbLastName.Text;
			position = ddlPosition.SelectedValue;

			new Toolbox.Db().Insert(Toolbox.ConnString,
			                        "INSERT INTO tblPlayers(firstname,lastname,position) VALUES('" + Toolbox.Utilities.FormatChars(firstName) + "','" + Toolbox.Utilities.FormatChars(lastName) +
			                        "','" + Toolbox.Utilities.FormatChars(position) + "')");

			var player = new Player 
				{
					FirstName = firstName,
					LastName = lastName,
					Position = position
				};

			new DefaultIndexer().IndexPlayer(player);

			Toolbox.Utilities.GetMasterLiteral(Page).Text = "<p>Player added, index re-indexed.";
		}
	}
}