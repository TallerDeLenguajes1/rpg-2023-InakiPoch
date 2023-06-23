using System.IO;
using ExceptionsHandler;

namespace ScreenManager {
    public class Screen {
        static string folderPath = "screen-files/";
        static string titleScreen = folderPath + "title-screen.txt";
        static ExceptionHandler newException = new ExceptionHandler();
        public void TitleScreen() {
            if(File.Exists(titleScreen)) {
                using(var streamReader = new StreamReader(titleScreen)) {
                    string? fileLine;
                    while((fileLine = streamReader.ReadLine()) != null) {
                        Console.WriteLine(fileLine);
                    }
                }
                return;
            }
            newException.CatchException(new Exception("ARCHIVO FALTANTE " + titleScreen));
        }
    }
}