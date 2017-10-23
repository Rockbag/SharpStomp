using System;
using System.Collections.Generic;


namespace SharpStomp
{
	public class UnsubscribeFrame : Frame
	{
		public UnsubscribeFrame (string body, Dictionary<string, string> headers) : base(StompCommands.UNSUBSCRIBE, body, headers)
		{
		}

		protected override void validate ()
		{
			base.validate ();

			if (!Headers.ContainsKey (StompHeaders.ID)) {
				throw new ArgumentException ("The UNSUBSCRIBE frame has one REQUIRED header, id.");
			}		

			if (!string.IsNullOrEmpty (Body)) {
				throw new ArgumentException ("As per specification: Only the SEND, MESSAGE, and ERROR frames MAY have a body. All other frames MUST NOT have a body.");
			}
		}
	}
}

