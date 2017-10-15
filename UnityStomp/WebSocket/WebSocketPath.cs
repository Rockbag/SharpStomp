using System;

namespace UnityStomp
{
	public class WebSocketPath
	{

		public string Protocol { get; private set; }
		public string Host { get; private set; }
		public int Port { get; private set; }
		public string AdditionalPath { get; private set; }

		public WebSocketPath (string protocol, string host, int port, string additionalPath)
		{
			this.Protocol = protocol;
			this.Host = host;
			this.Port = port;
			this.AdditionalPath = additionalPath;
		}

		public String AsConnectionString() {
			return string.Format("{0}://{1}:{2}/{3}", this.Protocol, this.Host, this.Port.ToString(), this.AdditionalPath);
		}
	}
}

