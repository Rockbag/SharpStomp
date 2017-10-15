using System;
using WebSocket4Net;
using System.Collections.Generic;
using UnityStomp;
using SuperSocket.ClientEngine;

namespace UnityStomp
{
	public class UnityStompClient
	{
		private WebSocket connection;

		public EventHandler OnOpen { set { connection.Opened += value; } }
		public EventHandler OnClose { set { connection.Closed += value; } }
		public EventHandler<ErrorEventArgs> OnError {  set { connection.Error += value; }}
		public EventHandler<MessageReceivedEventArgs> OnMessageReceived { set { connection.MessageReceived += value; } }

		public UnityStompClient (WebSocketPath path, List<KeyValuePair<string, string>> cookies)
		{
			connection = new WebSocket (path.AsConnectionString(), cookies);
		}

		public void Open() {
			connection.Open ();
		}

		public void Send(Frame frame) {
			connection.Send (frame.AsStompMessage ());
		}
	}
}

