using System;
using System.Collections.Generic;
using SharpStomp;
using WebSocketSharp;
using WebSocketSharp.Net;

namespace SharpStomp
{
	public class StompClient
	{
		private WebSocket socket;

		public event EventHandler OnOpen {
			add { socket.OnOpen += value; }
			remove { socket.OnOpen -= value; }
		}

		public event EventHandler<CloseEventArgs> OnClose {
			add { socket.OnClose += value; }
			remove { socket.OnClose -= value; }
		}

		public event EventHandler<StompEventArgs> OnMessage {
			add { onStompMessage += value; }
			remove { onStompMessage -= value; }
		}

		public event EventHandler<ErrorEventArgs> OnError {
			add { socket.OnError += value; }
			remove { socket.OnError -= value; }
		}
			
		private event EventHandler<StompEventArgs> onStompMessage;

		public static StompClient Over (WebSocketPath path, List<SharpStomp.Websocket.Cookie> cookies)
		{
			return new StompClient (path, cookies);
		}

		private StompClient(WebSocketPath path, List<SharpStomp.Websocket.Cookie> cookies) {
			socket = new WebSocket (path.AsConnectionString());
			foreach (SharpStomp.Websocket.Cookie cookie in cookies) {
				socket.SetCookie (cookie.cookie);
			}
			socket.OnMessage += onMessage;
		}

		~StompClient() {
			socket.OnMessage -= onMessage;
		}

		public void Open() {
			socket.Connect ();
		}

		public void Close() {
			socket.Close ();
		}

		public void Send(Frame frame) {
			socket.Send (frame.AsStompMessage ());
		}

		public Frame FromMessage(MessageEventArgs args) {
			return ServerFrameFactory.CreateFromMessage (args.Data);
		}

		private void onMessage(object sender, MessageEventArgs args) {
			if (onStompMessage != null) {;
				onStompMessage (sender, new StompEventArgs (args));	
			}
		}
	}
}

