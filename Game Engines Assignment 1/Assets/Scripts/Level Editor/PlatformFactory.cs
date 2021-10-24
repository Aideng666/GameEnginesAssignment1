using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Reflection;
using System.Linq;

public class PlatformFactory : MonoBehaviour
{
    private Dictionary<int, Type> platformTypeInt;

    public PlatformFactory()
    {
        var platformTypes = Assembly.GetAssembly(typeof(Platform)).GetTypes().Where(myType => myType.IsClass && !myType.IsAbstract && myType.IsSubclassOf(typeof(Platform)));

        platformTypeInt = new Dictionary<int, Type>();

        foreach(var type in platformTypes)
        {
            var tempType = Activator.CreateInstance(type) as Platform;
            platformTypeInt.Add(tempType.Type, type);
        }
    }

    public Platform CreatePlatformType(int type, Vector3 position, Transform platform)
    {
        if (type == 0)
        {
            return new ShortPlatform(position, platform);
        }
        else if (type == 1)
        {
            return new RegularPlatform(position, platform);
        }
        else if (type == 2)
        {
            return new LongPlatform(position, platform);
        }
        else
        {
            return null;
        }
    }
}
