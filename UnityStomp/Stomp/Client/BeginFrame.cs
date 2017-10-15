using System;
using System.Collections.Generic;

namespace UnityStomp
{
	public class BeginFrame : Frame
	{
		public BeginFrame (string body, Dictionary<string, string> headers) : base(StompCommands.BEGIN, body, headers)
		{
		}

		protected override void validate ()
		{
			base.validate ();

			if (!Headers.ContainsKey (StompHeaders.TRANSACTION)) {
				throw new ArgumentException ("The BEGIN frame has one REQUIRED header, transaction.");
			}

		}
	}
}

