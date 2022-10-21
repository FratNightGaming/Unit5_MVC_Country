using MVC_Countries;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using static System.Net.Mime.MediaTypeNames;

namespace MVC_Countries
{
    public class CountryController
    {
        public List<Country> CountryDataBase { get; set; } = new List<Country>();

        public CountryController()
        {
            Country USA = new Country ("USA", "North America", new List<string> {"Red", "White", "Blue"});
            Country China = new Country("China", "Asia", new List<string> { "Red", "White" });
            Country Israel = new Country("Israel", "Asia", new List<string> { "Blue", "White"});
            Country Japan = new Country("Japan", "Asia", new List<string> { "Red", "White" });
            Country England = new Country("England", "Europe", new List<string> { "Red", "White", "Blue" });
            Country Brazil = new Country("Brazil", "South America", new List<string> { "Green", "Yellow", "Blue" });
            Country France = new Country("France", "Europe", new List<string> { "Black", "Red", "Yellow" });

            CountryDataBase.Add(USA);
            CountryDataBase.Add(new Country("China", "Asia", new List<string> { "Red", "White" }));
            CountryDataBase.Add(Israel);
            CountryDataBase.Add(Japan);
            CountryDataBase.Add(England);
            CountryDataBase.Add(Brazil);
            CountryDataBase.Add(France);
        }

        public void CountryAction(Country c)//if controller is supposed to control logic, this controller class doesnt control logic; it just calls logic. Logic is done in the view classes
        {
            CountryView countryView = new CountryView(c);

            countryView.Display();
        }

        public void WelcomeAction()//what does action mean exactly
        {
            CountryListView countryListView = new CountryListView(CountryDataBase);

            Console.WriteLine($"Hello, welcome to the country app. Please select a country from the following list: ");

            Console.WriteLine();

            while (true)
            {
                countryListView.Display();

                Country selectedCountry;
                int countryIndex;

                while (true)
                {
                    try
                    {
                        Console.WriteLine("Please select a country by index:");
                        countryIndex = int.Parse(Console.ReadLine());
                        selectedCountry = countryListView.Countries[countryIndex];
                        Console.WriteLine();
                        break;
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                        continue;
                    }
                }

                /*Next allow the user to select a country by index. Upon getting the country out of CountryDb, pass that country along to the CountryAction() method.After that’s done, ask if the user would like to learn about another country.*/

                CountryAction(selectedCountry);

                if (Continue())
                {
                    continue;
                }

                else
                {
                    break;
                }
            }
        }

        public bool Continue()
        {
            Console.WriteLine("\nWould you like to learn about another country? Y/N");
            string input = string.Empty;
            try
            {
                input = Console.ReadLine().ToUpper().Trim();
                /*if (char.IsDigit(input, 0))
                {
                    throw new Exception("You must input Y/N instead of a number");
                }*/

                if (int.TryParse(input, out int num))
                {
                    throw new Exception("Cant parse nums bro");
                }
            }
            catch(FormatException e)
            {
                Console.WriteLine(e.Message);
            }

            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return Continue();
            }

            switch (input)
            {
                case "Y":
                    return true;
                case "YES":
                    return true;
                case "N":
                    Console.WriteLine("Exiting program. Goodbye!");
                    return false;
                case "NO":
                    Console.WriteLine("Exiting program. Goodbye!");
                    return false;
                default:
                    Console.WriteLine("Please enter Y/N");
                    return Continue();
            }
        }
    }
}
/*Lastly make a CountryController class. This class will be the big boss of your app and usually where you spend most of your time coding. This class should have the following properties and methods: 
List<Country> CountryDb - this stands in for our country database. We’ll learn those later, but know the info from the database gets stored in a list 
Public void CountryAction(Country c) -This will take in a Country model, passing the model into the CountryView constructor, and call Display Country on your CountryView object. 
Public void WelcomeAction() -This will take no parameter and pass CountryDb into the CountryListView class. Then, it will print “Hello, welcome to the country app. Please select a country from the following list:” Then it will call Display() on the CountryListView. 
Next allow the user to select a country by index. Upon getting the country out of CountryDb, pass that country along to the CountryAction() method.After that’s done, ask if the user would like to learn about another country. 

------------------------------

Extended Exercise: 
Use Console.Color to change the console’s colors to the country’s colors upon select that country. For Example, for USA, Change the console colors to Red, White, and Blue. Note that Countries have either 2 OR 3 colors, you will have to account for this. 
*/