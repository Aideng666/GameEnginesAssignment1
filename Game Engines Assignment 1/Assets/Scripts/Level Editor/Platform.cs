using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Platform
{
    public abstract int Type { get; }
    public abstract Vector3 Position { get; set; }
    public abstract Transform Platform { get; set; }

    void Spawn();

    void Undo();

}
