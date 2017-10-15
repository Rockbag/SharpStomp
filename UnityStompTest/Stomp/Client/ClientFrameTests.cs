using NUnit.Framework;
using System;
using UnityStomp;
using System.Collections.Generic;

namespace UnityStompTest
{
	[TestFixture (TestName="ClientFrameTests")]
	public class ClientFrameTests
	{

        private static string MESSAGE_TEMPLATE = "{0}\r\n{1}\r\n\n{2}";

		[Test ()]
		public void TestAbortFrameEmptyBody ()
		{
			Dictionary<string, string> headers = new Dictionary<string, string> ();
			headers.Add (StompHeaders.TRANSACTION, "transactionId");

            //test for null body
			AbortFrame abortFrame = new AbortFrame (null, headers);
		
			StringAssert.AreEqualIgnoringCase(string.Format(MESSAGE_TEMPLATE,
					"ABORT",
					"transaction:transactionId",
					"\0"),
				abortFrame.AsStompMessage());
            //test for empty body
            AbortFrame abortFrameEmptyBody = new AbortFrame("", headers);

			StringAssert.AreEqualIgnoringCase(string.Format(MESSAGE_TEMPLATE,
					"ABORT",
					"transaction:transactionId",
					"\0"),
				abortFrameEmptyBody.AsStompMessage());

		}

		[Test()]
		public void TestAbortFrameWithBody() 
		{
            Dictionary<string, string> headers = new Dictionary<string, string>();
            headers.Add(StompHeaders.TRANSACTION, "transactionId");

            AbortFrame abortFrame = new AbortFrame("some body", headers);
            StringAssert.AreEqualIgnoringCase(string.Format(MESSAGE_TEMPLATE,
                    "ABORT",
                    "transaction:transactionId",
                    "some body\0"),
				abortFrame.AsStompMessage());
        }

		[Test()]
		public void TestAbortFrameBodyWithMissingTransactionHeader() 
		{
            Assert.Throws<ArgumentException>(() => new AbortFrame("", null));
            Assert.Throws<ArgumentException>(() => new AbortFrame("whatever body it is", null));
        }

        [Test(Description = "Checks if an Ack frame can be created with an empty/null body")]
        public void TestAckFrameEmptyBody()
        {
            Dictionary<string, string> headers = new Dictionary<string, string>();
            headers.Add(StompHeaders.ID, "id");

            //test for null body
            AckFrame ackFrame = new AckFrame(null, headers);
			StringAssert.AreEqualIgnoringCase(
				string.Format(MESSAGE_TEMPLATE,
					"ACK",
					"id:id",
					"\0"),
				ackFrame.AsStompMessage());

            //test for empty body
            AckFrame ackFrameEmptyBody = new AckFrame("", headers);
			StringAssert.AreEqualIgnoringCase(string.Format(MESSAGE_TEMPLATE,
					"ACK",
					"id:id",
					"\0"),
				ackFrameEmptyBody.AsStompMessage());
        }

        [Test(Description = "Checks that an Ack Frame is correctly serialiyed into a message")]
        public void TestAckFrameWithBody()
        {
            Dictionary<string, string> headers = new Dictionary<string, string>();
            headers.Add(StompHeaders.ID, "id");

            AckFrame ackFrame = new AckFrame("some body", headers);
            StringAssert.AreEqualIgnoringCase(string.Format(MESSAGE_TEMPLATE,
                    "ACK",
                    "id:id",
				"some body\0"),
				ackFrame.AsStompMessage());
        }

        [Test(Description = "Checks validation logic for Ack frame")]
        public void TestAckFrameBodyWithMissingIdHeader()
        {
            Assert.Throws<ArgumentException>(() => new AckFrame(null, null));
            Assert.Throws<ArgumentException>(() => new AckFrame("whatever body it is", null));
        }

		[Test()]
		public void TestBeginFrameEmptyBody() {

			Dictionary<string, string> headers = new Dictionary<string, string> ();
			headers.Add (StompHeaders.TRANSACTION, "transactionId");

			BeginFrame beginFrame = new BeginFrame ("", headers);
			StringAssert.AreEqualIgnoringCase(beginFrame.AsStompMessage(),
				string.Format(MESSAGE_TEMPLATE,
					"BEGIN",
					"transaction:transactionId",
					"\0"));

			BeginFrame beginFrameEmptyBody = new BeginFrame (null, headers);
			StringAssert.AreEqualIgnoringCase(string.Format(MESSAGE_TEMPLATE,
					"BEGIN",
					"transaction:transactionId",
					"\0"), 
				beginFrameEmptyBody.AsStompMessage());

		}

		[Test()]
		public void TestBeginFrameWithBody() {
			Dictionary<string, string> headers = new Dictionary<string, string> ();
			headers.Add (StompHeaders.TRANSACTION, "transactionId");

			BeginFrame beginFrame = new BeginFrame ("some body", headers);
			StringAssert.AreEqualIgnoringCase (string.Format (MESSAGE_TEMPLATE, 
					"BEGIN",
					"transaction:transactionId",
					"some body\0"), 
				beginFrame.AsStompMessage ());
		}

		[Test()]
		public void TestBeginFrameBodyWithMissingIdHeader() {
			Assert.Throws<ArgumentException> (() => new BeginFrame ("", null));
			Assert.Throws<ArgumentException> (() => new BeginFrame (null, null));
		}


	}
}

