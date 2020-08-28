using System;

namespace Ifns51.ToAis
{
	public class SrvResponse
	{
		public OperationStatus Status
		{
			get;
			set;
		}

		public string Message
		{
			get;
			set;
		}

		public Guid Id
		{
			get;
			set;
		}
	}
}
