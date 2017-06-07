using System;
using System.Collections.Generic;

namespace UnityStomp.Client
{
	public class NackFrame : Frame
	{
		public NackFrame (string body, Dictionary<string, string> headers) : base(ClientFrames.NACK, body, headers) 
		{
		}

		protected override void validate ()
		{
			base.validate ();

			if (!headers.ContainsKey (Headers.ID)) {
				throw new ArgumentException ("The NACK frame has one REQUIRED header, id.");
			}

		}
	}
}

