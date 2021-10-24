using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformProduct1 : IFactory2
{
    public GameObject _prefab;

    public GameObject CreatePlatform()
    {
        return _prefab;
    }
}