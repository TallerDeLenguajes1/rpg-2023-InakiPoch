using System.Text.Json;
using Entity;

namespace Serializer {
    public class EntitiesJson {
        string? serializedEntity;
        string? enemiesFileName;

        string? serializedCharacter;
        string? characterFileName;

        public void CreateEnemiesFile(List<Character> enemies) { 
            serializedEntity =  JsonSerializer.Serialize(enemies, new JsonSerializerOptions { WriteIndented = true });
            enemiesFileName = "json-files/enemies.json";
            File.WriteAllText(enemiesFileName, serializedEntity);
        }

        public void CreateCharacterFile(List<Character> character) {
            serializedCharacter =  JsonSerializer.Serialize(character, new JsonSerializerOptions { WriteIndented = true });
            characterFileName = "json-files/main-character.json";
            File.WriteAllText(characterFileName, serializedCharacter);
        }

        public void ReadFile(string? serializedEntity) {
            if(serializedEntity == null) {
                Console.WriteLine("\nNo se encontraron personajes\n");
                return;
            }
            List<Character>? characters = JsonSerializer.Deserialize<List<Character>>(serializedEntity);
            if(characters != null) {
                foreach(Character character in characters) {
                    Console.WriteLine("╔══════════════════════════════════════════════════════════╗");
                    Console.WriteLine("      Nombre: " + character.Name);
                    Console.WriteLine("      Apodo: " + character.Nickname);
                    Console.WriteLine("      Tipo: " + Enum.GetName(character.Type));
                    Console.WriteLine("      Fecha de nacimiento: " + character.BirthDate.ToString("dd/MM/yyyy"));
                    Console.WriteLine("      Edad: " + character.Age);
                    Console.WriteLine("      Velocidad: " + character.Speed);
                    Console.WriteLine("      Destreza: " + character.Dexterity);
                    Console.WriteLine("      Fuerza: " + character.Strength);
                    Console.WriteLine("      Nivel: " + character.Level);
                    Console.WriteLine("      Armadura: " + character.Armor);
                    Console.WriteLine("      Vida: " + character.Health);
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