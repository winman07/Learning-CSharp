using System;
using System.Collections.Generic;
using System.IO;

public class MenuItem
{
    public string Item {get; set;}
    public string Category {get; set;}
    public double Price {get; set;}
    public string Description {get; set;}
    public bool NewProduct {get; set;}

    //outline for menu items
    public MenuItem (string item, string category, double price, string description, bool newProduct)
    {
        Item = item;
        Category = category;
        Price = price;
        Description = description;
        NewProduct = newProduct;
    }
}

public class Menu
{
    //create the menu itself
    public Dictionary<string, MenuItem> Items {get; set;}
    public Menu()
    {
        Items = new Dictionary<string, MenuItem>();
    }

    public void AddItem(MenuItem item)
    {
        Items[item.Item] = item;
    }
    public void DisplayMenu()
    {
        foreach (var item in Items.Values)
        {
            string newProductLabel;
            if (item.NewProduct)
            {
                newProductLabel = "(New!)";
            }
            else
            {
                newProductLabel = "";
            }
            Console.WriteLine($"Item: {item.Item} {newProductLabel}, Category: {item.Category}, Price: {item.Price}, Description: {item.Description}");
            Console.WriteLine();
        }
    }
}
class Program
{
    static void Main(string[] args)
    {
        string path = System.Reflection.Assembly.GetExecutingAssembly().Location;

        //display when program was last modified
        Console.WriteLine("Last Updated: " + File.GetLastWriteTime(path));

        //add items to menu
        Menu menu = new Menu();
        menu.AddItem(new MenuItem("Stuffed Jalapenos", "Appetizer", 10.59, "Bacon wrapped jalapenos stuffed with cream cheese and sausage, grilled to perfection", true));
        menu.AddItem(new MenuItem("20oz Ribeye", "Main Dish", 34.99, "A thick cut 20oz Ribeye seasoned with our signature blend, perfectly grilled to your preferred doneness", false));
        menu.AddItem(new MenuItem("Cookie Sundae", "Dessert", 9.79, "A large chocolate chip cookie, baked fresh in house every day, with a scoop of vanilla bean ice cream and chocolate drizzle. Simple yet awesome!", false));
        menu.AddItem(new MenuItem("The LIT", "Cocktails and Brews", 12.99, "Our spin on a Long Island Ice Tea, with all locally sourced liquors", true));

        //Display the menu
        menu.DisplayMenu();
    }
}
