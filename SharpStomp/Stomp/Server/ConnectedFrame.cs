using System;
using System.Collections.Generic;

namespace SharpStomp
{
	public class ConnectedFrame : Frame
	{
		public ConnectedFrame (string body, Dictionary<string, string> headers) : base(StompCommands.CONNECTED, body, headers)
		{
		}


		protected override void validate ()
		{
			base.validate ();

			if (!Headers.ContainsKey (StompHeaders.VERSION)) {
				throw new ArgumentException ("The MESSAGE frame has mulitple REQUIRED headers, destination and message-id.");
			}

			if (!string.IsNullOrEmpty (Body)) {
				throw new ArgumentException ("As per specification: Only the SEND, MESSAGE, and ERROR frames MAY have a body. All other frames MUST NOT have a body.");
			}
		}
	}
}

