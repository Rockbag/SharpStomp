using System;
using System.Collections.Generic;

namespace SharpStomp
{
	public class AckFrame : Frame
	{
		public AckFrame (string body, Dictionary<string, string> headers) : base(StompCommands.ACK, body, headers)
		{
		}

		protected override void validate ()
		{
			base.validate ();
			if (!Headers.ContainsKey (StompHeaders.ID)) {
				throw new ArgumentException ("The ACK frame has one REQUIRED header, id.");
			}
		}
	}
}

