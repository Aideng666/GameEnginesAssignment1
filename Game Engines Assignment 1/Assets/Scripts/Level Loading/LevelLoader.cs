using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    [SerializeField] List<Transform> platformPrefabs;
    [SerializeField] Transform grassPrefab;
    [SerializeField] Transform platformParent;

    List<Platform> platforms;
    StreamReader reader;
    string data;

    PlatformFactory factory;

    void Start()
    {
        LoadData();
        platforms = new List<Platform>();
        factory = new PlatformFactory();
    }

    public void LoadData()
    {
        reader = new StreamReader(Application.dataPath + "/levelsave.txt");

        data = reader.ReadLine();

        while(data != null)
        {
            string[] platformData = data.Split(':');

            string type = platformData[0];

            Vector3 platformPosition = new Vector3(float.Parse(platformData[1]), float.Parse(platformData[2]), float.Parse(platformData[3]));

            Vector3 scale = new Vector3(float.Parse(platformData[4]), float.Parse(platformData[5]), float.Parse(platformData[6]));

            SavePlatform(type, platformPosition, scale);

            data = reader.ReadLine();
        }

        //LoadLevel();
    }

    void SavePlatform(string type, Vector3 pos, Vector3 scale)
    {
        if (type == "ShortPlatform")
        {
            Instantiate(platformPrefabs[0], pos, Quaternion.identity);
        }

        if (type == "RegularPlatform")
        {
            Instantiate(platformPrefabs[1], pos, Quaternion.identity);
        }

        if (type == "LongPlatform")
        {
            Instantiate(platformPrefabs[2], pos, Quaternion.identity);
        }

        if (type == "FinalPlatform")
        {
            Instantiate(platformPrefabs[3], pos, Quaternion.identity);
        }

        if (type == "Grass")
        {
            Instantiate(grassPrefab, pos, Quaternion.identity);
        }
    }

    //void LoadLevel()
    //{
    //    for (int i = 0; i < platforms.Count; i++)
    //    {
    //        if (platforms[i].Type == 4)
    //        {
    //            var grass = Instantiate(grassPrefab, platforms[i].Position, Quaternion.identity);
    //            grass.localScale = platforms[i].Platform.localScale;
    //        }
    //        else
    //        {
    //            var plat = Instantiate(platformPrefab, platforms[i].Position, Quaternion.identity);
    //            plat.localScale = platforms[i].Platform.localScale;
    //        }

    //    }
    //}
}
