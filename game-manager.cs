using Entity;
using Serializer;
using ScreenManager;
using ExceptionsHandler;

namespace GameManager { 
    public class Game {
        static EntityGenerator entitiesGenerator = new EntityGenerator();
        static EntitiesJson entitiesSerializer = new EntitiesJson();
        static List<Character<EnemyType>> enemiesList = new List<Character<EnemyType>>();
        static Character<CharacterType>? mainCharacter;
        static Screen screenHandler = new Screen();
        static bool playerDefeated;
        static bool isDefending;
        static bool inCombat;
        static Combat? combat;


        public Game() {
            CreateEnemies();
            playerDefeated = false;
            isDefending = false;
            inCombat = false;
        }
        public void StartGame() {
            HandleGameStart();
            Console.ReadKey();
            while(!playerDefeated && !(mainCharacter == null)) {
                Character<EnemyType> currentEnemy = enemiesList[(new Random()).Next(enemiesList.Count)];
                combat = new Combat(currentEnemy);
                inCombat = true;
                combat.DisplayCombatScreen(currentEnemy);
                Console.WriteLine("╔══════════════════════════════════════════════════════════╗\n");
                Console.WriteLine("                   𝐀𝐆𝐑𝐄𝐃𝐈𝐃𝐎 𝐏𝐎𝐑: " + currentEnemy.Name + "       ");
                Console.WriteLine("                 𝐕𝐈𝐃𝐀 𝐃𝐄𝐋 𝐄𝐍𝐄𝐌𝐈𝐆𝐎: " + currentEnemy.Health + "     ");
                Console.WriteLine("\n╚══════════════════════════════════════════════════════════╝");
                while(inCombat) {
                    if(!isDefending) {
                        Console.WriteLine("\n════════════════════════════𝐓𝐄 𝐓𝐎𝐂𝐀: 𝐀𝐓𝐀𝐂𝐀𝐑════════════════════════════");
                        Console.WriteLine("\n                         𝐏𝐑𝐄𝐒𝐈𝐎𝐍𝐀 𝐏𝐀𝐑𝐀 𝐀𝐓𝐀𝐂𝐀𝐑!\n");
                        Console.ReadKey();
                        combat.CalculateDeffense(currentEnemy.Armor, currentEnemy.Speed);
                        int damageDealt = (int)combat.CalculateDamage(mainCharacter.Dexterity, mainCharacter.Strength, mainCharacter.Level);
                        currentEnemy.Health -= damageDealt;
                        Console.WriteLine("      ╔══════════════════════════════════════════════════════════╗");
                        Console.WriteLine("                          Danio Otorgado: " + damageDealt + "            ");
                        Console.WriteLine("                         Vida del enemigo: " + currentEnemy.Health + "      ");
                        Console.WriteLine("      ╚══════════════════════════════════════════════════════════╝");
                        isDefending = true;
                    }
                    else {
                        Console.WriteLine("\n═══════════════════════════𝐓𝐄 𝐓𝐎𝐂𝐀: 𝐃𝐄𝐅𝐄𝐍𝐃𝐄𝐑════════════════════════════");
                        Console.WriteLine("\n          Estas por recibir un ataque! Presiona para defenderte!\n");
                        Console.ReadKey();
                        combat.CalculateDeffense(mainCharacter.Armor, mainCharacter.Speed);
                        int damageRecieved = (int)combat.CalculateDamage(currentEnemy.Dexterity, currentEnemy.Strength, currentEnemy.Level);
                        mainCharacter.Health -= damageRecieved;
                        if(!(mainCharacter.Health <= 0)) {
                            Console.WriteLine("     ╔══════════════════════════════════════════════════════════╗");
                            Console.WriteLine("                         Danio recibido: " + damageRecieved + "            ");
                            Console.WriteLine("                          Vida restante: " + mainCharacter.Health + "      ");
                            Console.WriteLine("     ╚══════════════════════════════════════════════════════════╝");
                        }
                        else {
                            mainCharacter.Health = 0;
                            playerDefeated = true;
                            break;  
                        }
                        isDefending = false;
                    }
                    if(currentEnemy.Health <= 0) {
                        Console.WriteLine("Ganaste!");
                        enemiesList.Remove(currentEnemy);           
                        inCombat = false;
                    }
                }
            }
        }

        private void HandleGameStart() {
            CharacterType[] classes = Enum.GetValues<CharacterType>();
            int validClass, validAge;
            DateTime validBirthDate;
            screenHandler.TitleScreen();
            screenHandler.SelectClass();
            Console.Write("\nSeleccionar clase: ");
            string? selectedClass = Console.ReadLine();
            while(!int.TryParse(selectedClass, out validClass) || validClass < (int)classes[0] || validClass > classes.Length) {
                Console.Write("\nNo se detecto una opcion valida. Ingresar la clase que desea jugar\n");
                selectedClass = Console.ReadLine();
            }
            CharacterType type = (CharacterType)validClass;
            Console.WriteLine("\n𝐂𝐀𝐑𝐆𝐀 𝐃𝐄 𝐃𝐀𝐓𝐎𝐒");
            Console.Write("\nNombre: ");
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
            Console.Write("Edad (Hasta 300): ");
            string? age = Console.ReadLine();
            while(!int.TryParse(age, out validAge) || validAge > 300 || validAge < 0) {
                Console.Write("\nIngresar una edad valida\n");
                age = Console.ReadLine();
            }
            mainCharacter = entitiesGenerator.CreateMainCharacter(type, name, nickname, validBirthDate, validAge);
            if(mainCharacter == null) {
                (new ExceptionHandler()).CatchException(new Exception("NO SE PUDO CREAR EL PERSONAJE"));
                System.Environment.Exit(1);
            }
            if(!File.Exists(entitiesSerializer.CharacterFileName)) {
                entitiesSerializer.CreateCharacterFile(new List<Character<CharacterType>> { mainCharacter } );
            }
            entitiesSerializer.ReadFile<CharacterType>(entitiesSerializer.SerializedCharacter);
        }

        private void CreateEnemies() {
            const int MAX_CHARACTERS = 10;
            if(!File.Exists(entitiesSerializer.EnemiesFileName)) {
                for (int i = 0; i < MAX_CHARACTERS; i++) {
                    Character<EnemyType>? randomEnemy = entitiesGenerator.GenerateEnemies();
                    if (randomEnemy != null) {
                        enemiesList.Add(randomEnemy);
                    }
                }
                entitiesSerializer.CreateEnemiesFile(enemiesList);
            }
            //entitiesSerializer.ReadFile<EnemyType>(entitiesSerializer.SerializedEnemies);
        }
    }
}