namespace Entity {
    public class EntityGenerator {
        static string[] names = {"Personaje1", "Personaje2", "Personaje3"}; 
        static string[] nicknames = {"Personaje1", "Personaje2", "Personaje3"};
        static DateTime start = new DateTime(1723, 1, 1);
        static int range = (DateTime.Today - start).Days;
        static Random random = new Random();
        static Array differentTypes = Enum.GetValues<CharacterType>();
        
        public Character? GenerateCharacter() {
            if (differentTypes == null) {
                return null;
            }
            int index = random.Next(differentTypes.Length);
            var tryType = differentTypes.GetValue(index); 
            if(tryType == null) {
                return null;
            }
            CharacterType type = (CharacterType)tryType;
            DateTime birthDate = start.AddDays(random.Next(range));
            int age = DateTime.Today.Year - birthDate.Year;
            int nameIndex = random.Next(names.Length);
            string name = names[nameIndex];
            string nickname = nicknames[nameIndex];
            return new Character(type, name, nickname, birthDate, age) {
                Speed = random.Next(1, 10),
                Dexterity = random.Next(1, 5),
                Strength = random.Next(1, 10),
                Level = random.Next(1, 10),
                Armor = random.Next(1, 10),
                Health = 100
            };
        }
    }
}