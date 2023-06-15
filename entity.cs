public enum CharacterType { Sage, Cleric, Warrior }

interface IStats {
    float Speed { get; set; }
    float Dexterity { get; set; }
    float Strength { get; set; }
    int Level { get; set; }
    float Armor { get; set; }
    int Health { get; set; }
}

namespace Entity {
    public class Character : IStats {
        CharacterType type;
        string name;
        string nickname;
        DateTime birthDate;
        int age;

        public Character(CharacterType type, string name, string nickname, DateTime birthDate, int age) {
            this.type = type;
            this.name = name;
            this.nickname = nickname;
            this.birthDate = birthDate;
            this.age = age;
        }

        public float Speed { get; set; }
        public float Dexterity { get; set; }
        public float Strength { get; set; }
        public int Level { get; set; }
        public float Armor { get; set; }
        public int Health { get; set; }
    }
}
