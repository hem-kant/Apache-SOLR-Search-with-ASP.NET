using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace Solr.Classes
{
	public class PlayerRepository
	{

		private readonly string _connString;

		public PlayerRepository()
		{
			this._connString = Toolbox.ConnString;
		}

		/// <summary>
		/// Get all players from database
		/// </summary>
		/// <returns>All players</returns>
		public IEnumerable<Player> GetPlayers()
		{
			return ExecSql("SELECT * FROM tblPlayers");
		}

		/// <summary>
		/// Get players based on id
		/// </summary>
		/// <param name="id">Id</param>
		/// <returns>A set of players</returns>
		public IEnumerable<Player> GetPlayers(IEnumerable<int> id)
		{
			if (!id.Any()) { yield break; }
			string query = String.Format("SELECT * FROM tblPlayers WHERE id IN({0})", id.ToDelimetedString());
			foreach (var item in ExecSql(query))
			{
				yield return item;
			}
		}

		/// <summary>
		/// Get player based on several parameters
		/// </summary>
		/// <param name="firstName">First name</param>
		/// <param name="lastName">Last name</param>
		/// <param name="position">Position</param>
		/// <returns>Specific player</returns>
		public IEnumerable<Player> GetPlayer(string firstName, string lastName, string position)
		{
			string query = "SELECT * FROM tblPlayers WHERE firstname = '" + firstName + "' AND lastname='" + lastName +
			               "' AND position='" + position + "'";
			return ExecSql(query);
		}

		/// <summary>
		/// Select specific player based on ID
		/// </summary>
		/// <param name="id">ID param</param>
		/// <returns>Specific player</returns>
		public IEnumerable<Player> GetPlayer(int id)
		{
			string query = "SELECT * FROM tblPlayers WHERE id = " + id;
			return ExecSql(query);
		}

		/// <summary>
		/// Execute a SQL query
		/// </summary>
		/// <param name="query">SQL query</param>
		/// <returns></returns>
		private IEnumerable<Player> ExecSql(string query)
		{
			var cn = new SqlConnection(this._connString);
			var cmd = new SqlCommand(query, cn);
			{
				cmd.CommandText = query;
				cn.Open();
				var rdr = cmd.ExecuteReader();
				while (rdr.Read())
				{
					yield return FromReader(rdr);
				}
			}

			cmd.Connection.Close();
			cmd.Connection.Dispose();
		}

		/// <summary>
		/// Create new Player object and assign data to it
		/// </summary>
		/// <param name="rdr">SqlDataReader</param>
		/// <returns>Player object</returns>
		private static Player FromReader(SqlDataReader rdr)
		{
			var res = new Player
			          	{
			          		Id = (int) rdr["id"],
			          		FirstName = rdr["firstname"] as string,
			          		LastName = rdr["lastname"] as string,
			          		Position = rdr["position"] as string
			          	};

			return res;
		}

	}
}