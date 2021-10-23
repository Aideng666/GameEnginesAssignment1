using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Creator : MonoBehaviour
{ 
    public abstract IFactory CreateProduct();

    public string SomeOperation()
    {
        var product = CreateProduct();

        var result = product.Operation();

        return result;
    }
}
