using System;
using System.Text;
using DDOLogAnalyzer.Helpers;

namespace DDOLogAnalyzer.Models
{
    public enum MessageType : int
    {
        /// <summary>
        /// Unknown
        /// </summary>
        Unknown = 0,

        /// <summary>
        /// Combat message.
        /// </summary>
        Combat,

        /// <summary>
        /// Standard message.
        /// </summary>
        Standard,

        /// <summary>
        /// Advancement message.
        /// </summary>
        Advancement
    }

    public enum ChatMessageState : int
    {
        /// <summary>
        /// The type is unknown.
        /// </summary>
        Unknown = 0,
        /// <summary>
        /// The message was successfully parsed.
        /// </summary>
        Parsed,
        /// <summary>
        /// The message was recognized, but failed to parse properly.
        /// </summary>
        ParsingError
    }

    public class ChatMessage : NotificationObject
    {
       private string type = "";
       public DateTime timestamp { get; set; }
       public string message { get; set; }
       private ChatMessageState state = ChatMessageState.Unknown;
       private StringBuilder b = new StringBuilder();
       private StringBuilder orig = new StringBuilder();

       public ChatMessageState State
       {
           get { return state; }
           set { state = value; }
       }

        public ChatMessage()
        {
            
        }

        public virtual MessageType MessageType
        {
            get { return MessageType.Unknown; }
        }

       public ChatMessage(string type, string text)
       {
           this.message = text;
           this.type = type;          
           timestamp = DateTime.Now;
       }

       public ChatMessage(ChatMessage msg)
       {
     
           this.type = msg.type;
           this.message = msg.message;
           this.timestamp = msg.timestamp;
           this.state = msg.state;
           this.orig = msg.orig;
           this.b = msg.b;
       }
       
        public bool IsCombat
       {
           get { return MessageType == MessageType.Combat; }
       }
    }
}
