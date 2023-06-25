public enum CharacterType { Warrior = 1, Confessor, Samurai }
public enum EnemyType { Regular, Special, Rare }
interface IStats {
    int Speed { get; set; }
    int Dexterity { get; set; }
    int Strength { get; set; }
    int Level { get; set; }
    int Armor { get; set; }
    int Health { get; set; }
}

namespace Entity {
    public class Character<TEnum> : IStats where TEnum : Enum {
        TEnum type;
        string name;
        string nickname;
        DateTime birthDate;
        int age;

        public Character(TEnum type, string name, string nickname, DateTime birthDate, int age) {
            this.type = type;
            this.name = name;
            this.nickname = nickname;
            this.birthDate = birthDate;
            this.age = age;
        }

        public TEnum Type { get => type; }
        public string Name { get => name; }
        public string Nickname { get => nickname; }
        public DateTime BirthDate { get => birthDate; }
        public int Age { get => age; }

        public int Speed { get; set; }
        public int Dexterity { get; set; }
        public int Strength { get; set; }
        public int Level { get; set; }
        public int Armor { get; set; }
        public int Health { get; set; }
    }
}
