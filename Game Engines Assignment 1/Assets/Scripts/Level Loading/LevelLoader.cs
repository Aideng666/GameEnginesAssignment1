using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    [SerializeField] Transform platformPrefab;
    [SerializeField] Transform grassPrefab;

    List<Platform> platforms;
    StreamReader reader;
    string data;

    void Start()
    {
        LoadData();
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

            Debug.Log(type + " : " + platformPosition + " : " + scale);

            platforms.Add(SavePlatform(type, platformPosition, scale));

            data = reader.ReadLine();
        }

        //LoadLevel();
    }

    Platform SavePlatform(string type, Vector3 pos, Vector3 scale)
    {
        if (type == "ShortPlatform")
        {
            Platform newPlat = new ShortPlatform(pos, platformPrefab);

            newPlat.Platform.localScale = scale;

            return newPlat;
        }

        if (type == "RegularPlatform")
        {
            Platform newPlat = new RegularPlatform(pos, platformPrefab);

            newPlat.Platform.localScale = scale;

            return newPlat;
        }

        if (type == "LongPlatform")
        {
            Platform newPlat = new LongPlatform(pos, platformPrefab);

            newPlat.Platform.localScale = scale;

            return newPlat;
        }

        if (type == "FinalPlatform")
        {
            Platform newPlat = new FinalPlatform(pos, platformPrefab);

            newPlat.Platform.localScale = scale;

            return newPlat;
        }

        if (type == "Grass")
        {
            Platform newPlat = new Grass(pos, grassPrefab);

            newPlat.Platform.localScale = scale;

            return newPlat;
        }

        return null;
    }

    void LoadLevel()
    {
        for (int i = 0; i < platforms.Count; i++)
        {
            if (platforms[i].Type == 4)
            {
                var grass = Instantiate(grassPrefab, platforms[i].Position, Quaternion.identity);
                grass.localScale = platforms[i].Platform.localScale;
            }
            else
            {
                var plat = Instantiate(platformPrefab, platforms[i].Position, Quaternion.identity);
                plat.localScale = platforms[i].Platform.localScale;
            }

        }
    }
}
