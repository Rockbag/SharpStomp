using System;
using System.Collections.Generic;

namespace SharpStomp
{
	public class ReceiptFrame : Frame
	{
		public ReceiptFrame (string body, Dictionary<string, string> headers) : base(StompCommands.RECEIPT, body, headers)
		{
		}


		protected override void validate ()
		{
			base.validate ();
			if (!Headers.ContainsKey (StompHeaders.RECEIPT_ID)) {
				throw new ArgumentException ("The RECEIPT frame has one REQUIRED header, receipt-id.");
			}

			if (!string.IsNullOrEmpty (Body)) {
				throw new ArgumentException ("As per specification: Only the SEND, MESSAGE, and ERROR frames MAY have a body. All other frames MUST NOT have a body.");
			}
		}
	}
}

