using Entity;
using Serializer;
using ScreenManager;
using ExceptionsHandler;

namespace GameManager { 
    public class Game {
        static EntityGenerator entitiesGenerator = new EntityGenerator();
        static EntitiesJson entitiesSerializer = new EntitiesJson();
        static List<Character> enemiesList = new List<Character>();
        static Screen screenHandler = new Screen();

        public void StartGame() {
            HandleGameStart();
            // const int MAX_CHARACTERS = 10;
            // if(!File.Exists(entitySerializer.CharactersFileName)) {
            //     for (int i = 0; i < MAX_CHARACTERS; i++) {
            //         Character? randomEnemy = entitiesGenerator.GenerateEnemies();
            //         if (randomEnemy != null) {
            //             Character character = randomEnemy;
            //             enemiesList.Add(character);
            //         }
            //     }
            //     entitySerializer.CreateEnemiesFile(enemiesList);
            // }
            // entitySerializer.ReadCharacters();
        }

        private void HandleGameStart() {
            CharacterType[] classes = Enum.GetValues<CharacterType>();
            int validClass, validAge;
            DateTime validBirthDate;
            screenHandler.TitleScreen();
            screenHandler.SelectClass();
            string? selectedClass = Console.ReadLine();
            while(!int.TryParse(selectedClass, out validClass) || validClass < (int)classes[0] || validClass > classes.Length) {
                Console.Write("\nNo se detecto una opcion valida. Ingresar la clase que desea jugar\n");
                selectedClass = Console.ReadLine();
            }
            CharacterType type = (CharacterType)validClass;
            Console.Write("Nombre: ");
            string? name = Console.ReadLine();
            while(name == string.Empty || name == null) {
                Console.Write("\nIngresar un nombre valido\n");
                name = Console.ReadLine();
            }
            Console.Write("Apodo: ");
            string? nickname = Console.ReadLine();
            while(nickname == string.Empty || nickname == null) {
                Console.Write("\nIngresar un apodo valido\n");
                nickname = Console.ReadLine();
            }
            Console.Write("Fecha de nacimiento: ");
            string? birthDate = Console.ReadLine();
            while(!DateTime.TryParse(birthDate, out validBirthDate)) {
                Console.Write("\nIngresar una fecha de nacimiento valida\n");
                birthDate = Console.ReadLine();
            }
            Console.Write("Edad: ");
            string? age = Console.ReadLine();
            while(!int.TryParse(age, out validAge)) {
                Console.Write("\nIngresar una edad valida\n");
                selectedClass = Console.ReadLine();
            }
            Character? mainCharacter = entitiesGenerator.CreateMainCharacter(type, name, nickname, validBirthDate, validAge);
            if(mainCharacter == null) {
                (new ExceptionHandler()).CatchException(new Exception("NO SE PUDO CREAR EL PERSONAJE"));
                System.Environment.Exit(1);
            }
            if(!File.Exists(entitiesSerializer.CharacterFileName)) {
                entitiesSerializer.CreateCharacterFile(new List<Character> { mainCharacter });
            }
            entitiesSerializer.ReadFile(entitiesSerializer.SerializedCharacter);
        }
    }
}