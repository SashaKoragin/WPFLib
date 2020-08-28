using System;
using System.Collections.Generic;

namespace Ifns51.FromAis
{
	public class AisParsedData
	{
		public string N134
		{
			get;
			set;
		}

		public string Tree
		{
			get;
			set;
		}

		public List<Dictionary<string,string>> Data
		{
			get;
			set;
		} = new List<Dictionary<string, string>>();
	}
}
