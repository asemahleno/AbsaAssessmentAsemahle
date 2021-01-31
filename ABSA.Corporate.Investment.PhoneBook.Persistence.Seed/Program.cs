namespace ABSA.Corporate.Investment.PhoneBook.Persistence.Seed
{
    using System.Configuration;
    using Microsoft.EntityFrameworkCore;


    using System;

    public class Program
    {
        public static void Main(string[] args)
        {
            if (!AskConfirmation(out var connectionStringName))
            {
                return;
            }

            try
            {
                var optionsBuilder = new DbContextOptionsBuilder<DatabaseContext>();
                optionsBuilder.UseSqlServer(connectionStringName);

                using (var modelContext = new DatabaseContext(optionsBuilder.Options))
                {
                    modelContext.Database.EnsureDeleted();
                    modelContext.Database.EnsureCreated();
                    Console.WriteLine("Successfully Created Database");

                }
            }
            catch (Exception exception)
            {
                LogMessage(ConsoleColor.Red, "" + exception);
            }

            Console.WriteLine(@"Press Enter key to exit...");
            Console.ReadLine();
        }

        private static bool AskConfirmation(out string connectionStringName)
        {
            var environmentName = ConfigurationManager.AppSettings["Environment"];

            connectionStringName =
                ConfigurationManager.ConnectionStrings["AbsaConnectionString"].ConnectionString;
            
            LogMessage(ConsoleColor.DarkYellow, $"You are about to reset the database of the following environment: {environmentName} \n");
          
            Console.WriteLine("The Connection string to the DB is :\n" + connectionStringName + "\n\n");
           LogMessage(ConsoleColor.Blue,"Do you wish to proceed? (Y/N): ");

            var answer = Console.ReadLine();

            var canProceed = !string.IsNullOrEmpty(answer)
                             && (answer.ToLower().Trim().Equals("y") || answer.ToLower().Trim() == "yes");

            return canProceed;
        }


        private static void LogMessage(ConsoleColor color, string message)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(message);
            Console.ResetColor();
        }
    }
}
