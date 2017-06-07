using System;
using System.Collections.Generic;

namespace UnityStomp.Client
{
	public class CommitLibrary : Frame
	{
		public CommitLibrary (string body, Dictionary<string, string> headers) : base(ClientFrames.COMMIT, body, headers)
		{
		}

		protected override void validate ()
		{
			base.validate ();

			if (!headers.ContainsKey (Headers.TRANSACTION)) {
				throw new ArgumentException ("The COMMIT frame has one REQUIRED header, transaction.");
			}
		}
	}
}

