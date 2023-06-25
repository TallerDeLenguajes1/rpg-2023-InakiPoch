using ExceptionsHandler;

namespace Entity {
    public class EntityGenerator {
        static string[] names = {"Soldier of Godrick", "Vanished Knight", "Omen"}; 
        static string[] nicknames = {"Godrick's Soldier", "Knight", "Omen"};
        static DateTime start = new DateTime(1723, 1, 1);
        static int range = (DateTime.Today - start).Days;
        static Random random = new Random();
        static Array differentEnemyTypes = Enum.GetValues<EnemyType>();
        static Stats? stats = new Stats();
        
        public Character<EnemyType>? GenerateEnemies() {
            if (differentEnemyTypes == null || stats == null) {
                return null;
            }
            int index = random.Next(differentEnemyTypes.Length);
            var tryType = differentEnemyTypes.GetValue(index); 
            if(tryType == null) {
                return null;
            }
            EnemyType type = (EnemyType)tryType;
            DateTime birthDate = start.AddDays(random.Next(range));
            int age = DateTime.Today.Year - birthDate.Year;
            int nameIndex = (int)type;
            string name = names[nameIndex];
            string nickname = nicknames[nameIndex];
            return new Character<EnemyType>(type, name, nickname, birthDate, age) {
                Speed = stats.DefineEnemySpeed(type),
                Dexterity = stats.DefineEnemyDex(type),
                Strength = stats.DefineEnemyStrength(type),
                Level = stats.DefineEnemyLevel(type),
                Armor = stats.DefineEnemyArmor(type),
                Health = stats.DefineEnemyHealth(type)
            };
        }

        public Character<CharacterType>? CreateMainCharacter(CharacterType type, string name, string nickname, DateTime birthDate, int age) {
            if(!(stats == null)) {
                int newSpeed = stats.SetSpeed(type);
                int newDexterity = stats.SetDexterity(type);
                int newStrength = stats.SetStrength(type);
                int newArmor = stats.SetArmor(type);
                if(newSpeed == 0 && newDexterity == 0 && newStrength == 0 && newArmor == 0) {
                    return null;
                }
                birthDate = birthDate.AddYears(DateTime.Today.Year - birthDate.Year);
                birthDate = birthDate.AddYears(-age);
                return new Character<CharacterType>(type, name, nickname, birthDate, age) {
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