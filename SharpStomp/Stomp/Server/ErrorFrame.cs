﻿using System;
using System.Collections.Generic;

namespace SharpStomp
{
	public class ErrorFrame : Frame
	{
		public ErrorFrame (string body, Dictionary<string, string> headers) : base(StompCommands.ERROR, body, headers)
		{
		}


		protected override void validate ()
		{
			base.validate ();
		}
	}
}

