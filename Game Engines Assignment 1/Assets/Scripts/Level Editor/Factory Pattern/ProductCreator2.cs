using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Concrete Creator

public class ProductCreator2 : Creator
{
    public override IFactory CreateProduct()
    {
        return new Product2();
    }
}