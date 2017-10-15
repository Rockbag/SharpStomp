using System;
using System.Collections.Generic;

namespace UnityStomp
{
	public class SendFrame : Frame
	{

		public SendFrame (string body, Dictionary<string, string> headers) : base(StompCommands.SEND, body, headers)
		{
		}

		protected override void validate ()
		{
			base.validate ();

			if (!string.IsNullOrEmpty(Body)) {
				throw new ArgumentException ("As per specification: Only the SEND, MESSAGE, and ERROR frames MAY have a body. All other frames MUST NOT have a body.");
			}

			if (!Headers.ContainsKey (StompHeaders.DESTINATION)) {
				throw new ArgumentException ("The SEND frame has REQUIRED header, destination.");
			}

			if (!Headers.ContainsKey (StompHeaders.ID)) {
				throw new ArgumentException ("The SEND frame has REQUIRED header, id.");
			}

		}
	}
}

