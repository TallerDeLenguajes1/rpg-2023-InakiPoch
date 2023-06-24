public enum CharacterType { Confessor = 1, Samurai, Warrior }

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

        public CharacterType Type { get => type; }
        public string Name { get => name; }
        public string Nickname { get => nickname; }
        public DateTime BirthDate { get => birthDate; }
        public int Age { get => age; }

        public float Speed { get; set; }
        public float Dexterity { get; set; }
        public float Strength { get; set; }
        public int Level { get; set; }
        public float Armor { get; set; }
        public int Health { get; set; }
    }
}
