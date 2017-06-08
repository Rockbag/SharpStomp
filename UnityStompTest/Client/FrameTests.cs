using NUnit.Framework;
using System;
using UnityStomp.Client;
using UnityStomp;
using System.Collections.Generic;

namespace UnityStompTest
{
	[TestFixture ()]
	public class FrameTests
	{

        private static string MESSAGE_TEMPLATE = "{0}\r\n{1}\r\n\n{2}";

		[Test ()]
		public void TestAbortFrameEmptyBody ()
		{
			Dictionary<string, string> headers = new Dictionary<string, string> ();
			headers.Add (Headers.TRANSACTION, "transactionId");

            //test for null body
			new AbortFrame (null, headers);
            //test for empty body
            new AbortFrame("", headers);

		}

		[Test()]
		public void TestAbortFrameWithBody() 
		{
            Dictionary<string, string> headers = new Dictionary<string, string>();
            headers.Add(Headers.TRANSACTION, "transactionId");

            AbortFrame abortFrame = new AbortFrame("some body", headers);
            StringAssert.AreEqualIgnoringCase(abortFrame.AsMessage(),
                string.Format(MESSAGE_TEMPLATE,
                    "ABORT",
                    "transaction:transactionId",
                    "some body\0"));
        }

		[Test()]
		public void TestAbortFrameBodyAndMissingTransactionHeader() 
		{
            Assert.Throws<ArgumentException>(() => new AbortFrame("", null));
            Assert.Throws<ArgumentException>(() => new AbortFrame("whatever body it is", null));
        }

        [Test(Description = "Checks if an Ack frame can be created with an empty/null body")]
        public void TestAckFrameEmptyBody()
        {
            Dictionary<string, string> headers = new Dictionary<string, string>();
            headers.Add(Headers.ID, "id");

            //test for null body
            new AckFrame(null, headers);
            //test for empty body
            new AckFrame("", headers);
        }

        [Test(Description = "Checks that an Ack Frame is correctly serialiyed into a message")]
        public void TestAckFrameWithBody()
        {
            Dictionary<string, string> headers = new Dictionary<string, string>();
            headers.Add(Headers.ID, "id");

            AckFrame abortFrame = new AckFrame("some body", headers);
            StringAssert.AreEqualIgnoringCase(abortFrame.AsMessage(),
                string.Format(MESSAGE_TEMPLATE,
                    "ACK",
                    "id:id",
                    "some body\0"));
        }

        [Test(Description = "Checks validation logic for Ack frame")]
        public void TestAckFrameBodyAndMissingIdHeader()
        {
            Assert.Throws<ArgumentException>(() => new AckFrame(null, null));
            Assert.Throws<ArgumentException>(() => new AckFrame("whatever body it is", null));
        }


	}
}

