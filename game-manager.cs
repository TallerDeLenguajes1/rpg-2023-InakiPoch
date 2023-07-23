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
        static int playerXP;
        static int maxXP;
        static int maxPlayerHP = 100;
        static bool playerDefeated;
        static bool isDefending;
        static bool inCombat;
        static Combat? combat;


        public Game() {
            createEnemies();
            playerDefeated = false;
            isDefending = false;
            inCombat = false;
            playerXP = 0;
            maxXP = 50;
        }
        public void StartGame() {
            handleGameStart();
            Console.ReadKey();
            while(!playerDefeated && !(mainCharacter == null) && enemiesList.Any()) {
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
                        Console.WriteLine("\n\n\n\n════════════════════════════𝐓𝐄 𝐓𝐎𝐂𝐀: 𝐀𝐓𝐀𝐂𝐀𝐑════════════════════════════");
                        Console.WriteLine("\n                         𝐏𝐑𝐄𝐒𝐈𝐎𝐍𝐀 𝐏𝐀𝐑𝐀 𝐀𝐓𝐀𝐂𝐀𝐑!\n");
                        Console.ReadKey();
                        combat.CalculateDeffense(currentEnemy.Armor, currentEnemy.Speed);
                        int damageDealt = combat.CalculateDamage(mainCharacter.Dexterity, mainCharacter.Strength, mainCharacter.Level);
                        currentEnemy.Health -= damageDealt;
                        if(currentEnemy.Health < 0) {
                            currentEnemy.Health = 0;
                        }
                        Console.WriteLine("\n\n      ╔══════════════════════════════════════════════════════════╗");
                        Console.WriteLine("                          Danio Otorgado: " + damageDealt + "            ");
                        Console.WriteLine("                         Vida del enemigo: " + currentEnemy.Health + "      ");
                        Console.WriteLine("      ╚══════════════════════════════════════════════════════════╝");
                        isDefending = true;
                    }
                    else {
                        Console.WriteLine("\n\n\n\n═══════════════════════════𝐓𝐄 𝐓𝐎𝐂𝐀: 𝐃𝐄𝐅𝐄𝐍𝐃𝐄𝐑════════════════════════════");
                        Console.WriteLine("\n          Estas por recibir un ataque! Presiona para defenderte!\n");
                        Console.ReadKey();
                        combat.CalculateDeffense(mainCharacter.Armor, mainCharacter.Speed);
                        int damageRecieved = combat.CalculateDamage(currentEnemy.Dexterity, currentEnemy.Strength, currentEnemy.Level);
                        mainCharacter.Health -= damageRecieved;
                        if(!(mainCharacter.Health <= 0)) {
                            Console.WriteLine("\n\n     ╔══════════════════════════════════════════════════════════╗");
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
                    if(currentEnemy.Health == 0) {
                        Console.WriteLine("\n\n\n                               𝐕𝐈𝐂𝐓𝐎𝐑𝐈𝐀\n\n\n");
                        Console.WriteLine("RECOMPENSA: +50XP");
                        playerXP += 50;
                        if(playerXP == maxXP) {
                            mainCharacter.Level++;
                            playerXP = 0;
                            maxXP += 50;
                            mainCharacter.Health += 20;
                            if(mainCharacter.Health > maxPlayerHP) {
                                mainCharacter.Health = maxPlayerHP;
                            }
                            Console.WriteLine("\n\n     ╔══════════════════════════════════════════════════════════╗");
                            Console.WriteLine("                           𝐒𝐔𝐁𝐄𝐒 𝐃𝐄 𝐍𝐈𝐕𝐄𝐋!");
                            Console.WriteLine("                            𝐍𝐈𝐕𝐄𝐋 𝐀𝐂𝐓𝐔𝐀𝐋: " + mainCharacter.Level + "");
                            Console.WriteLine("     ╚══════════════════════════════════════════════════════════╝");
                            if(mainCharacter.Level % 3 == 0) {
                                Console.WriteLine("\nTus habilidades fueron mejoradas!\n");
                                mainCharacter.Speed += 1;
                                mainCharacter.Strength += 1;
                                mainCharacter.Dexterity += 1;
                                mainCharacter.Armor += 1;
                                maxPlayerHP += 20;
                                increaseEnemiesStats();
                            }
                        }
                        Console.WriteLine("\n\n𝐏𝐑𝐄𝐒𝐈𝐎𝐍𝐀 𝐏𝐀𝐑𝐀 𝐂𝐎𝐍𝐓𝐈𝐍𝐔𝐀𝐑\n");
                        Console.ReadKey();
                        enemiesList.Remove(currentEnemy);           
                        inCombat = false;
                        entitiesSerializer.CreateCharacterFile(new List<Character<CharacterType>> { mainCharacter } );
                    }
                }
            }
            if(!enemiesList.Any()) {
                Console.WriteLine("\n\n               𝐅𝐄𝐋𝐈𝐂𝐈𝐃𝐀𝐃𝐄𝐒! 𝐆𝐀𝐍𝐀𝐒𝐓𝐄! 𝐄𝐑𝐄𝐒 𝐃𝐈𝐆𝐍𝐎 𝐃𝐄 𝐒𝐄𝐑 𝐄𝐋𝐃𝐄𝐍 𝐋𝐎𝐑𝐃\n");
                Console.WriteLine("\n                                    STATS FINALES\n");
                entitiesSerializer.ReadFile<CharacterType>(entitiesSerializer.SerializedCharacter);
            }
            else {
                Console.WriteLine("\n\n                                       𝐏𝐄𝐑𝐃𝐈𝐒𝐓𝐄\n\n");
                Console.WriteLine("\n                 Put these foolish ambitions to rest. STATS FINALES\n");
                entitiesSerializer.ReadFile<CharacterType>(entitiesSerializer.SerializedCharacter);
            }
        }

        private void handleGameStart() {
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

        private void createEnemies() {
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

        private void increaseEnemiesStats() {
            foreach(Character<EnemyType> enemy in enemiesList) {
                enemy.Armor += 1;
                enemy.Dexterity += 1;
                enemy.Speed += 1;
                enemy.Strength += 1;
            }
        }
    }
}