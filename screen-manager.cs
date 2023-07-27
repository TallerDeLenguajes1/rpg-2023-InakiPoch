using System.IO;
using ExceptionsHandler;

namespace ScreenManager {
    public class Screen {
        static string folderPath = "screen-files/";
        static string titleScreen = folderPath + "title-screen.txt";
        static string classesScreen = folderPath + "select-class.txt";
        static string stormveilScreen = folderPath + "stormveil-text.txt";
        static ExceptionHandler newException = new ExceptionHandler();

        private void readfile(string fileName) {
            if(File.Exists(fileName)) {
                using(var streamReader = new StreamReader(fileName)) {
                    string? fileLine;
                    while((fileLine = streamReader.ReadLine()) != null) {
                        Console.WriteLine(fileLine);
                    }
                }
                return;
            }
            newException.CatchException(new Exception("MISSING FILE " + fileName));
        }
        
        public void TitleScreen() { readfile(titleScreen); }
        public void SelectClass() { readfile(classesScreen); }
        public void CombatScreen(string currentEnemy) { readfile(folderPath + currentEnemy); }
        public void StormveilScreen() { readfile(stormveilScreen); }
    }
}