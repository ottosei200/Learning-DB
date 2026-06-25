namespace ManagerCustomers {
    internal class Program {
        static void Main(string[] args) {
            try {
                Core.Run();
            } catch (Exception e) {
                Console.WriteLine(e.Message);
            }
        }
    }
}
