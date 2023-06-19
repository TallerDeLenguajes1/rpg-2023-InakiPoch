using System.Text.Json;
using Entity;

namespace Serializer {
    public class EntitiesJson {
        string? serializedCharacters;
        string? charactersFileName;

        public void CreateCharactersFile(List<Character> entities) { 
            serializedCharacters =  JsonSerializer.Serialize(entities);
            charactersFileName = "characters.json";
            File.WriteAllText(charactersFileName, serializedCharacters);
        }

        public void ReadCharacters() {
            if(serializedCharacters == null) {
                Console.WriteLine("\nNombre de archivo no previsto\n");
                return;
            }
            List<Character>? characters = JsonSerializer.Deserialize<List<Character>>(serializedCharacters);
            if(characters != null) {
                foreach(Character character in characters) {
                    Console.WriteLine("Nombre: " + character.Name);
                    Console.WriteLine("Apodo: " + character.Nickname);
                    Console.WriteLine("Tipo: " + Enum.GetName(character.Type));
                    Console.WriteLine("Fecha de nacimiento: " + character.BirthDate);
                    Console.WriteLine("Edad: " + character.Age);
                    Console.WriteLine("Velocidad: " + character.Speed);
                    Console.WriteLine("Destreza: " + character.Dexterity);
                    Console.WriteLine("Fuerza: " + character.Strength);
                    Console.WriteLine("Nivel: " + character.Level);
                    Console.WriteLine("Armadura: " + character.Armor);
                    Console.WriteLine("Vida: " + character.Health);
                }
            }
        }
    }
}