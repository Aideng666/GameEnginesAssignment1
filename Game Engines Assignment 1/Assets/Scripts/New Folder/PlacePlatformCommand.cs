using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacePlatformCommand : ICommand
{
    Vector3 position;
    Color color;
    Transform platform;

    public PlacePlatformCommand(Vector3 position, Color color, Transform platform)
    {
        this.position = position;
        this.color = color;
        this.platform = platform;
    }

    public void Execute()
    {
        PlatformPlacer.PlacePlatform(position, color, platform);
    }

    public void Undo()
    {
        PlatformPlacer.RemovePlatform(position, color);
    }
}
