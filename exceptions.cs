namespace ExceptionsHandler {
    public class ExceptionHandler {
        public void CatchException(Exception e) {
            Console.WriteLine("ERROR: " + e.Message);
            System.Environment.Exit(1);
        }
    }
}