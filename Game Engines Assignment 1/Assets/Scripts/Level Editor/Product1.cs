using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Product1 : IFactory
{
    public string Operation()
    {
        return "{Result of Product1}";
    }
}