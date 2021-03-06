﻿//Author: Andrejs Tomsons
//CIS 237
//Assignment 5
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment1
{
    class UserInterface
    {
        const int maxMenuChoice = 5;
        //---------------------------------------------------
        //Public Methods
        //---------------------------------------------------

        //Display Welcome Greeting
        public void DisplayWelcomeGreeting()
        {
            Console.WriteLine("Welcome to the wine program");
        }

        //Display Menu And Get Response
        public int DisplayMenuAndGetResponse()
        {
            //declare variable to hold the selection
            string selection;

            //Display menu, and prompt
            this.displayMenu();
            this.displayPrompt();

            //Get the selection they enter
            selection = this.getSelection();

            //While the response is not valid
            while (!this.verifySelectionIsValid(selection))
            {
                //display error message
                this.displayErrorMessage();

                //display the prompt again
                this.displayPrompt();

                //get the selection again
                selection = this.getSelection();
            }
            //Return the selection casted to an integer
            return Int32.Parse(selection);
        }

        //Get the search query from the user
        public string GetSearchQuery()
        {
            Console.WriteLine();
            Console.WriteLine("What would you like to search for?");
            Console.Write("> ");
            return Console.ReadLine();
        }

        //Get New Item Information From The User.
        public string[] GetNewItemInformation()
        {
            Console.WriteLine();
            Console.WriteLine("What is the new items Id?");
            Console.Write("> ");
            string id = Console.ReadLine();
            Console.WriteLine("What is the new items Name?");
            Console.Write("> ");
            string name = Console.ReadLine();
            Console.WriteLine("What is the new items Pack?");
            Console.Write("> ");
            string pack = Console.ReadLine();
            Console.WriteLine("What is the new items Price?");
            Console.Write("> ");
            string price = Console.ReadLine();

            return new string[] { id, name, pack, price };
        }

        //Get the updated item information from the user
        public string[] GetUpdatedItemInformation()
        {
            Console.WriteLine();
            Console.WriteLine("What is the Updated items Id?");
            Console.Write("> ");
            string id = Console.ReadLine();
            Console.WriteLine("What is the Updated items Name?");
            Console.Write("> ");
            string name = Console.ReadLine();
            Console.WriteLine("What is the Updated items Pack?");
            Console.Write("> ");
            string pack = Console.ReadLine();
            Console.WriteLine("What is the Updated items Price?");
            Console.Write("> ");
            string price = Console.ReadLine();

            return new string[] { id, name, pack, price };
        }

        //Display Import Success
        public void DisplayImportSuccess()
        {
            Console.WriteLine();
            Console.WriteLine("Wine List Has Been Imported Successfully");
        }

        //Display Import Error
        public void DisplayImportError()
        {
            Console.WriteLine();
            Console.WriteLine("There was an error importing the CSV");
        }

        //Display All Items
        public void DisplayAllItems(string[] allItemsOutput, int length)
        {
            Console.WriteLine();
            for (int i = 0; i < length; i++ )
            {
                Console.WriteLine(allItemsOutput[i]);
            }
        }

        //Display All Items Error
        public void DisplayAllItemsError()
        {
            Console.WriteLine();
            Console.WriteLine("There are no items in the list to print");
        }

        //Display Item Found Success
        public void DisplayItemFound(string itemInformation)
        {
            Console.WriteLine();
            Console.WriteLine("Item Found!");
            Console.WriteLine(itemInformation);
        }

        //Display Item Found Error
        public void DisplayItemFoundError()
        {
            Console.WriteLine();
            Console.WriteLine("A Match was not found");
        }

        //Display Add Wine Item Success
        public void DisplayAddWineItemSuccess()
        {
            Console.WriteLine();
            Console.WriteLine("The Item was successfully added");
        }

        //Display Item Already Exists Error
        public void DisplayItemAlreadyExistsError()
        {
            Console.WriteLine();
            Console.WriteLine("An Item With That Id Already Exists");
        }

        //Get the delete information
        public string GetDeleteInformation()
        {
            Console.WriteLine();
            Console.WriteLine("What is the Id of the item you wish to delete?");
            Console.Write("> ");
            string id = Console.ReadLine();

            return id;
        }

        //Display delete success
        public void DisplayDeleteSuccess()
        {
            Console.WriteLine();
            Console.WriteLine("The item was successfully deleted");
        }

        //display delere error
        public void DisplayDeleteError()
        {
            Console.WriteLine();
            Console.WriteLine("The item was not deleted because it does not exist");
        }

        //display update success
        public void DisplayUpdateSuccess()
        {
            Console.WriteLine();
            Console.WriteLine("The item has been updated");
        }

        //Displat update error
        public void DisplayUpdateError()
        {
            Console.WriteLine();
            Console.WriteLine("The item has not been updated because it does not exist");
        }


        //---------------------------------------------------
        //Private Methods
        //---------------------------------------------------

        //Display the Menu
        private void displayMenu()
        {
            Console.WriteLine();
            Console.WriteLine("What would you like to do?");
            Console.WriteLine();
            Console.WriteLine("1. Print The Entire List Of Items");
            Console.WriteLine("2. Search For An Item");
            Console.WriteLine("3. Add New Item To The List");
            Console.WriteLine("4. Delete an item");
            Console.WriteLine("5. Update an item");
            Console.WriteLine("6. Exit Program");
        }

        //Display the Prompt
        private void displayPrompt()
        {
            Console.WriteLine();
            Console.Write("Enter Your Choice: ");
        }

        //Display the Error Message
        private void displayErrorMessage()
        {
            Console.WriteLine();
            Console.WriteLine("That is not a valid option. Please make a valid choice");
        }

        //Get the selection from the user
        private string getSelection()
        {
            return Console.ReadLine();
        }

        //Verify that a selection from the main menu is valid
        private bool verifySelectionIsValid(string selection)
        {
            //Declare a returnValue and set it to false
            bool returnValue = false;

            try
            {
                //Parse the selection into a choice variable
                int choice = Int32.Parse(selection);

                //If the choice is between 0 and the maxMenuChoice
                if (choice > 0 && choice <= maxMenuChoice)
                {
                    //set the return value to true
                    returnValue = true;
                }
            }
            //If the selection is not a valid number, this exception will be thrown
            catch (Exception e)
            {
                //set return value to false even though it should already be false
                returnValue = false;
            }

            //Return the reutrnValue
            return returnValue;
        }
    }
}
