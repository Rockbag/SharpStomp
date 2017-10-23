using System;
using SharpStomp;
using System.Collections.Generic;

namespace SharpStomp
{
	public class ServerFrameFactory
	{
public static Frame CreateFromMessage(String message) {
			string[] lines = message.Split ('\n');

			StompCommands command = (StompCommands) Enum.Parse(typeof(StompCommands), lines[0]);
			Dictionary<string, string> headers = new Dictionary<string, string> ();

			int bodyLineCount = 1;
			bool hasBody = false;
			for (int i = 1; i < lines.Length; i++) {
				if (String.IsNullOrEmpty(lines[i])) { // blank line separates headers from body
					bodyLineCount++; // the next line after the empty one is the body.
					hasBody = true;
					break;
				}
				string[] header = lines[i].Split(':');
				headers.Add (header [0].Trim(), header [1].Trim()); 
				bodyLineCount++;
			}

			String body = null;
			if (hasBody) { //body is not obligatory for every frame type
				string[] bodyAsArray = new string[lines.Length - bodyLineCount]; //body can be multiline
				Array.Copy(lines, bodyLineCount, bodyAsArray, 0, lines.Length - bodyLineCount); 
				body = string.Join("\n", bodyAsArray);
			}
				
			switch (command) {
			case StompCommands.MESSAGE:
				return new MessageFrame (body, headers);
			case StompCommands.ERROR:
				return new ErrorFrame (body, headers);
			case StompCommands.RECEIPT:
				return new ReceiptFrame(body, headers);
			case StompCommands.CONNECTED:
				return new ConnectedFrame (body, headers);
			}
			
			return null;
		}
			
	}
}

