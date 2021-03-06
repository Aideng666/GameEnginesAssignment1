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

    public Platform CreatePlatformType(int type, Vector3 position, Transform platform, bool randomized = false)
    {
        if (type == 0)
        {
            Platform newPlat = new ShortPlatform(position, platform);

            newPlat.Platform.localScale = new Vector3(1.5f, 1, 1);
            if (randomized)
            {
                newPlat.Platform.localScale = FindObjectOfType<RandomScalePlugin>().ApplyRandomScale(newPlat.Platform.localScale);
            }


            return newPlat;
        }
        else if (type == 1)
        {
            Platform newPlat = new RegularPlatform(position, platform);

            newPlat.Platform.localScale = new Vector3(3, 1, 1);

            if (randomized)
            {
                newPlat.Platform.localScale = FindObjectOfType<RandomScalePlugin>().ApplyRandomScale(newPlat.Platform.localScale);
            }

            return newPlat;
        }
        else if (type == 2)
        {
            Platform newPlat = new LongPlatform(position, platform);

            newPlat.Platform.localScale = new Vector3(4.5f, 1, 1);

            if (randomized)
            {
                newPlat.Platform.localScale = FindObjectOfType<RandomScalePlugin>().ApplyRandomScale(newPlat.Platform.localScale);
            }

            return newPlat;
        }
        else
        {
            return null;
        }
    }
}
