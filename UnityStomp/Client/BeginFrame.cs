using System;
using System.Collections.Generic;

namespace UnityStomp.Client
{
	public class BeginFrame : Frame
	{
		public BeginFrame (string body, Dictionary<string, string> headers) : base(ClientFrames.BEGIN, body, headers)
		{
		}

		protected override void validate ()
		{
			base.validate ();

			if (!headers.ContainsKey (Headers.TRANSACTION)) {
				throw new ArgumentException ("The BEGIN frame has one REQUIRED header, transaction.");
			}

		}
	}
}

