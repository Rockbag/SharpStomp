using System;
using System.Collections.Generic;


namespace UnityStomp.Client
{
	public class UnsubscribeFrame : Frame
	{
		public UnsubscribeFrame (string body, Dictionary<string, string> headers) : base(ClientFrames.UNSUBSCRIBE, body, headers)
		{
		}

		protected override void validate ()
		{
			base.validate ();
			if (!headers.ContainsKey (Headers.ID)) {
				throw new ArgumentException ("The UNSUBSCRIBE frame has one REQUIRED header, id.");
			}		
		}
	}
}

