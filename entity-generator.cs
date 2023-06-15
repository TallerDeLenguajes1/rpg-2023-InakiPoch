namespace Entity {
    public class EntityGenerator {
        static string[] names = {"Personaje1", "Personaje2", "Personaje3"}; 
        static string[] nicknames = {"Personaje1", "Personaje2", "Personaje3"};
        static DateTime start = new DateTime(1995, 1, 1);
        static int range = (DateTime.Today - start).Days;
        static Random random = new Random();
        public Character GenerateCharacter() {
            Array differentTypes = Enum.GetValues(typeof(CharacterType));
            var type = (CharacterType)differentTypes.GetValue(random.Next(differentTypes.Length));
            string name = names[random.Next(names.Length)];
            string nickname = nicknames[random.Next(nicknames.Length)];
            int age = random.Next(300);
            DateTime birthDate = start.AddDays(random.Next(range));
            return new Character(type, name, nickname, birthDate, age) {
                Speed = 100, 
                Dexterity = 9, 
                Strength = 10, 
                Level = 1,
                Armor = 20,
                Health = 50 
            };
        }
    }
}