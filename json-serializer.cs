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

        public void CreateCharacterFile(Character<CharacterType> character) {
            serializedCharacter =  JsonSerializer.Serialize(character, new JsonSerializerOptions { WriteIndented = true });
            characterFileName = "json-files/main-character.json";
            File.WriteAllText(characterFileName, serializedCharacter);
        }

        public void ReadFile(string? serializedEntity, Type entityType) {
            if(serializedEntity == null) {
                Console.WriteLine("\nNo se encontraron personajes\n");
                return;
            }
            if(entityType == typeof(CharacterType)) {
                Character<CharacterType>? character = JsonSerializer.Deserialize<Character<CharacterType>>(serializedEntity);
                if(character != null) {
                    Console.WriteLine("╔══════════════════════════════════════════════════════════╗");
                    Console.WriteLine("      Nombre: " + character.Name);
                    Console.WriteLine("      Apodo: " + character.Nickname);
                    Console.WriteLine("      Tipo: " + Enum.GetName(typeof(CharacterType), character.Type));
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
            else {
                List<Character<EnemyType>>? enemies = JsonSerializer.Deserialize<List<Character<EnemyType>>>(serializedEntity);
                if(enemies != null) {
                    foreach(Character<EnemyType> enemy in enemies) {
                        Console.WriteLine("╔══════════════════════════════════════════════════════════╗");
                        Console.WriteLine("      Nombre: " + enemy.Name);
                        Console.WriteLine("      Apodo: " + enemy.Nickname);
                        Console.WriteLine("      Tipo: " + Enum.GetName(typeof(EnemyType), enemy.Type));
                        Console.WriteLine("      Fecha de nacimiento: " + enemy.BirthDate.ToString("dd/MM/yyyy"));
                        Console.WriteLine("      Edad: " + enemy.Age);
                        Console.WriteLine("      Velocidad: " + enemy.Speed);
                        Console.WriteLine("      Destreza: " + enemy.Dexterity);
                        Console.WriteLine("      Fuerza: " + enemy.Strength);
                        Console.WriteLine("      Nivel: " + enemy.Level);
                        Console.WriteLine("      Armadura: " + enemy.Armor);
                        Console.WriteLine("      Vida: " + enemy.Health);
                        Console.WriteLine("╚══════════════════════════════════════════════════════════╝");
                    }
                }
            }
        }

        public string? EnemiesFileName { get => enemiesFileName; }
        public string? SerializedEnemies { get => serializedEntity; }
        public string? CharacterFileName { get => characterFileName; }
        public string? SerializedCharacter { get => serializedCharacter; }
    }
}