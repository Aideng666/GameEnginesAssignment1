using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformPlacer : MonoBehaviour
{
    static List<Transform> platforms;

    public static void PlacePlatform(Vector3 position, Color color, Transform platform)
    {
        Transform newPlatform = Instantiate(platform, position, Quaternion.identity);
        newPlatform.GetComponentInChildren<MeshRenderer>().material.color = color;
        if (platforms == null)
        {
            platforms = new List<Transform>();
        }
        platforms.Add(newPlatform);
    }

    public static void RemovePlatform(Vector3 position, Color color)
    {
        for (int i = 0; i < platforms.Count; i++)
        {
            if (platforms[i].position == position && platforms[i].GetComponentInChildren<MeshRenderer>().material.color == color)
            {
                GameObject.Destroy(platforms[i].gameObject);
                platforms.RemoveAt(i);
                break;
            }
        }
    }
}
