using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegularPlatform : Platform
{
    public int Type => 0;
    public Vector3 Position { get { return position; } set { this.Position = value; } }
    public Transform Platform
    {
        get { return platform; }

        set
        {
            this.Platform = value;
        }
    }

    Vector3 position;
    Transform platform;

    public RegularPlatform(Vector3 position, Transform platform)
    {
        this.position = position;
        this.platform = platform;
    }

    public void Spawn()
    {
        platform.localScale = new Vector3(3, 1, 1);

        PlatformPlacer.PlacePlatform(position, platform);
    }

    public void Undo()
    {
        PlatformPlacer.RemovePlatform(position);
    }
}
