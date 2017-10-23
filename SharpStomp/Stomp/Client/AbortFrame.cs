using System;
using System.Collections.Generic;

namespace SharpStomp
{
	public class AbortFrame : Frame
	{
		public AbortFrame (string body, Dictionary<string, string> headers) : base(StompCommands.ABORT, body, headers) 
		{
		}

		protected override void validate ()
		{
			base.validate ();

			if (!Headers.ContainsKey (StompHeaders.TRANSACTION)) {
				throw new ArgumentException ("The ABORT frame has one REQUIRED header, transaction.");
			}
		}
	}
}

