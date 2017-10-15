using System;
using System.Collections.Generic;


namespace UnityStomp
{
	public class StompFrame : Frame
	{
		public StompFrame (string body, Dictionary<string, string> headers) : base(StompCommands.STOMP, body, headers)
		{
		}

		protected override void validate ()
		{
			base.validate ();
			if (!Headers.ContainsKey (StompHeaders.ACCEPT_VERSION)) {
				throw new ArgumentException ("As per specification: STOMP 1.2 clients MUST set the accept-version header");
			}

			if (!Headers.ContainsKey (StompHeaders.HOST)) {
				throw new ArgumentException ("As per specification: STOMP 1.2 clients MUST set the host header");
			}
		}
	}
}

