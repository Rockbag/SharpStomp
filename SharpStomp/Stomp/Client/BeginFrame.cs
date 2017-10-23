using System;
using System.Collections.Generic;

namespace SharpStomp
{
	public class BeginFrame : Frame
	{
		public BeginFrame (string body, Dictionary<string, string> headers) : base(StompCommands.BEGIN, body, headers)
		{
		}

		protected override void validate ()
		{
			base.validate ();

			if (!string.IsNullOrEmpty (Body)) {
				throw new ArgumentException ("As per specification: Only the SEND, MESSAGE, and ERROR frames MAY have a body. All other frames MUST NOT have a body.");
			}

			if (!Headers.ContainsKey (StompHeaders.TRANSACTION)) {
				throw new ArgumentException ("The BEGIN frame has one REQUIRED header, transaction.");
			}

		}
	}
}

