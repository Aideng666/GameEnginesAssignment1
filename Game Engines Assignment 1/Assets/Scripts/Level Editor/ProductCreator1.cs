using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProductCreator1 : Creator
{
    public override IFactory FactoryMethod()
    {
        return new Product1();
    }
}
