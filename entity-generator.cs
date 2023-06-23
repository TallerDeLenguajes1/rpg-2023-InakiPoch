namespace Entity {
    public class EntityGenerator {
        static string[] names = {"Personaje1", "Personaje2", "Personaje3"}; 
        static string[] nicknames = {"Personaje1", "Personaje2", "Personaje3"};
        static DateTime start = new DateTime(1723, 1, 1);
        static int range = (DateTime.Today - start).Days;
        static Random random = new Random();
        static Array differentTypes = Enum.GetValues<CharacterType>();
        static Stats? stats = new Stats();
        
        public Character? GenerateEnemies() {
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

        public Character? CreateMainCharacter(CharacterType type, string name, string nickname, DateTime birthDate, int age) {
            if(!(stats == null)) {
                int newSpeed = stats.SetSpeed(type);
                int newDexterity = stats.SetDexterity(type);
                int newStrength = stats.SetStrength(type);
                int newArmor = stats.SetArmor(type);
                if(newSpeed == 0 && newDexterity == 0 && newStrength == 0 && newArmor == 0) {
                    return null;
                }
                return new Character(type, name, nickname, birthDate, age) {
                    Speed = newSpeed,
                    Dexterity = newDexterity,
                    Strength = newStrength,
                    Level = 1,
                    Armor = newArmor,
                    Health = 100
                };
            }
            return null;
        }
    }
}