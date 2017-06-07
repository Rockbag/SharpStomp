using System;

namespace UnityStomp.Client
{
	public enum ClientFrames
	{
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
		STOMP
	}
}

