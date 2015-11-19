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
    class Program
    {
        static void Main(string[] args)
        {
            //Set a constant for the size of the collection
            const int wineItemCollectionSize = 4000;

            //Create an instance of the UserInterface class
            UserInterface userInterface = new UserInterface();

            //Create an instance of the WineItemCollection class
            WineItemCollection wineItemCollection = new WineItemCollection(wineItemCollectionSize);

            //Display the Welcome Message to the user
            userInterface.DisplayWelcomeGreeting();

            //Display the Menu and get the response. Store the response in the choice integer
            //This is the 'primer' run of displaying and getting.
            int choice = userInterface.DisplayMenuAndGetResponse();

            while (choice != 6)
            {
                switch (choice)
                {
                    case 1:
                        //Print Entire List Of Items
                        string[] allItems = wineItemCollection.GetPrintStringsForAllItems(wineItemCollectionSize);
                        if (allItems.Length > 0)
                        {
                            //Display all of the items
                            userInterface.DisplayAllItems(allItems, wineItemCollection.WineItemsLength);
                        }
                        else
                        {
                            //Display error message for all items
                            userInterface.DisplayAllItemsError();
                        }
                        break;

                    case 2:
                        //Search For An Item
                        string searchQuery = userInterface.GetSearchQuery();
                        string itemInformation = wineItemCollection.FindById(searchQuery);
                        if (itemInformation != null)
                        {
                            //Display the item found
                            userInterface.DisplayItemFound(itemInformation);
                        }
                        else
                        {
                            //Display error message for item found
                            userInterface.DisplayItemFoundError();
                        }
                        break;

                    case 3:
                        //Add A New Item To The List
                        string[] newItemInformation = userInterface.GetNewItemInformation();
                        itemInformation = wineItemCollection.FindById(newItemInformation[0]);
                        if (itemInformation == null)
                        {
                            //Add the item
                            wineItemCollection.AddNewItem(newItemInformation[0], newItemInformation[1], newItemInformation[2], Convert.ToDecimal(newItemInformation[3]));
                            //Display item adding success
                            userInterface.DisplayAddWineItemSuccess();
                        }
                        else
                        {
                            //Display item adding failure
                            userInterface.DisplayItemAlreadyExistsError();
                        }
                        break;

                    case 4:
                        //Delete an item
                        string deleteQuery = userInterface.GetDeleteInformation();
                        itemInformation = wineItemCollection.FindById(deleteQuery);
                        if (itemInformation != null)
                        {
                            //Delete the item
                            wineItemCollection.DeleteItem(deleteQuery);
                            //Display delete success
                            userInterface.DisplayDeleteSuccess();
                        }
                        else
                        {
                            //Display delete error
                            userInterface.DisplayDeleteError();
                        }
                        break;

                    case 5:
                        //Update an item
                        string[] updateItemInformation = userInterface.GetUpdatedItemInformation();
                        itemInformation = wineItemCollection.FindById(updateItemInformation[0]);
                        if (itemInformation != null)
                        {
                            //Update the item
                            wineItemCollection.UpdateItem(updateItemInformation[0], updateItemInformation[1], updateItemInformation[2], Convert.ToDecimal(updateItemInformation[3]));
                            //Display update success
                            userInterface.DisplayUpdateSuccess();
                        }
                        else
                        {
                            //Display update error
                            userInterface.DisplayUpdateError();
                        }
                        break;
                }

                //Get the new choice of what to do from the user
                choice = userInterface.DisplayMenuAndGetResponse();
            }

        }
    }
}
