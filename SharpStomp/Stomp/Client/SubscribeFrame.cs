using System;
using System.Collections.Generic;

namespace SharpStomp
{
	public class SubscribeFrame : Frame
	{
		public SubscribeFrame (string body, Dictionary<string, string> headers) : base(StompCommands.SUBSCRIBE, body, headers)
		{
		}

		protected override void validate ()
		{
			base.validate ();

			if (!Headers.ContainsKey (StompHeaders.ID)) {
				throw new ArgumentException ("The SUBSCRIBE frame has one REQUIRED header, id.");
			}

			if (!string.IsNullOrEmpty (Body)) {
				throw new ArgumentException ("As per specification: Only the SEND, MESSAGE, and ERROR frames MAY have a body. All other frames MUST NOT have a body.");
			}

		}
	}
}

