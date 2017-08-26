using System;
using System.Collections.Generic;
using System.Text;
using LocationParser.Models.Internal;

namespace LocationParser.Data
{
	class FileStore : IDataStore
	{
		public void Copy(string nameFrom, string nameTo)
		{
			throw new NotImplementedException();
		}

		public TimeLine Retrieve(string name)
		{
			throw new NotImplementedException();
		}

		public void Store(string name, TimeLine timeLine)
		{
			throw new NotImplementedException();
		}
	}
}
