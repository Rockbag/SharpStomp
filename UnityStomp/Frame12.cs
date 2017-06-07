using System;
using System.Collections.Generic;

namespace UnityStomp
{
	public class Frame12 : Frame
	{
		public Frame12 (ClientFrames frameCommand, string body, Dictionary<string, string> headers = null) : base(frameCommand, body, headers)
		{
			if (frameCommand == ClientFrames.STOMP && !headers.ContainsKey (Headers.ACCEPT_VERSION)) {
				throw ArgumentException ("As per specification: STOMP 1.2 clients MUST set the accept-version header");
			}

			if (!headers.ContainsKey (Headers.HOST)) {
				throw ArgumentException ("As per specification: STOMP 1.2 clients MUST set the host header");
			}
		}
			
	}
}

