using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Platform
{
    void Spawn();

    void Undo();

    public abstract int Type { get; }
}
