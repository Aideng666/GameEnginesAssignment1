using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacePlatformCommand : ICommand
{
    Vector3 position;
    Transform platform;

    public PlacePlatformCommand(Vector3 position, Transform platform)
    {
        this.position = position;
        this.platform = platform;
    }

    public void Execute()
    {
        PlatformPlacer.PlacePlatform(position, platform);
    }

    public void Undo()
    {
        PlatformPlacer.RemovePlatform(position);
    }
}
