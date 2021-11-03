using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformPlacer : MonoBehaviour
{
    static List<Transform> platforms;

    public static void PlacePlatform(Vector3 position, Transform platform, Transform parent)
    {
        Transform newPlatform = Instantiate(platform, position, Quaternion.identity, parent);

        if (platforms == null)
        {
            platforms = new List<Transform>();
        }
        platforms.Add(newPlatform);
    }

    public static void RemovePlatform(Vector3 position)
    {
        for (int i = 0; i < platforms.Count; i++)
        {
            if (platforms[i].position == position)
            {
                GameObject.Destroy(platforms[i].gameObject);
                platforms.RemoveAt(i);
                break;
            }
        }
    }

    public List<Transform> GetPlatformList()
    {
        return platforms;
    }
}
