using Entity;
using Serializer;

var entityGenerator = new EntityGenerator();
var entitySerializer = new EntitiesJson();
var charactersList = new List<Character>();

for(int i  = 0; i < 3; i++) {
    Character? randomCharacter = entityGenerator.GenerateCharacter();
    if(randomCharacter != null) {
        Character character = randomCharacter;
        charactersList.Add(character);        
    }
}

entitySerializer.CreateCharactersFile(charactersList);
entitySerializer.ReadCharacters();

