using System;
using System.Collections.Generic;

namespace SharpStomp
{
	public class SendFrame : Frame
	{

		public SendFrame (string body, Dictionary<string, string> headers) : base(StompCommands.SEND, body, headers)
		{
		}

		protected override void validate ()
		{
			base.validate ();

			if (!Headers.ContainsKey (StompHeaders.DESTINATION)) {
				throw new ArgumentException ("The SEND frame has REQUIRED header, destination.");
			}

			if (!Headers.ContainsKey (StompHeaders.ID)) {
				throw new ArgumentException ("The SEND frame has REQUIRED header, id.");
			}

		}
	}
}

