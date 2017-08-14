using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeNode : MonoBehaviour
{
    private const int markMaxNumber = 51;
    private Queue<Vector3> posQue = new Queue<Vector3>();

    public void Init()
    {
        posQue = new Queue<Vector3>();
        for (int i = 0; i < markMaxNumber; i++)
        {
            AddPos(transform.localPosition);
        }
    }

    public Vector3 GetQuePos()
    {
        return posQue.Peek();
    }

    public void AddSelfPos()
    {
        AddPos(transform.localPosition);
    }

    public void AddPos(Vector3 pos)
    {
        posQue.Enqueue(pos);
        if (posQue.Count >= markMaxNumber)
        {
            posQue.Dequeue();
        }
    }


}
