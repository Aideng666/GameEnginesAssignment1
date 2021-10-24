using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandInvoker : MonoBehaviour
{
    //static Queue<ICommand> commandBuffer;
    static Queue<Platform> platformCommandBuffer;

    //static List<ICommand> commandHistory;
    static List<Platform> platformHistory;
    static int counter;

    private void Awake()
    {
        //commandBuffer = new Queue<ICommand>();
        //commandHistory = new List<ICommand>();

        platformCommandBuffer = new Queue<Platform>();
        platformHistory = new List<Platform>();
    }

    //public static void AddCommand(ICommand command)
    //{
    //    while (commandHistory.Count > counter)
    //    {
    //        commandHistory.RemoveAt(counter);
    //    }

    //    commandBuffer.Enqueue(command);
    //}

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
        //if (commandBuffer.Count > 0)
        //{
        //    ICommand c = commandBuffer.Dequeue();
        //    c.Execute();

        //    commandHistory.Add(c);
        //    counter++;
        //    Debug.Log("Command history length: " + commandHistory.Count);
        //}
        //else
        //{
        //    if (Input.GetKeyDown(KeyCode.Z))
        //    {
        //        if (counter > 0)
        //        {
        //            counter--;
        //            commandHistory[counter].Undo();
        //        }
        //    }
        //    else if (Input.GetKeyDown(KeyCode.R))
        //    {
        //        if (counter < commandHistory.Count)
        //        {
        //            commandHistory[counter].Execute();
        //            counter++;
        //        }
        //    }
        //}

        if (platformCommandBuffer.Count > 0)
        {
            Platform c = platformCommandBuffer.Dequeue();
            c.Spawn();

            platformHistory.Add(c);
            counter++;
            Debug.Log("Platform history length: " + platformHistory.Count);
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Z))
            {
                if (counter > 0)
                {
                    counter--;
                    platformHistory[counter].Undo();
                }
            }
            else if (Input.GetKeyDown(KeyCode.R))
            {
                if (counter < platformHistory.Count)
                {
                    platformHistory[counter].Spawn();
                    counter++;
                }
            }
        }
    }
}
