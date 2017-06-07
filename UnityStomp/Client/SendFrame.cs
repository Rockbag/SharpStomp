using System;
using System.Collections.Generic;

namespace UnityStomp.Client
{
	public class SendFrame : Frame
	{

		public SendFrame (string body, Dictionary<string, string> headers) : base(ClientFrames.SEND, body, headers)
		{
		}

		protected override void validate ()
		{
			base.validate ();

			if (!string.IsNullOrEmpty(body)) {
				throw new ArgumentException ("As per specification: Only the SEND, MESSAGE, and ERROR frames MAY have a body. All other frames MUST NOT have a body.");
			}

			if (!headers.ContainsKey (Headers.DESTINATION)) {
				throw new ArgumentException ("The SEND frame has REQUIRED header, destination.");
			}

			if (!headers.ContainsKey (Headers.ID)) {
				throw new ArgumentException ("The SEND frame has REQUIRED header, id.");
			}

		}
	}
}

