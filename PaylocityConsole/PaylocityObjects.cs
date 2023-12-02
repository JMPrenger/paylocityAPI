using PaylocityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PaylocityConsole
{
    public static class PaylocityObjects
    {
        public static void DisplayPaylocityObjects(List<PaylocityDto> dtoList)
        {
            Console.WriteLine("\nDisplaying Results:");
            var orderedList = dtoList.OrderByDescending(x => x.date).ToList();

            foreach (var ol in orderedList)
            {
                Console.WriteLine(ol.ToString());
            }
        }

        public static List<PaylocityDto> BuildPaylocityObject()
        {
            var objectList = new List<PaylocityDto>();
            var addAnother = "n";
            do
            {
                Console.Write("Enter the object's name: ");
                string? stringName = Console.ReadLine();
                Console.Write("Enter the object's type: ");
                string? stringType = Console.ReadLine();
                Console.Write("Enter the object's description: ");
                string? stringDescription = Console.ReadLine();
                Console.Write("Enter the object's date (YYYY-MM-DD): ");
                string? stringDate = Console.ReadLine();
                while (!Regex.Match(stringDate, "^\\d{4}\\-(0?[1-9]|1[012])\\-(0?[1-9]|[12][0-9]|3[01])$").Success)
                {
                    Console.Write("Enter the object's date (YYYY-MM-DD): ");
                    stringDate = Console.ReadLine();
                }

                DateOnly.TryParse(stringDate, out var tempDate);
                objectList.Add(new PaylocityDto
                {
                    name = stringName,
                    type = stringType,
                    description = stringDescription,
                    date = tempDate
                });
                Console.WriteLine("Do you want to create another? (y/n)");
                addAnother = Console.ReadLine().ToLower();

            } while (addAnother[0] == 'y');

            return objectList;
        }
    }
}
