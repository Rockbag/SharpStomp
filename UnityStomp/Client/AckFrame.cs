using System;
using System.Collections.Generic;

namespace UnityStomp.Client
{
	public class AckFrame : Frame
	{
		public AckFrame (string body, Dictionary<string, string> headers) : base(ClientFrames.ACK, body, headers)
		{
		}

		protected override void validate ()
		{
			base.validate ();
			if (!headers.ContainsKey (Headers.ID)) {
				throw new ArgumentException ("The ACK frame has one REQUIRED header, id.");
			}
		}
	}
}

