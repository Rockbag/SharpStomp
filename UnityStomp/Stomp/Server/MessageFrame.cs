using System;
using System.Collections.Generic;

namespace UnityStomp
{
	public class MessageFrame : Frame
	{
		public MessageFrame (string body, Dictionary<string, string> headers) : base(StompCommands.MESSAGE, body, headers)
		{
		}


		protected override void validate ()
		{
			base.validate ();

			if (!Headers.ContainsKey (StompHeaders.DESTINATION) || !Headers.ContainsKey(StompHeaders.MESSAGE_ID)) {
				throw new ArgumentException ("The MESSAGE frame has mulitple REQUIRED headers, destination and message-id.");
			}

			//TODO as per specification - this would require some knowledge of state, so may not be best to have it here.
			/*If the message is received from a subscription that requires explicit acknowledgment
			 * (either client or client-individual mode) 
			 * then the MESSAGE frame MUST also contain an ack header with an arbitrary value.
			*/
		}
	}
}

