using System.Text.Json;
using Entity;

namespace Serializer {
    public class EntitiesJson {
        string? serializedCharacters;
        string? charactersFileName;

        public void CreateEnemiesFile(List<Character> entities) { 
            serializedCharacters =  JsonSerializer.Serialize(entities, new JsonSerializerOptions { WriteIndented = true });
            charactersFileName = "json-files/enemies.json";
            File.WriteAllText(charactersFileName, serializedCharacters);
        }

        public void ReadCharacters() {
            if(serializedCharacters == null) {
                Console.WriteLine("\nNo se encontraron personajes\n");
                return;
            }
            List<Character>? characters = JsonSerializer.Deserialize<List<Character>>(serializedCharacters);
            if(characters != null) {
                foreach(Character character in characters) {
                    Console.WriteLine("Nombre: " + character.Name);
                    Console.WriteLine("Apodo: " + character.Nickname);
                    Console.WriteLine("Tipo: " + Enum.GetName(character.Type));
                    Console.WriteLine("Fecha de nacimiento: " + character.BirthDate.ToString("dd/MM/yyyy"));
                    Console.WriteLine("Edad: " + character.Age);
                    Console.WriteLine("Velocidad: " + character.Speed);
                    Console.WriteLine("Destreza: " + character.Dexterity);
                    Console.WriteLine("Fuerza: " + character.Strength);
                    Console.WriteLine("Nivel: " + character.Level);
                    Console.WriteLine("Armadura: " + character.Armor);
                    Console.WriteLine("Vida: " + character.Health + "\n");
                }
            }
        }

        public string? CharactersFileName { get => charactersFileName; }
    }
}