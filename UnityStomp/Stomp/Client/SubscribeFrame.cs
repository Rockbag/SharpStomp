using System;
using System.Collections.Generic;

namespace UnityStomp
{
	public class SubscribeFrame : Frame
	{
		public SubscribeFrame (string body, Dictionary<string, string> headers) : base(StompCommands.SUBSCRIBE, body, headers)
		{
		}

		protected override void validate ()
		{
			if (!Headers.ContainsKey (StompHeaders.ID)) {
				throw new ArgumentException ("The SUBSCRIBE frame has one REQUIRED header, id.");
			}
			base.validate ();
		}
	}
}

