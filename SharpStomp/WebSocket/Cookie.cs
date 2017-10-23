using System;

namespace SharpStomp.Websocket
{
	public class Cookie
	{
		public WebSocketSharp.Net.Cookie cookie { get; private set; }
		public Cookie (string key, string value)
		{
			this.cookie = new WebSocketSharp.Net.Cookie (key, value);
		}
	}
}

