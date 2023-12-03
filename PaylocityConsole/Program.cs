namespace PaylocityConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var httpService = new HttpService();
            int optionNumber;
            var option = string.Empty;
            bool isNum;
            Console.WriteLine("Welcome to the Paylocity Console App!");
            do
            {
                do
                {
                    option = PresentOptions();
                    isNum = int.TryParse(option, out optionNumber);

                } while (!isNum || (optionNumber < 1 && optionNumber > 3));

                switch (optionNumber)
                {
                    case 1:
                        {
                            var objectList = PaylocityObjects.BuildPaylocityObject();
                            var result = Task.Run(() => httpService.AddObjects(objectList)).GetAwaiter().GetResult();
                            if (result)
                            {
                                Console.WriteLine("Object successfully created");
                            }
                            else
                            {
                                Console.WriteLine("An error has occurred");
                            }
                            break;
                        }
                    case 2:
                        {
                            var objects = Task.Run(() => httpService.GetObjects()).GetAwaiter().GetResult();
                            PaylocityObjects.DisplayPaylocityObjects(objects);
                            break;
                        }
                    default:
                        break;
                }
            } while (optionNumber != 3);
            Console.WriteLine("Exiting...");
        }

        static string PresentOptions()
        {
            Console.WriteLine();
            Console.WriteLine("Please choose from the following options:");
            Console.WriteLine("1: Create a new Paylocity object");
            Console.WriteLine("2: Get all Paylocity objects");
            Console.WriteLine("3: Exit");
            return Console.ReadLine();
        }
    }
}
