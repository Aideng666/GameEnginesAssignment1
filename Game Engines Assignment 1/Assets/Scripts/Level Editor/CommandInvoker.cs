using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandInvoker : MonoBehaviour
{
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
            Debug.Log("Platform history length: " + platformHistory.Count);
        }
        //else
        //{
        //    if (Input.GetKeyDown(KeyCode.Z))
        //    {
        //        if (counter > 0)
        //        {
        //            counter--;
        //            platformHistory[counter].Undo();
        //        }
        //    }
        //    else if (Input.GetKeyDown(KeyCode.R))
        //    {
        //        if (counter < platformHistory.Count)
        //        {
        //            platformHistory[counter].Spawn();
        //            counter++;
        //        }
        //    }
        //}
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
        }
    }

    public void RedoCommand()
    {
        if (counter < platformHistory.Count)
        {
            platformHistory[counter].Spawn();
            counter++;
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


    //public void UndoCommand()
    //{
    //    if (counter > 0)
    //    {
    //        if (Input.GetKeyDown(KeyCode.Z))
    //        {
    //            if (counter > 0)
    //            {
    //                counter--;
    //                platformHistory[counter].Undo();
    //            }
    //        }
    //        else if (Input.GetKeyDown(KeyCode.R))
    //        {
    //            if (counter < platformHistory.Count)
    //            {
    //                platformHistory[counter].Spawn();
    //                counter++;
    //            }
    //        }
    //    }
    //}

    //public void RedoCommand()
    //{
    //    if (counter < commandHistory.Count)
    //    {
    //        commandHistory[counter].Execute();
    //        counter++;
    //    }
    //}
}