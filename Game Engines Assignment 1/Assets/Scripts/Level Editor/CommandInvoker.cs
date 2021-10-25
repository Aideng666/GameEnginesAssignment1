using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CommandInvoker : MonoBehaviour
{
    public static event Action clicked;

    static Queue<Platform> platformCommandBuffer;

    static List<Platform> platformHistory;
    static int counter;

    private void Awake()
    {
        platformCommandBuffer = new Queue<Platform>();
        platformHistory = new List<Platform>();
    }

    public static void AddCommand(Platform command)
    {
        while (platformHistory.Count > counter)
        {
            platformHistory.RemoveAt(counter);
        }

        platformCommandBuffer.Enqueue(command);
    }

    // Update is called once per frame
    void Update()
    {
        if (platformCommandBuffer.Count > 0)
        {
            Platform c = platformCommandBuffer.Dequeue();
            c.Spawn();

            platformHistory.Add(c);
            counter++;
            //Debug.Log("Platform history length: " + platformHistory.Count);
        }
    }

    private void OnEnable()
    {
        UndoCommand();
        RedoCommand();
    }

    public void UndoCommand()
    {
        if (counter > 0)
        {
            counter--;
            platformHistory[counter].Undo();
            clicked?.Invoke();
        }

        
    }

    public void RedoCommand()
    {
        if (counter < platformHistory.Count)
        {
            platformHistory[counter].Spawn();
            counter++;
            clicked?.Invoke();
        }

        
    }

    public List<Platform> GetHistory()
    {
        return platformHistory;
    }

    public void SetHistory(List<Platform> newHistory)
    {
        platformHistory = newHistory;
    }
}