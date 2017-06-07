using System;
using System.Collections.Generic;

namespace UnityStomp.Client
{
	public class AbortFrame : Frame
	{
		public AbortFrame (string body, Dictionary<string, string> headers) : base(ClientFrames.ABORT, body, headers) 
		{
		}

		protected override void validate ()
		{
			base.validate ();

			if (!headers.ContainsKey (Headers.TRANSACTION)) {
				throw new ArgumentException ("The ABORT frame has one REQUIRED header, transaction.");
			}
		}
	}
}

