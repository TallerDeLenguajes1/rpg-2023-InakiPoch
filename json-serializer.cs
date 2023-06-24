using System.Text.Json;
using Entity;

namespace Serializer {
    public class EntitiesJson {
        string? serializedEntity;
        string? enemiesFileName;
        string? serializedCharacter;
        string? characterFileName;

        public void CreateEnemiesFile(List<Character<EnemyType>> enemies) { 
            serializedEntity =  JsonSerializer.Serialize(enemies, new JsonSerializerOptions { WriteIndented = true });
            enemiesFileName = "json-files/enemies.json";
            File.WriteAllText(enemiesFileName, serializedEntity);
        }

        public void CreateCharacterFile(List<Character<CharacterType>> character) {
            serializedCharacter =  JsonSerializer.Serialize(character, new JsonSerializerOptions { WriteIndented = true });
            characterFileName = "json-files/main-character.json";
            File.WriteAllText(characterFileName, serializedCharacter);
        }

        public void ReadFile<T>(string? serializedEntity) where T : Enum {
            if(serializedEntity == null) {
                Console.WriteLine("\nNo se encontraron personajes\n");
                return;
            }
            List<Character<T>>? entities = JsonSerializer.Deserialize<List<Character<T>>>(serializedEntity);
            if(entities != null) {
                foreach(Character<T> entity in entities) {
                    Console.WriteLine("╔══════════════════════════════════════════════════════════╗");
                    Console.WriteLine("      𝐍𝐎𝐌𝐁𝐑𝐄: " + entity.Name);
                    Console.WriteLine("      𝐀𝐏𝐎𝐃𝐎: " + entity.Nickname);
                    Console.WriteLine("      𝐓𝐈𝐏𝐎: " + Enum.GetName(typeof(T), entity.Type));
                    Console.WriteLine("      𝐅𝐄𝐂𝐇𝐀 𝐃𝐄 𝐍𝐀𝐂𝐈𝐌𝐈𝐄𝐍𝐓𝐎: " + entity.BirthDate.ToString("dd/MM/yyyy"));
                    Console.WriteLine("      𝐄𝐃𝐀𝐃: " + entity.Age);
                    Console.WriteLine("      𝐕𝐄𝐋𝐎𝐂𝐈𝐃𝐀𝐃: " + entity.Speed);
                    Console.WriteLine("      𝐃𝐄𝐒𝐓𝐑𝐄𝐙𝐀: " + entity.Dexterity);
                    Console.WriteLine("      𝐅𝐔𝐄𝐑𝐙𝐀: " + entity.Strength);
                    Console.WriteLine("      𝐍𝐈𝐕𝐄𝐋: " + entity.Level);
                    Console.WriteLine("      𝐀𝐑𝐌𝐀𝐃𝐔𝐑𝐀: " + entity.Armor);
                    Console.WriteLine("      𝐕𝐈𝐃𝐀: " + entity.Health);
                    Console.WriteLine("╚══════════════════════════════════════════════════════════╝");
                }
            }
        }

        public string? EnemiesFileName { get => enemiesFileName; }
        public string? SerializedEnemies { get => serializedEntity; }
        public string? CharacterFileName { get => characterFileName; }
        public string? SerializedCharacter { get => serializedCharacter; }
    }
}