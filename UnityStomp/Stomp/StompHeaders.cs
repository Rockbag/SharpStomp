using System;

namespace UnityStomp
{
	public class StompHeaders
	{
		public static string CONTENT_LENGTH = "content-length";
		public static string CONTENT_TYPE = "content-type";
		public static string RECEIPT = "receipt";
		public static string RECEIPT_ID = "receipt-id";
		public static string DESTINATION = "destination";
		public static string TRANSACTION = "transaction";
		public static string ID = "id";
		public static string ACK = "ack";
		public static string MESSAGE_ID = "message-id";
		public static string SUBSCRIPTION = "subscription";

		//Stomp v1.2
		public static string ACCEPT_VERSION = "accept-version";
		public static string HOST = "host";
		public static string LOGIN = "login";
		public static string PASSWORD = "passcode";
		public static string HEARTBEAT = "heart-beat";
		public static string VERSION = "version";
	}
}

