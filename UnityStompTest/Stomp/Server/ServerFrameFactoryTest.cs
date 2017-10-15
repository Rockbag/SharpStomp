using System;
using NUnit.Framework;
using UnityStomp.Server;
using UnityStomp;
using System.Collections.Generic;

namespace UnityStompTest
{
	[TestFixture(TestName = "ServerFrameFactoryTests")]
	public class ServerFrameFactoryTest
	{
		private const String EXAMPLE_MESSAGE = 
@"MESSAGE
subscription:0
message-id:007
destination:/queue/a
content-type:text/plain
server-defined-header:hello
ack:client

hello queue a";

		private const String EXAMPLE_RECEIPT = 
@"RECEIPT
receipt-id:message-12345";

		private const String EXAMPLE_ERROR = 
@"ERROR
receipt-id:message-12345
content-type:text/plain
content-length:171
message: malformed frame received

The message:
-----
MESSAGE
destined:/queue/a
receipt:message-12345

Hello queue a!
-----
Did not contain a destination header, which is REQUIRED
for message propagation.";


		
		[Test()]
		public void TestMessageFrameParsing() {
			Frame message = ServerFrameFactory.CreateFromMessage (EXAMPLE_MESSAGE);

			Assert.AreEqual (StompCommands.MESSAGE, message.Command);
			StringAssert.AreEqualIgnoringCase ("0", message.Headers ["subscription"]);
			StringAssert.AreEqualIgnoringCase ("007", message.Headers ["message-id"]);
			StringAssert.AreEqualIgnoringCase ("/queue/a", message.Headers ["destination"]);
			StringAssert.AreEqualIgnoringCase ("text/plain", message.Headers ["content-type"]);
			StringAssert.AreEqualIgnoringCase ("hello",message.Headers ["server-defined-header"]);
			StringAssert.AreEqualIgnoringCase ("client", message.Headers ["ack"]);
			StringAssert.AreEqualIgnoringCase ("hello queue a", message.Body);
		}

		[Test()]
		public void TestReceiptFrameParsing() {
			Frame receipt = ServerFrameFactory.CreateFromMessage (EXAMPLE_RECEIPT);

			Assert.AreEqual (StompCommands.RECEIPT, receipt.Command);
			StringAssert.AreEqualIgnoringCase ("message-12345", receipt.Headers ["receipt-id"]);

		}

		[Test()]
		public void TestErrorFrameParsing() {
			Frame error = ServerFrameFactory.CreateFromMessage (EXAMPLE_ERROR);

			Assert.AreEqual (StompCommands.ERROR, error.Command);
			StringAssert.AreEqualIgnoringCase ("message-12345", error.Headers ["receipt-id"]);
			StringAssert.AreEqualIgnoringCase ("text/plain", error.Headers ["content-type"]);
			StringAssert.AreEqualIgnoringCase ("171",error.Headers ["content-length"]);
			StringAssert.AreEqualIgnoringCase ("malformed frame received", error.Headers ["message"]);
			StringAssert.AreEqualIgnoringCase ("The message:\n-----\nMESSAGE\ndestined:/queue/a\nreceipt:message-12345\n\nHello queue a!\n-----\nDid not contain a destination header, which is REQUIRED\nfor message propagation.", error.Body);
		}
	}
}

