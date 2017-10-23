using System;
using System.Collections.Generic;
using System.Text;
using SharpStomp;

namespace SharpStomp
{
	public class Frame
	{
		public StompCommands Command { get; private set; }
		public Dictionary<string, string> Headers { get; protected set; }
		public string Body { get; protected set; }

        public Frame(StompCommands frameCommand, string body, Dictionary<string, string> headers = null)
        {
            this.Command = frameCommand;
            this.Body = body;

            if (headers == null)
            {
                this.Headers = new Dictionary<string, string>();
            } else
            {
                this.Headers = headers;
            }

			this.validate ();
		}

		protected virtual void validate() {

            if ((Body != null && Body.Contains ("\0")) && Headers.ContainsKey (StompHeaders.CONTENT_LENGTH)) {
				throw new ArgumentException ("As per specification:  If the frame body contains NULL octets, the frame MUST include a content-length header.");
			}

		}

		public string AsStompMessage() {
			string commandAsString = utf8Encode (Command.ToString() + "\r\n");
			Body = Body ?? "";
			return string.Format ("{0}{1}{2}\0", commandAsString.ToString().ToUpper(), assembleHeaders (), utf8Encode(Body));
		}

		private string assembleHeaders() {
			if (Headers == null) {
				return string.Empty;
			}

			string stringifiedHeaders = string.Empty;

			foreach (KeyValuePair<string, string> entry in Headers) {
				stringifiedHeaders += string.Format ("{0}:{1}\r\n", entry.Key, entry.Value);
			}

			stringifiedHeaders += "\n";
				
			return utf8Encode (stringifiedHeaders);
		}

		private String utf8Encode(String stringToEncode) {
			byte[] headersToEncode = Encoding.UTF8.GetBytes (stringToEncode);
			return Encoding.UTF8.GetString(headersToEncode);
		}
	}
}

