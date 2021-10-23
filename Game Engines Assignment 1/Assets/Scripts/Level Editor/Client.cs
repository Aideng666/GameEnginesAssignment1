using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Client : MonoBehaviour
{
    public void Main()
    {
        Debug.Log("App: Launched with the ProductCreator1");
        ClientCode(new ProductCreator1());

        Debug.Log("App: Launched with the ProductCreator2");
        ClientCode(new ProductCreator2());
    }

    public void ClientCode(Creator creator)
    {
        Debug.Log("Client: I'm not aware of the creator's class, " + "but it still works.\n" + creator.SomeOperation());
    }

    public void ButtonEvent()
    {
        new Client().Main();
    }
}
