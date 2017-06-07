using System;
using System.Collections.Generic;

namespace UnityStomp.Client
{
	public class ConnectFrame : Frame
	{

		public ConnectFrame (string body, Dictionary<string, string> headers) : base(ClientFrames.CONNECT, body, headers)
		{
		}

		protected override void validate ()
		{
			base.validate ();
			if (!headers.ContainsKey (Headers.ACCEPT_VERSION)) {
				throw new ArgumentException ("As per specification: Connect frames MUST set the accept-version header");
			}

			if (!headers.ContainsKey (Headers.HOST)) {
				throw new ArgumentException ("As per specification: Connect frames MUST set the host header");
			}

			if (headers.ContainsKey(Headers.RECEPIT)) {
				throw new ArgumentException ("Any client frame other than CONNECT MAY specify a receipt header with an arbitrary value.");
			}	
		}
	}
}

