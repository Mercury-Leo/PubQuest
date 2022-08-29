using System;

namespace Core.Placeholders.Entities {
    [Serializable]
    public class EntityStatPlaceholder {
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
    }
}