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

            SpawnPlatform(type, platformPosition, scale);

            data = reader.ReadLine();
        }
    }

    void SpawnPlatform(string type, Vector3 pos, Vector3 scale)
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
}
