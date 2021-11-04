using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacePlatformCommand : ICommand
{
    Vector3 position;
    Transform platform;
    Transform parent;

    public PlacePlatformCommand(Vector3 position, Transform platform, Transform parent)
    {
        this.position = position;
        this.platform = platform;
        this.parent = parent;
    }

    public void Execute()
    {
        PlatformPlacer.PlacePlatform(position, platform, parent);
    }

    public void Undo()
    {
        PlatformPlacer.RemovePlatform(position);
    }
}
