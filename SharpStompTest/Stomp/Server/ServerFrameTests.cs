using System;
using NUnit.Framework;
using SharpStomp;
using System.Collections.Generic;

namespace SharpStompTest
{
	[TestFixture(TestName = "Server frame validation tests")]
	public class ServerFrameTests
	{
		[Test()]
		public void MalformedReceiptFrame() {
			Assert.Throws<ArgumentException> (() => new ReceiptFrame ("", new Dictionary<string, string>()));
		}

		[Test()]
		public void MalformedMessageFrame() {
			Assert.Throws<ArgumentException> (() => new MessageFrame ("", new Dictionary<string, string>()));
		}
	}
}

