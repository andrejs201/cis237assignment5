//Author: Andrejs Tomsons
//CIS 237
//Assignment 5
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment1
{
    class WineItemCollection : IWineCollection
    {
        //Private Variables
        WineItem[] wineItems;
        BeverageATomsonsEntities1 beverageEntity = new BeverageATomsonsEntities1();

        public int WineItemsLength
        { get; set; }

        //Constuctor. Must pass the size of the collection.
        public WineItemCollection(int size)
        {
            wineItems = new WineItem[size];
            WineItemsLength = 0;
        }

        //Add a new item to the collection
        public void AddNewItem(string id, string name, string pack, decimal price)
        {
            //Add a new WineItem to the collection. Increase the Length variable.
            Beverage beverageToAdd = new Beverage();
            //Fields for item
            beverageToAdd.id = id;
            beverageToAdd.name = name;
            beverageToAdd.pack = pack;
            beverageToAdd.price = price;

            //Add the item
            beverageEntity.Beverages.Add(beverageToAdd);
            WineItemsLength++;

            beverageEntity.SaveChanges();
        }

        //Delete an item
        public void DeleteItem(string id)
        {
            //Find the item
            Beverage beverageToDelete = beverageEntity.Beverages.Where(b => b.id == id).First();
            //Delete the item
            beverageEntity.Beverages.Remove(beverageToDelete);

            WineItemsLength--;

            beverageEntity.SaveChanges();
        }

        //Update an item
        public void UpdateItem(string id, string name, string pack, decimal price)
        {
            //Find the item
            Beverage beverageToUpdate = beverageEntity.Beverages.Where(b => b.id == id).First();
            //Update fields
            beverageToUpdate.name = name;
            beverageToUpdate.pack = pack;
            beverageToUpdate.price = price;

            beverageEntity.SaveChanges();
        }
        
        //Get The Print String Array For All Items
        public string[] GetPrintStringsForAllItems(int collectionSize)
        {
            //Create and array to hold all of the printed strings
            string[] allItemStrings = new string[collectionSize];
            WineItemsLength = 0;
            //set a counter to be used
            int counter = 0;

            //If the wineItemsLength is greater than 0, create the array of strings
            if (collectionSize > 0)
            {
                //For each item in the collection
                foreach (Beverage beverage in beverageEntity.Beverages)
                {
                    //if the current item is not null.
                    if (beverage != null)
                    {
                        //Add the results of calling ToString on the item to the string array.
                        allItemStrings[counter] = beverage.ToString();
                        WineItemsLength++;
                        counter++;
                    }
                }
            }
            //Return the array of item strings
            return allItemStrings;
        }

        //Find an item by it's Id
        public string FindById(string id)
        {
            //Declare return string for the possible found item
            string returnString = null;

            try
            {
                //Find the beverage
                Beverage beverage = beverageEntity.Beverages.Where(b => b.id == id).First();
                returnString = beverage.ToString();
                return returnString;
            }
            catch
            {
                return returnString;
            }
            
            //Return the returnString
            
        }

    }
}
