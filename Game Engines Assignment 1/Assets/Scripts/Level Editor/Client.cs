using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Client : MonoBehaviour
{
    public void ProductOne()
    {
        Debug.Log("Product 1");
        ClientCode(new ProductCreator1());
    }

    public void ProductTwo()
    {
        Debug.Log("Product 2");
        ClientCode(new ProductCreator2());
    }

    public void ClientCode(Creator creator)
    {
        Debug.Log(creator.SomeOperation());
    }

    public void ButtonEvent1()
    {
        new Client().ProductOne();
    }

    public void ButtonEvent2()
    {
        new Client().ProductTwo();
    }
}
