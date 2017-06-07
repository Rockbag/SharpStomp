using System;
using System.Collections.Generic;

namespace UnityStomp.Client
{
	public class SubscribeFrame : Frame
	{
		public SubscribeFrame (string body, Dictionary<string, string> headers) : base(ClientFrames.SUBSCRIBE, body, headers)
		{
		}

		protected override void validate ()
		{
			if (!headers.ContainsKey (Headers.ID)) {
				throw new ArgumentException ("The SUBSCRIBE frame has one REQUIRED header, id.");
			}
			base.validate ();
		}
	}
}

