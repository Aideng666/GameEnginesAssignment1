using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Creator : MonoBehaviour
{ 
    public abstract IFactory FactoryMethod();

    public string SomeOperation()
    {
        var product = FactoryMethod();

        var result = "Creator: The same creator's code has just worked with " + product.Operation();

        return result;
    }
}
