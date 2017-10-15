using System;
using System.Collections.Generic;

namespace UnityStomp
{
	public class MessageFrame : Frame
	{
		public MessageFrame (string body, Dictionary<string, string> headers) : base(StompCommands.MESSAGE, body, headers)
		{
		}


		protected override void validate ()
		{
			base.validate ();
		}
	}
}

