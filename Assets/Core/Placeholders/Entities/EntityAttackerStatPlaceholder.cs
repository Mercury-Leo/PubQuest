namespace Core.Placeholders.Entities {
    public class EntityAttackerStatPlaceholder : EntityStatPlaceholder {
        #region Properties

        public float Attack { get; set; }

        public float AttackSpeed { get; set; }

        #endregion

        #region Constructor

        public EntityAttackerStatPlaceholder(float health, float speed, float defense, float attack, float attackSpeed)
            : base(health, speed, defense) {
            Attack = attack;
            AttackSpeed = attackSpeed;
        }

        #endregion
    }
}