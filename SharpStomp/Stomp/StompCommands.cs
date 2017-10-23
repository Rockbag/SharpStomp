using System;

namespace SharpStomp
{
	public enum StompCommands
	{
		//Client frames
		SEND,
		SUBSCRIBE,
		UNSUBSCRIBE,
		ACK,
		NACK,
		BEGIN,
		COMMIT,
		ABORT,
		CONNECT,
		DISCONNECT,
		STOMP,

		//Server frames
		MESSAGE, //Used to convey messages from subscriptions to the client
		RECEIPT, //Sent from the server to the client once a server has successfully processed a client frame that requests a receipt
		ERROR,  //Something goes wrong on the server
		CONNECTED //Server's response to the STOMP frame
	}
}

