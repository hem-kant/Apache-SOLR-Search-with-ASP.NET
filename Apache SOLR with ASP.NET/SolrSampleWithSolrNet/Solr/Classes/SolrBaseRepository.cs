using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SolrNet;

namespace Solr.Classes
{
	/// <summary>
	/// Base repository for Solr
	/// </summary>
	public class SolrBaseRepository
	{
		/// <summary>
		/// New instance of Solr
		/// </summary>
		/// <typeparam name="T">Specific type</typeparam>
		public class Instance<T>
		{
			/// <summary>
			/// Start Solr instance for a specific type
			/// </summary>
			public void Start()
			{
				var instances = Startup.Container.GetAllInstances(typeof (ISolrOperations<T>));

				if (instances.Count() == 0)
				{
					Startup.Init<T>(Toolbox.SolrUrl);
				}
			}

		}
	}
}