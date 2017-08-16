using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeNode : MonoBehaviour
{
    private const int markMaxNumber = 51;
    private Queue<Vector3> posRotQue = new Queue<Vector3>();

    public void Init()
    {
        posRotQue = new Queue<Vector3>();
        Vector3 vec3 = EnPosRot();

        for (int i = 0; i < markMaxNumber; i++)
        {
            AddPosRot(vec3);
        }
    }

    public Vector3 GetQuePosRot()
    {
        return posRotQue.Peek();
    }

    public Vector3 GetQuePos()
    {
        return DePos(posRotQue.Peek());
    }

    public Vector3 GetQueRot()
    {
        return DeRot(posRotQue.Peek());
    }

    public void AddSelfPosRot()
    {
        AddPosRot(EnPosRot());
    }

    public void AddPosRot(Vector3 posRot)
    {
        posRotQue.Enqueue(posRot);
        if (posRotQue.Count >= markMaxNumber)
        {
            posRotQue.Dequeue();
        }
    }

    public void UpdatePosRot(Vector3 posRot)
    {
        transform.localPosition = DePos(posRot);
        transform.localEulerAngles = DeRot(posRot);
    }

    Vector3 EnPosRot()
    {
        Vector3 vec3;
        vec3 = transform.localPosition;
        vec3.z = transform.localEulerAngles.z;
        return vec3;
    }

    void DePosRot(Vector3 vec3,out Vector3 pos,out Vector3 rot)
    {
        pos = DePos(vec3);
        rot = DeRot(vec3);
    }

    Vector3 DePos(Vector3 vec3)
    {
        Vector3 pos = vec3;
        pos.z = transform.localPosition.z;
        return pos;
    }

    Vector3 DeRot(Vector3 vec3)
    {
        Vector3 rot = transform.eulerAngles;
        rot.z = vec3.z;
        return rot;
    }
}
