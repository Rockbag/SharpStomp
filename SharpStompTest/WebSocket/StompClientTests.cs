using System;
using NUnit.Framework;
using SharpStomp; 
using WebSocketSharp.Server;
using System.Collections.Generic;
using SharpStomp.Websocket;

namespace SharpStompTest
{
	[TestFixture(TestName = "Test case for WebSocket integration")]
	public class StompClientTests
	{
		private WebSocketServer server;
		private StompClient client;

		private bool messageArrived = false;
		private Frame message;

		[SetUp]
		public void SetUp() {
			server = new WebSocketServer (6601);
			server.AddWebSocketService<DummyEcho> ("/Test");
			server.Start ();
			messageArrived = false;
		}

		[TearDown]
		public void TearDown() {
			server.Stop ();
			client.OnMessage -= onMessage;
			messageArrived = true;
			message = null;
		}

		[Test]
		public void TestMessageHandlerIsWrappedCorrectl() {
			WebSocketPath path = new WebSocketPath ("ws", "localhost", 6601, "Test");
			List<Cookie> cookies = new List<Cookie> ();
			client = StompClient.Over (path, cookies);
			client.OnMessage += onMessage;
			Dictionary<string, string> headers = new Dictionary<string, string> ();
			headers.Add (StompHeaders.DESTINATION, "/test");
			headers.Add (StompHeaders.ID, "id");
			client.Open ();
			client.Send (new SendFrame ("Hello world", headers));

			while (!messageArrived) {
				// Wait for event to arrive, then quit.
			}

			Assert.AreEqual (StompCommands.MESSAGE, message.Command);
			StringAssert.AreEqualIgnoringCase ("Hello world\0", message.Body);
			StringAssert.AreEqualIgnoringCase ("/test", message.Headers [StompHeaders.DESTINATION]);
			StringAssert.AreEqualIgnoringCase ("1", message.Headers [StompHeaders.MESSAGE_ID]);
			client.Close ();
		}
			
		private void onMessage(object sender, StompEventArgs args) {
			this.message = args.StompFrame;
			messageArrived = true;
		}


		private class DummyEcho : WebSocketBehavior {

			protected override void OnMessage (WebSocketSharp.MessageEventArgs e)
			{
				Dictionary<string, string> headers = new Dictionary<string, string> ();
				headers.Add (StompHeaders.DESTINATION, "/test");
				headers.Add (StompHeaders.MESSAGE_ID, "1");
				MessageFrame frame = new MessageFrame ("Hello world", headers);
				Send (frame.AsStompMessage ()); 
			}
		}
	}
}

