using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Documents;
using DDOLogAnalyzer.Models;

namespace DDOLogAnalyzer.Helpers
{
    class FileLoader
    {
        private static string _filePath;

        public FileLoader(string filePath)
        {
            _filePath = filePath;
        }

        public List<CombatMessage> DoIt()
        {
            List<CombatMessage> myChatMessages = new List<CombatMessage>();

            string[] dataStrings = File.ReadAllLines(_filePath);

            foreach (string entry in dataStrings)
            {
                string[] tokenStrings = entry.Split(' ');
                string[] messageStrings = entry.Split(':');
                ChatMessage logEntry = new ChatMessage();
                logEntry.timestamp = Convert.ToDateTime(tokenStrings[1]);
                StringBuilder builder = new StringBuilder();
                builder.AppendLine(messageStrings[3]);
                builder.AppendLine(": ");
                builder.AppendLine(messageStrings[4]);
                logEntry.message = builder.ToString();
                EnglishParser parser = new EnglishParser();
                ChatMessage parsedChatMessage = parser.Parse(logEntry);
                if (parsedChatMessage is CombatMessage)
                {
                    myChatMessages.Add(parsedChatMessage as CombatMessage);
                }

                Debug.WriteLine("{0}: {1}",
                  logEntry.timestamp.TimeOfDay, logEntry.message);
            }
            return myChatMessages;
        }

    }
}
