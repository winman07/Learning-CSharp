using System;
using System.Collections.Generic;

public class MenuItem
{
    string Item {get; set;}
    string Category {get; set;}
    double Price {get; set;}
    string Description {get; set;}

    public MenuItem (string item, string category, double price, string description)
    {
        Item = item;
        Category = category;
        Price = price;
        Description = description;
    }

    public static DateTime
    GetLastWriteTime (string path);

}
