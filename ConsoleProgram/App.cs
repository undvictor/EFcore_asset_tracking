using System;
using System.Collections.Generic;
using System.Linq;
using EFassets.Data;
using EFassets.Domains;

namespace ConsoleProgram
{
    public class App
    {
        /*
         * I'LL DO SOME FUNCTIONS HERE THAT WE CAN DECOUPLE WHEN WE'RE WORKING AGILE
         * 
         * Create Console Menu
         * Convert Currency
         * Get categories, assets and offices.
         * Add -||-
         * Update -||-
         * Delete -||-
         */



        private static readonly AssetContext context = new AssetContext();

        //Constructor
        public App() {

        }

        internal void Start() {
           Menu();
        }

        private void Menu()
        {
            Console.WriteLine("Welcome to our App. As you know Console is the new trend.\n");
            Console.WriteLine("What do you want to do?");
            Console.WriteLine("a) add info");
            Console.WriteLine("d) delete info");
            Console.WriteLine("g) get info");
            Console.WriteLine("u) update info");

            string option = Console.ReadLine();

            switch (option)
            {
                case "a":

                    AddAsset();
                    break;
                case "d":
                    DeleteInfo();
                    break;
                case "g":
                    GetInfo();
                    break;
                case "u":
                    UpdateInfo();
                    break;


                default:
                    Console.WriteLine($"{option} is not a valid option, please try again.");
                    Menu();
                   break;
            }

            /*
                        Console.WriteLine("We're now in App-class");
                        // Lets test the database before expanding
                        GetAssets("Before Add: ");
                        GetAssets("After Add: ");
                        Console.Write("Add a phone operating idunno");
                        AddAsset(Console.ReadLine());
                        GetAssets("After Add: ");

             */
            Console.ReadKey();
        }

        private static void AddAsset()
        {
            Console.WriteLine("Add your Asset: ");
            var asset = new Asset { AssetName = Console.ReadLine()};
            context.Assets.Add(asset);
            context.SaveChanges();

            //let's print the list so we know it went in. a DEV thing
            var assets = context.Assets.ToList();
            foreach (var loopAsset in assets)
            {
                Console.WriteLine($"asset Id {loopAsset.AssetId}   asset name: {loopAsset.AssetName}");
            }
            Console.ReadKey();

        }

        private void DeleteInfo()
        {

            Console.WriteLine("What do you want to delete?");
            Console.WriteLine("a) Asset");
            Console.WriteLine("c) Category ");
            Console.WriteLine("o) Office ");
            Console.WriteLine("__\n");
            //delete statement

        }

        private void UpdateInfo()
        {
            //delete statement

        }

        private static void GetInfo()
        {
            Console.WriteLine("What do you want to get?");
            Console.WriteLine("a) Asset");
            Console.WriteLine("c) Category ");
            Console.WriteLine("o) Office ");
            Console.WriteLine("__\n");

            //specify what you want, convert to lowercase and trim the string
            string whatToGet = Console.ReadLine().ToLower().Trim();


            //and if you want a list or specific item
            Console.WriteLine("Do you want to get a List of products or get one item?");
            Console.WriteLine("L) List");
            Console.WriteLine("S) Specific");
            string listOrSpecific = Console.ReadLine().ToLower().Trim();


            string caseToGet = "";
            //switch-statement for the options
            switch (whatToGet)
            {
                case "a":
                    caseToGet = "asset";
                    break;
                case "c":
                    caseToGet = "category";
                    break;
                case "o":
                    caseToGet = "office";
                    break;
                default:
                    Console.WriteLine($"'{caseToGet}' is not really a valid value, do it again. I believe in you <3");
                    break;
            }


            // get a list or specific

            //lets do a switch on the list vs specific too in this method. 
            //maybe it's better to use polyformism but I dont feel like challenging the framework            
            
            
            switch (listOrSpecific)
            {
                //print out the list
                case "l":
                    var assets = context.Assets.ToList();
                    foreach (var asset in assets)
                    {
                        Console.WriteLine($"asset Id {asset.AssetId}   asset name: {asset.AssetName}");
                    }
                    break;
                case "s":
                    //Linq-method for that...
                    break;

                default:
                    Console.WriteLine($"{listOrSpecific} is not a valid option, please try again");
                    break;
            }

        }



    }
}
