using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grass : Platform
{
    public int Type => 4;
    public Vector3 Position { get { return position; } set { position = value; } }
    public Transform Platform { get; set; }
    public Transform Parent { get; set; }

    Vector3 position;

    public Grass(Vector3 position, Transform platform, Transform parent = null)
    {
        this.position = position;
        this.Platform = platform;

        this.Position = position;

        this.Parent = parent;
    }

    public void Spawn()
    {
        PlatformPlacer.PlacePlatform(position, Platform, Parent);
    }

    public void Undo()
    {
        PlatformPlacer.RemovePlatform(position);
    }

    public override string ToString()
    {
        return "Grass:" + position.x + ":" + position.y + ":" + position.z + ":" + Platform.localScale.x + ":" + Platform.localScale.y + ":" + Platform.localScale.z;
    }
}
