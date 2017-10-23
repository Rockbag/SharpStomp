using System;
using System.Collections.Generic;

namespace SharpStomp
{
	public class CommitLibrary : Frame
	{
		public CommitLibrary (string body, Dictionary<string, string> headers) : base(StompCommands.COMMIT, body, headers)
		{
		}

		protected override void validate ()
		{
			base.validate ();
			if (!string.IsNullOrEmpty (Body)) {
				throw new ArgumentException ("As per specification: Only the SEND, MESSAGE, and ERROR frames MAY have a body. All other frames MUST NOT have a body.");
			}

			if (!Headers.ContainsKey (StompHeaders.TRANSACTION)) {
				throw new ArgumentException ("The COMMIT frame has one REQUIRED header, transaction.");
			}
		}
	}
}

