using System;
using WebSocketSharp;
using SharpStomp;

namespace SharpStomp
{
	public class StompEventArgs : EventArgs
	{
		public string Data {
			get;
			private set;
		}

		public bool IsBinary {
			get;
			private set;
		}

		public bool IsPing {
			get;
			private set;
		}

		public bool IsText {
			get;
			private set;
		}

		public byte[] RawData {
			get;
			private set;
		}

		public Frame StompFrame {
			get;
			private set;
		}

		public StompEventArgs (MessageEventArgs args)
		{
			this.Data = args.Data;
			this.IsBinary = args.IsBinary;
			this.IsPing = args.IsPing;
			this.IsText = args.IsText;
			this.RawData = args.RawData;
			this.StompFrame = ServerFrameFactory.CreateFromMessage (args.Data);
		}
	}
}

