using System;
using System.Collections.Generic;
using System.Text;

namespace UnityStomp.Client
{
	public class Frame
	{
		private ClientFrames command;
		protected Dictionary<string, string> headers;
		protected string body;

        public Frame(ClientFrames frameCommand, string body, Dictionary<string, string> headers = null)
        {
            this.command = frameCommand;
            this.body = body;

            if (headers == null)
            {
                this.headers = new Dictionary<string, string>();
            } else
            {
                this.headers = headers;
            }

			this.validate ();
		}

		protected virtual void validate() {

            if ((body != null && body.Contains ("\0")) && headers.ContainsKey (Headers.CONTENT_LENGTH)) {
				throw new ArgumentException ("As per specification:  If the frame body contains NULL octets, the frame MUST include a content-length header.");
			}

		}

		public string AsMessage() {
			string commandAsString = utf8Encode (command.ToString() + "\r\n");
            body = body ?? "";
			return string.Format ("{0}{1}{2}\0", commandAsString.ToString().ToUpper(), assembleHeaders (), body);
		}

		private string assembleHeaders() {
			if (headers == null) {
				return string.Empty;
			}

			string stringifiedHeaders = string.Empty;

			foreach (KeyValuePair<string, string> entry in headers) {
				stringifiedHeaders += string.Format ("{0}:{1}\r\n", entry.Key, entry.Value);
			}

			stringifiedHeaders += "\n";
				
			return utf8Encode (stringifiedHeaders);
		}

		private String utf8Encode(String stringToEncode) {
			byte[] headersToEncode = Encoding.Default.GetBytes (stringToEncode);
			return Encoding.Default.GetString(headersToEncode);
		}
	}
}

