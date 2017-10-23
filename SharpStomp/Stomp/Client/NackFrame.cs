using System;
using System.Collections.Generic;

namespace SharpStomp
{
	public class NackFrame : Frame
	{
		public NackFrame (string body, Dictionary<string, string> headers) : base(StompCommands.NACK, body, headers) 
		{
		}

		protected override void validate ()
		{
			base.validate ();

			if (!Headers.ContainsKey (StompHeaders.ID)) {
				throw new ArgumentException ("The NACK frame has one REQUIRED header, id.");
			}

		}
	}
}

