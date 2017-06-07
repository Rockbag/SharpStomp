using System;
using System.Collections.Generic;


namespace UnityStomp.Client
{
	public class StompFrame : Frame
	{
		public StompFrame (string body, Dictionary<string, string> headers) : base(ClientFrames.STOMP, body, headers)
		{
		}

		protected override void validate ()
		{
			base.validate ();
			if (!headers.ContainsKey (Headers.ACCEPT_VERSION)) {
				throw new ArgumentException ("As per specification: STOMP 1.2 clients MUST set the accept-version header");
			}

			if (!headers.ContainsKey (Headers.HOST)) {
				throw new ArgumentException ("As per specification: STOMP 1.2 clients MUST set the host header");
			}
		}
	}
}

