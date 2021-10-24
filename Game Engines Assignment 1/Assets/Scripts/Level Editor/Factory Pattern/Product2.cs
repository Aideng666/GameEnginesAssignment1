using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Concrete Product

public class Product2 : IFactory
{
    public string Operation()
    {
        return "Product 2 is a large platform";

    }
}
