
namespace DDOLogAnalyzer.Models
{
    public enum CombatLogType : int
    {
        /// <summary>
        /// The type is unkown.
        /// </summary>
        Unknown = 0,
        /// <summary>
        /// The player has caused damage to a mob.
        /// </summary>
        DamageDone,
        /// <summary>
        /// A mob has caused damage to the player.
        /// </summary>
        DamageTaken,
        /// <summary>
        /// A mob has been killed.
        /// </summary>
        TargetKilled,
    }

    class CombatMessage : ChatMessage
    {
        private string target = "";
        private CombatLogType type = CombatLogType.Unknown;
        private Damage damage = new Damage();

        public CombatLogType CombatType
        {
            get { return type; }
            set { type = value; }
        }

        public CombatMessage(string type, string text)
            : base(type, text)
        {
        }

        public CombatMessage(ChatMessage msg)
            : base(msg)
        {
        }

        /// <summary>
        /// The actual damage inflicted or taken.
        /// </summary>
        public Damage Damage
        {
            get { return damage; }
            set
            {
                damage = value;
                if (!string.IsNullOrEmpty(value.Target))
                {
                    target = value.Target;
                }
            }
        }
        /// <summary>
        /// The target of the combat log message. Either the monster you killed or damaged.
        /// </summary>
        public string Target
        {
            get { return target; }
            set { target = value; }
        }
    }
}
