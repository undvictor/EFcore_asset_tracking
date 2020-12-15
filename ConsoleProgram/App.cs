using System;
using System.Collections.Generic;
using System.Linq;
using EFassets.Data;
using EFassets.Domains;
using Microsoft.EntityFrameworkCore;

namespace ConsoleProgram
{
    public class App
    {
        static readonly AssetContext context = new AssetContext();

        public void Start() {
            Console.Clear();
            Menu();
        }
        private void Menu()
        {
            Console.WriteLine("Welcome to our App. As you know Console is the new trend.\n");
            Console.WriteLine("What do you want to do?");
            Console.WriteLine("g) get info");
            Console.WriteLine("a) add info");
            Console.WriteLine("u) update info");
            Console.WriteLine("d) delete info");

            string option = Console.ReadLine().ToLower();

            switch (option)
            {
                case "a":
                    AddWithCategory();
                    break;
                case "d":
                    DeleteInfo();
                    break;
                case "g":
                    PrintList();
                    break;
                case "u":
                    UpdateInfo();
                    break;
                default:
                    Console.WriteLine($"{option} is not a valid option, please try again.");
                    Menu();
                   break;
            } 
            Console.ReadKey();
        }
        private static void PrintList()
        {
            //Join Categories-table with Asset-table
            var categoriesWithAssets = context.Assets
                .Where(a => a.CategoryObject != null)
                .Select(a => new { Category = a.CategoryObject, Asset = a })
                .ToList();
            //print the info
            foreach (var asset in categoriesWithAssets)
            {
                Console.WriteLine($" Asset ID {asset.Asset.AssetId} | Asset name {asset.Asset.AssetName} | Asset Price {asset.Asset.price}" +
                    $"\n AssetModel: {asset.Asset.AssetModel} | Categoryname: {asset.Category.CategoryName}" +
                    $"\n Date Bought {asset.Asset.purchaseDate} | Expirationdate {asset.Asset.expirationDate} \n " +
                    $"_______________________________________________________" +
                    $"\n");
            }
        }
        private void AddWithCategory() {

            //Get the info, user assigns the values
            Console.WriteLine("Name of Asset: ");
            var assetName = Console.ReadLine();
            Console.WriteLine("Model of Asset: ");
            var assetModel = Console.ReadLine();
            Console.WriteLine("Category of Asset: ");
            var assetCategory = Console.ReadLine();
            Console.WriteLine("Price of Asset: ");
            float assetPrice = float.Parse(Console.ReadLine());

            //create an asset-object
            var asset = new Asset {
                AssetName = assetName,
                AssetModel = assetModel,
                CategoryObject = new Category { CategoryName = assetCategory},
                price = assetPrice,
                //purchaseDate = ,
                //expirationDate = 2 ,   
                
            };
            //type it out
            Console.WriteLine(asset.AssetName + asset.AssetModel + asset.CategoryObject.CategoryName +  asset.price);

            //add it to the database
            context.Add(asset);
            context.SaveChanges();
            PrintList();
            Console.ReadKey();
            Start();
        }
        private void DeleteInfo()
        {
            PrintList();
            Console.WriteLine("which would you like to delete? \n");

            int whichI = int.Parse(Console.ReadLine());
            var asset = context.Assets.Include(s => s.CategoryObject).FirstOrDefault(s => s.AssetId == whichI);

            context.Assets.Remove(asset);
            context.SaveChanges();
            
            Console.WriteLine("deleted");
            Console.ReadKey();
            Start();
        }
        private void UpdateInfo()
        {
            PrintList();

            Console.WriteLine("which would you like to edit? \n");              
            int whichI = int.Parse(Console.ReadLine());                

            var asset = context.Assets.Include(s => s.CategoryObject).FirstOrDefault(s => s.AssetId == whichI);

            Console.WriteLine("\n\n\n\n");
            Console.WriteLine(($"a) Assetname {asset.AssetName}     b) Asset Model {asset.AssetModel}     c) Price {asset.price}     d) Category Name {asset.CategoryObject.CategoryName}"));
            Console.WriteLine("\nwhat would you like to edit? \n");
            Console.WriteLine("A)Name     B) Model     C) Price     D) Category");
            
            string choice = Console.ReadLine().ToLower();            
            Console.WriteLine("Type new Value: ");
            string newValue = Console.ReadLine();
            switch (choice) { 
                case "a":
                    asset.AssetName = newValue;
                    break;
                case "b":
                    asset.AssetModel = newValue;
                    break;
                case "c":
                    asset.price = float.Parse(newValue);
                    break;
                case "d":
                    asset.CategoryObject.CategoryName = newValue;
                    break;
                default:
                    break;                    
            }
            context.Update(asset);
            context.SaveChanges();
            Console.ReadKey();
            Start();
        }      
    }
}

