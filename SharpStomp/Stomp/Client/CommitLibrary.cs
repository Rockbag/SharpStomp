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

			if (!Headers.ContainsKey (StompHeaders.TRANSACTION)) {
				throw new ArgumentException ("The COMMIT frame has one REQUIRED header, transaction.");
			}
		}
	}
}

