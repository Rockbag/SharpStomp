using System;
using System.Collections.Generic;

namespace SharpStomp
{
	public class ConnectFrame : Frame
	{

		public ConnectFrame (string body, Dictionary<string, string> headers) : base(StompCommands.CONNECT, body, headers)
		{
		}

		protected override void validate ()
		{
			base.validate ();
			if (!Headers.ContainsKey (StompHeaders.ACCEPT_VERSION)) {
				throw new ArgumentException ("As per specification: Connect frames MUST set the accept-version header");
			}

			if (!Headers.ContainsKey (StompHeaders.HOST)) {
				throw new ArgumentException ("As per specification: Connect frames MUST set the host header");
			}

			if (Headers.ContainsKey(StompHeaders.RECEIPT)) {
				throw new ArgumentException ("Any client frame other than CONNECT MAY specify a receipt header with an arbitrary value.");
			}	

			if (!string.IsNullOrEmpty (Body)) {
				throw new ArgumentException ("As per specification: Only the SEND, MESSAGE, and ERROR frames MAY have a body. All other frames MUST NOT have a body.");
			}
		}
	}
}

