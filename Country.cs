using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_Countries
{
    public class Country
    {
        public string Name { get; set; }
        public string Continent { get; set; }
        public List<string> Colors { get; set; } = new List<string>();

        public Country(string name, string continent, List<string> colors)
        {
            Name = name;
            Continent = continent;
            Colors = colors;
        }
    }
}

/*What will the application do?

Make a Country model with the following properties: 
Public string Name 
Public string Continent (Or an enum if you feel spicy and we’ve gone over that) 
Public List<string> Colors

------------------------------

Next Create a CountryView Class. In the constructor require a Country be taken in and set to DisplayCountry. Create the following property and method: 
Public Country DisplayCountry
Public void Display() -This method will print out the Name, Continent, and Colors of the Country DisplayCountry property

------------------------------

Next Create a CountryListView class. This view will take a list of countries in its constructor. It should have the following property and method: 
Public List<Country> Countries - store the parameter from the constructor here.
Public void Display() - Print the name of each country in the list along with the index for each country

------------------------------

Lastly make a CountryController class. This class will be the big boss of your app and usually where you spend most of your time coding. This class should have the following properties and methods: 
List<Country> CountryDb - this stands in for our country database. We’ll learn those later, but know the info from the database gets stored in a list 
Public void CountryAction(Country c) -This will take in a Country model, passing the model into the CountryView constructor, and call Display Country on your CountryView object. 
Public void WelcomeAction() -This will take no parameter and pass CountryDb into the CountryListView class. Then, it will print “Hello, welcome to the country app. Please select a country from the following list:” Then it will call Display() on the CountryListView. 
Next allow the user to select a country by index. Upon getting the country out of CountryDb, pass that country along to the CountryAction() method.After that’s done, ask if the user would like to learn about another country. 

------------------------------

Extended Exercise: 
Use Console.Color to change the console’s colors to the country’s colors upon select that country. For Example, for USA, Change the console colors to Red, White, and Blue. Note that Countries have either 2 OR 3 colors, you will have to account for this. 
*/