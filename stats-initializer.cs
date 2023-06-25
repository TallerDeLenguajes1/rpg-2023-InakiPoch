namespace Entity {
    public class Stats {
        public int SetSpeed(CharacterType type) {
            switch(type) {
                case CharacterType.Confessor: return 9;
                case CharacterType.Samurai: return 7;
                case CharacterType.Warrior: return 5;
                default: return 0;
            }
        }

        public int SetDexterity(CharacterType type) {
            switch(type) {
                case CharacterType.Confessor: return 1;
                case CharacterType.Samurai: return 5;
                case CharacterType.Warrior: return 3;
                default: return 0;
            }
        }

        public int SetStrength(CharacterType type) {
            switch(type) {
                case CharacterType.Confessor: return 5;
                case CharacterType.Samurai: return 7;
                case CharacterType.Warrior: return 10;
                default: return 0;
            }
        }

        public int SetArmor(CharacterType type) {
            switch(type) {
                case CharacterType.Confessor: return 4;
                case CharacterType.Samurai: return 9;
                case CharacterType.Warrior: return 7;
                default: return 0;
            }
        }

        public int DefineEnemyHealth(EnemyType type) {
            switch(type) {
                case EnemyType.Regular: return 10;
                case EnemyType.Special: return 15;
                case EnemyType.Rare: return 20;
                default: return 0;
            }
        }

        public int DefineEnemySpeed(EnemyType type) {
            switch(type) {
                case EnemyType.Regular: return 5;
                case EnemyType.Special: return 4;
                case EnemyType.Rare: return 3;
                default: return 0;
            }
        }

        public int DefineEnemyDex(EnemyType type) {
            switch(type) {
                case EnemyType.Regular: return 1;
                case EnemyType.Special: return 2;
                case EnemyType.Rare: return 3;
                default: return 0;
            }
        }

        public int DefineEnemyStrength(EnemyType type) {
            switch(type) {
                case EnemyType.Regular: return 4;
                case EnemyType.Special: return 6;
                case EnemyType.Rare: return 9;
                default: return 0;
            }
        }

        public int DefineEnemyArmor(EnemyType type) {
            switch(type) {
                case EnemyType.Regular: return 4;
                case EnemyType.Special: return 7;
                case EnemyType.Rare: return 8;
                default: return 0;
            }
        }

        public int DefineEnemyLevel(EnemyType type) {
            switch(type) {
                case EnemyType.Regular: return 2;
                case EnemyType.Special: return 4;
                case EnemyType.Rare: return 6;
                default: return 0;
            }    
        }

    }
}