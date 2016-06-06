using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Solr.Classes
{
	/// <summary>
	/// Toolbox with easier access to commonly used features
	/// </summary>
	public class Toolbox
	{
		/// <summary>
		/// Database access
		/// </summary>
		public class Db
		{
			/// <summary>
			/// Insert to database
			/// </summary>
			/// <param name="connString">Connection string</param>
			/// <param name="query">SQL query</param>
			public void Insert(string connString, string query)
			{
				var cn = new SqlConnection(connString);
				var cmd = new SqlCommand(query, cn);

				cmd.CommandText = query;

				try
				{
					cn.Open();
					cmd.ExecuteNonQuery();
				}
				catch(Exception ex)
				{
					throw ex;
				}
				finally
				{
					cmd.Connection.Close();
				}
			}
		}

		public static string ConnString
		{
			get { return ConfigurationManager.ConnectionStrings["dbSolr"].ConnectionString; }
		}

		public static string SolrUrl { get { return "http://localhost:8983/solr"; } }

		/// <summary>
		/// Utilities
		/// </summary>
		public class Utilities
		{
			/// <summary>
			/// Get Master Literal control
			/// </summary>
			/// <param name="p">System.Web.UI.Page</param>
			/// <returns>Master Literal</returns>
			public static Literal GetMasterLiteral(Page p)
			{
				string controlId = "litMsg";

				Literal lit = (Literal)p.Master.FindControl(controlId);

				return lit;
			}

			/// <summary>
			/// Format characters
			/// </summary>
			/// <param name="s">String</param>
			/// <returns>Formatted string</returns>
			public static string FormatChars(string s)
			{
				s = s.Replace("'", "''");

				return s;
			}
		}

	}
}