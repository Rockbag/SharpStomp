using System;
using System.Collections.Generic;

namespace UnityStomp
{
	public class ReceiptFrame : Frame
	{
		public ReceiptFrame (string body, Dictionary<string, string> headers) : base(StompCommands.RECEIPT, body, headers)
		{
		}


		protected override void validate ()
		{
			base.validate ();
		}
	}
}

