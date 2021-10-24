using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShortPlatform : Platform
{
    public int Type => 0;

    Vector3 position;
    Transform platform;

    public ShortPlatform(Vector3 position, Transform platform)
    {
        this.position = position;
        this.platform = platform;
    }

    public void Spawn()
    {
        platform.localScale =  new Vector3(1.5f, 1, 1);

        PlatformPlacer.PlacePlatform(position, platform);
    }

    public void Undo()
    {
        PlatformPlacer.RemovePlatform(position);
    }
}
