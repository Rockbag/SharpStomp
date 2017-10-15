using System;
using NUnit.Framework;
using UnityStomp;
using System.Collections.Generic;
using SuperSocket.ClientEngine;
using WebSocket4Net;

namespace UnityStompTest
{
	public class WebSocketClientTest
	{

		UnityStompClient client;

		public void TestConnection() {
			//SESSION	deb29b8e-4abf-4470-8599-cc5516c2a575
			WebSocketPath path = new WebSocketPath("ws", "localhost", 8080, "api/sentinel/websocket");
			List<KeyValuePair<string, string>> cookies = new List<KeyValuePair<string,string>> ();
			cookies.Add(new KeyValuePair<string, string>("SESSION", "deb29b8e-4abf-4470-8599-cc5516c2a575"));
			client = new UnityStompClient(path, cookies);
			client.OnOpen = new EventHandler(onConnected);
			client.OnClose = new EventHandler(onClosed);
			client.OnError = new EventHandler<ErrorEventArgs>(onError);
			client.OnMessageReceived = new EventHandler<MessageReceivedEventArgs>(onMessageReceived);
			client.Open ();
		}


		private void onConnected(object sender, EventArgs e) {
			string body = "hello world";
			Dictionary<string, string> headers = new Dictionary<string, string> ();
			headers.Add (StompHeaders.ACCEPT_VERSION, "1.2");
			headers.Add (StompHeaders.HOST, "localhost");

			Frame stompFrame = new StompFrame (body, headers);
			client.Send (stompFrame);
		}

		private void onClosed(object sender, EventArgs e) {
		}

		private void onError(object sender, EventArgs e) {

		}

		private void onMessageReceived(object sender, EventArgs e) {

		}
	}
}

