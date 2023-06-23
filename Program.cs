using Entity;
using Serializer;

internal class Program
{
    private static void Main(string[] args)
    {
        const int MAX_CHARACTERS = 10;
        var entitiesGenerator = new EntityGenerator();
        var entitySerializer = new EntitiesJson();
        var enemiesList = new List<Character>();
        if(!File.Exists(entitySerializer.CharactersFileName)) {
            for (int i = 0; i < MAX_CHARACTERS; i++) {
                Character? randomEnemy = entitiesGenerator.GenerateEnemies();
                if (randomEnemy != null)
                {
                    Character character = randomEnemy;
                    enemiesList.Add(character);
                }
            }
            entitySerializer.CreateEnemiesFile(enemiesList);
        }
        entitySerializer.ReadCharacters();
    }
}