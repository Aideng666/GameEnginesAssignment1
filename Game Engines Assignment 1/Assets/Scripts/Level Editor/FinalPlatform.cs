using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalPlatform : Platform
{
    public int Type => 0;
    public Vector3 Position { get { return position; } set { position = value; } }
    public Transform Platform { get; set; }

    Vector3 position;

    public FinalPlatform(Vector3 position, Transform platform)
    {
        this.position = position;
        this.Platform = platform;

        this.Position = position;
    }

    public void Spawn()
    {
        PlatformPlacer.PlacePlatform(position, Platform);
    }

    public void Undo()
    {
        PlatformPlacer.RemovePlatform(position);
    }
    public override string ToString()
    {
        return "FinalPlatform:" + position.x + ":" + position.y + ":" + position.z;
    }

}
