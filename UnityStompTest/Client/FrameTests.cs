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
		[Test ()]
		public void TestAbortFrameEmptyBody ()
		{
			Dictionary<string, string> headers = new Dictionary<string, string> ();
			headers.Add (Headers.TRANSACTION, "transactionId");
			AbortFrame abortFrame = new AbortFrame (null, headers);
		}

		[Test()]
		public void TestAbortFrameWithBody() 
		{
		
		}

		[Test()]
		public void TestAbortFrameMissingTransactionHeader() 
		{
		}
	}
}

