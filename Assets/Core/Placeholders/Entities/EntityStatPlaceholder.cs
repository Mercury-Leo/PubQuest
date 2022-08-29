using System;

namespace Core.Placeholders.Entities {
    [Serializable]
    public class EntityStatPlaceholder : IEquatable<EntityStatPlaceholder> {
        #region Properties

        public float Health { get; set; }

        public float Speed { get; set; }

        public float Defense { get; set; }

        #endregion

        #region Constructor

        public EntityStatPlaceholder(float health, float speed, float defense) {
            Health = health;
            Speed = speed;
            Defense = defense;
        }

        #endregion

        public bool Equals(EntityStatPlaceholder other) {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Health.Equals(other.Health) && Speed.Equals(other.Speed) && Defense.Equals(other.Defense);
        }

        public override bool Equals(object obj) {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((EntityStatPlaceholder)obj);
        }

        public override int GetHashCode() {
            return HashCode.Combine(Health, Speed, Defense);
        }
    }
}