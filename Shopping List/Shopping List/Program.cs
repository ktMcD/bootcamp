/* SHOPPING LIST
 * Katie McDougall
 * 10/23/22
 * 
 * Task: Make a shopping list application which uses collections to store your items. 
 * (You will be using two collections, one for the menu and one for the shopping list.)
 * 
 * What will the application do?
 * Display at least 8 item names and prices.
 * Ask the user to enter an item name
 * If that item exists, display that item and price and add that item to the user’s order.
 * If that item doesn’t exist, display an error and re-prompt the user.  (Display the menu again if you’d like.)
 * After adding one to their order, ask if they want to add another. If so, repeat.
 *     (User can enter an item more than once; we’re not keeping track of quantity at this point.)
 * When they’re done adding items, display a list of all items ordered with prices in columns.
 * Display the sum price of the items ordered.
 *  
 * Build Specifications/Grading Points
 * Application uses a Dictionary<string, decimal> to keep track of the menu of items.  You can code it with literals. (2 points for instantiation & initialization)
 * Use a List<string> for the shopping list and store the name of the items the customer ordered.
 * Application takes item name input and:
 *     Responds if that item doesn’t exist (1 point)
 *     Adds its name to the relevant List if it does (1 point)
 *     Application asks user if they want to quit or continue, and loops appropriately (1 point)
 * Application displays list of items with their prices (2 points)
 * Application displays the correct total predict for the list (1 point)
 * To determine the sum: Loop through the shopping list’s List collection, obtain the name, and look up the name’s price in the Menu Dictionary.
 * 
 * Extended Challenges:
 * Implement a menu system so the user can enter just a letter or number for the item.
 * Display the most and least expensive item ordered.
 * Display the items ordered in order of price.

*/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace Shopping_List
{
    internal class Program
    {
        // Dictionary to contain items <string> <string> <decimal>
        IDictionary<string, double> groceryPrices = new Dictionary<string, double>();
        // list to contain user shopping list
        List<string> shoppingList = new List<string>();
        static void Main(string[] args)
        {
            Program ShoppingList = new Program();
            ShoppingList.Driver();
        }
        public void Driver()
        {
            string userEntry = "";
            string menuSelection = "";
            int menuIdSelected = -1;
            bool isValidSelection = true;
            bool onceMore = false;

            PopulateDictionary();
            // introduction
            Console.WriteLine("Hello! Welcome to our shop!");
            Console.WriteLine();
            // Display the least and most expensive items
            DisplayLeastMost();
            Console.WriteLine();
            try
            {
                do
                {
                    // Get the menu selection from the user
                    // doesn't return until we ensure valid data entry
                    userEntry = DisplayMenu();
                    isValidSelection = ValidateShoppingListDataEntry(userEntry,
                                                                     out menuIdSelected,
                                                                     out menuSelection);

                    if (!isValidSelection || userEntry == "")
                    {
                        onceMore = DoOver("invalid selection");
                        if (!onceMore)
                        {
                            CalculateTotalsAndDisplay("total");
                            SoLong();
                        }
                    }

                    else // data entry validated
                    {
                        Console.WriteLine($"You entered {menuIdSelected}, {menuSelection}.");
                        AddShoppingListItem(menuSelection);
                        CalculateTotalsAndDisplay("subtotal");
                        onceMore = DoOver("");
                    }

                } while (onceMore);
            }
            catch (Exception weirdThing)
            {
                Console.WriteLine(weirdThing.Message); // if this were going to a log, I'd use .ToString()
                Console.WriteLine("That's bad. We didn't know that would happen.");
                Console.WriteLine("Sorry! We gotta go.");
                SoLong();
            }
            CalculateTotalsAndDisplay("total");
            SoLong(); // we done
        }

        private void PopulateDictionary()
        {
            groceryPrices.Add("apples", 1.99); // this seems so much cleaner
            groceryPrices.Add("bananas", .59);
            groceryPrices.Add("cherries", 3.79);
            groceryPrices.Add("dates", .99);
            groceryPrices.Add("eggplant", 4.79);
            groceryPrices.Add("figs", 1.89);
            groceryPrices.Add("grapes", 12.99);
            groceryPrices.Add("huckleberries", 8.39);
        }

        private void AddShoppingListItem(string menuSelection)
        {
            shoppingList.Add(menuSelection);
            return;
        }

        private void CalculateTotalsAndDisplay(string totalOrSubtotal)
        {
            bool shoppingListItemExists = true;
            bool doOver = false;
            double shoppingListPrice = -1;
            double runningTotal = 0;
            int listThingCount = 1;
            foreach (string listThing in shoppingList)
            {
                // find the item name in dictionary groceryPrices
                shoppingListItemExists = groceryPrices.TryGetValue(listThing, out shoppingListPrice);
                if (shoppingListItemExists)
                {
                    Console.WriteLine($"List Item {listThingCount}:  {listThing} {shoppingListPrice:C2}");
                    runningTotal += shoppingListPrice;
                    listThingCount++;
                }
                else
                {
                    Console.WriteLine("Something weird happened and we can't find that item in our inventory.");
                    return;
                }
             }
            if (totalOrSubtotal == "subtotal")
            {
                Console.WriteLine($"You have added {runningTotal:C2} worth of items to your shopping list.");
            }
            else
            {
                Console.WriteLine($"Your total for this list is {runningTotal:C2}.");
            }
            Console.WriteLine();
            return;
        }

        private void DisplayLeastMost()
        {
            // sort the dictionary
            var sortedGroceryPrices = groceryPrices.OrderBy(price => price.Value); // order ascending
            // if most get LastOrDefault()
            Console.WriteLine($"The most expensive thing at our market is " +
                              $"{sortedGroceryPrices.LastOrDefault().Key} at " +
                              $"{sortedGroceryPrices.LastOrDefault().Value:C2}");
            // if least then get FirstOrDefault()
            Console.WriteLine($"The least expensive thing at our market is " +
                              $"{sortedGroceryPrices.FirstOrDefault().Key} at " +
                              $"{sortedGroceryPrices.FirstOrDefault().Value:C2}");
        }

        private string DisplayMenu()
        {
            string rawDataEntry = "";
            Console.WriteLine("Please select your shopping list item ID from the menu below");
            Console.WriteLine("ID");
            foreach (var selection in Enum.GetValues(typeof(ShoppingListMenu))) // I think "var" is my only option here too
            {
                Console.WriteLine($"{(int)selection}: {selection}");
            }
            rawDataEntry = Console.ReadLine().Trim().ToLower();
            return rawDataEntry;
        }

        private bool ValidateShoppingListDataEntry(string dataToValidate,
                                                   out int validatedInput,
                                                   out string shoppingListName)
        {
            validatedInput = -1;
            shoppingListName = "";
            if (!int.TryParse(dataToValidate, out validatedInput))
            {
                return false;
            }
            shoppingListName = Enum.GetName(typeof(ShoppingListMenu), validatedInput);
            if (shoppingListName == null || shoppingListName == "")
            {
                return false;
            }
            return true;
        }
        private bool DoOver(string errorType)
        {
            string oneMoreTime;
            string messageToUser = "";
            switch (errorType)
            {
                case "invalid selection":
                    messageToUser = "We don't recognize the ID you entered \n" +
                                    "Would you like to try again?";
                    break;
                case "item not found":
                    messageToUser = "Something weird happened and we couldn't find that item in our inventory";
                    break;
                default:
                    messageToUser = "Would you like to add another item to your shopping list?";
                    break;
            }
            Console.WriteLine(messageToUser);
            Console.WriteLine("Enter yes or y to continue, or enter any other key to exit.");
            oneMoreTime = Console.ReadLine().Trim().ToLower();
            if (oneMoreTime != "y" && oneMoreTime != "yes")
            {
                return false;
            }
            return true;
        }

        private void SoLong()
        {
            Console.WriteLine("Thanks for shopping with us. Come back soon.");
            Console.ReadKey();
            Environment.Exit(0);
        }
    }
}
