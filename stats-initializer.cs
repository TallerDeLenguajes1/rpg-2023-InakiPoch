namespace Entity {
    public class Stats {
        public int SetSpeed(CharacterType type) {
            switch(type) {
                case CharacterType.Confessor: return 5;
                case CharacterType.Samurai: return 9;
                case CharacterType.Warrior: return 7;
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
                case CharacterType.Confessor: return 3;
                case CharacterType.Samurai: return 5;
                case CharacterType.Warrior: return 10;
                default: return 0;
            }
        }
        public int SetArmor(CharacterType type) {
            switch(type) {
                case CharacterType.Confessor: return 2;
                case CharacterType.Samurai: return 7;
                case CharacterType.Warrior: return 9;
                default: return 0;
            }
        }
    }
}