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

    private bool dirty_;

    private bool isLevelSaved;
    private void Awake()
    {
        platformCommandBuffer = new Queue<Platform>();
        platformHistory = new List<Platform>();

        dirty_ = false;
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
        }

        if (dirty_)
        {
            List<string> lines = new List<string>();

            foreach (Platform c in platformHistory)
            {
                lines.Add(c.ToString());
            }

            System.IO.File.WriteAllLines(Application.dataPath + "/levelsave.txt", lines);

            print("Save Complete: File Path is Assets/levelsave.txt");

            isLevelSaved = true;

            dirty_ = false;
        }
    }

    public void SetDirty()
    {
        dirty_ = true;

        print("Saving...");
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

    public bool GetLevelSaved()
    {
        return isLevelSaved;
    }
}