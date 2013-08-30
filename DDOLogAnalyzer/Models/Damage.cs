
namespace DDOLogAnalyzer.Models
{
    public enum DamageType : int
    {
        /// <summary>
        /// The damage type is unknown to the application. This is not the same
        /// as "Unknown" or "Untyped" as the game sees it.
        /// </summary>
        Unknown = 0,
        Slashing,
        Piercing,
        Bludgeoning,
        Acid,
        Fire,
        Good,
        Cold,
        Shock,
        Chaotic,
        Sonic,
        Force,
        Evil,
        Lawful,
        /// <summary>
        /// As done by healing.
        /// </summary>
        Positive,
        /// <summary>
        /// As done by negative energy spells, like Harm or Inflict Critical Wounds.
        /// </summary>
        Negative
    }

    public class Damage
    {
        private uint points = 0;
        private uint blocked = 0;
        private string blockedby = "";
        private string source = "";
        private string sourceability = "";
        private string target = "";
        private string targetability = "";
        private DamageType type = DamageType.Unknown;
        public static readonly string Player = "player";

        public Damage()
        {
        }

        public Damage(uint points, uint blocked, string blockedby, string source, string target, DamageType type)
        {
            this.points = points;
            this.blocked = blocked;
            this.blockedby = blockedby;
            this.source = source;
            this.target = target;
            this.type = type;
        }

        /// <summary>
        /// Damage potential (i.e. points + blocked)
        /// </summary>
        public uint PotentialDamage
        {
            get
            {
                uint pot = points + blocked;
                return pot;
            }
        }

        /// <summary>
        /// Damage effectively done.
        /// </summary>
        public uint Points
        {
            get { return points; }
        }

        /// <summary>
        /// Number of points blocked.
        /// </summary>
        public uint Blocked
        {
            get { return blocked; }
        }

        /// <summary>
        /// What caused damage to be blocked, e.g. damage reduction.
        /// </summary>
        public string BlockedBy
        {
            get { return blockedby; }
        }

        /// <summary>
        /// Source of the damage.
        /// </summary>
        public string Source
        {
            get { return source; }
            set { source = value; }
        }

        /// <summary>
        /// Target of the damage.
        /// </summary>
        public string Target
        {
            get { return target; }
            set { target = value; }
        }

        /// <summary>
        /// Ability of the source that caused the damage.
        /// </summary>
        public string SourceAbility
        {
            get { return sourceability; }
            set { sourceability = value; }
        }

        /// <summary>
        /// Ability of the target that caused the damage.
        /// </summary>
        public string TargetAbility
        {
            get { return targetability; }
            set { targetability = value; }
        }

        public DamageType Type
        {
            get { return type; }
        }

        /// <summary>
        /// Adds two damage values together.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="d"></param>
        /// <returns></returns>
        public static Damage operator +(Damage a, Damage d)
        {
            a.points += d.points;
            a.blocked += d.blocked;

            return a;
        }
    }
}
