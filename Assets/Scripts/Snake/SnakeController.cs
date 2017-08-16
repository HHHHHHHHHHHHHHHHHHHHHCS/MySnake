using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeController : MonoBehaviour
{
    private static SnakeNode prefab_snakeHead;
    private static SnakeNode prefab_snakeNode;

    public List<SnakeNode> NodeList
    {
        get;
        private set;
    }

    private float walkSpeed = 20f;
    private float runSpeed = 30f;


    public static SnakeController CreateSnake()
    {
        if (!prefab_snakeHead)
        {
            prefab_snakeHead = Resources.Load<SnakeNode>(PrefabsName.snakeHead);
        }
        if (!prefab_snakeNode)
        {
            prefab_snakeNode = Resources.Load<SnakeNode>(PrefabsName.snakeNode);
        }

        var snakeCtrl = new GameObject("MySnake" + Random.Range(0, 10000)).AddComponent<SnakeController>();
        if (snakeCtrl.NodeList == null)
        {
            snakeCtrl.NodeList = new List<SnakeNode>();
        }

        var head = Instantiate(prefab_snakeHead, snakeCtrl.transform);
        float dir = Random.Range(-180, 180);
        head.transform.localEulerAngles = new Vector3(0, 0, dir);
        head.Init();
        snakeCtrl.NodeList.Add(head);

        for (int i = 0; i < 11; i++)
        {
            snakeCtrl.CreateNode();
        }

        return snakeCtrl;
    }


    public void CreateNode()
    {
        if (!prefab_snakeNode)
        {
            prefab_snakeNode = Resources.Load<SnakeNode>(PrefabsName.snakeNode);
        }

        var node = Instantiate(prefab_snakeNode, transform);
        node.transform.localPosition = NodeList[NodeList.Count - 1].GetQuePos();
        node.transform.localEulerAngles = NodeList[NodeList.Count - 1].GetQueRot();

        node.Init();
        NodeList.Add(node);
    }

    private void Update()
    {
        Walk();
    }

    private void Walk()
    {
        if (NodeList != null)
        {
            for (int i = 0; i < NodeList.Count; i++)
            {
                if (i == 0)
                {
                    NodeList[0].transform.localPosition += NodeList[0].transform.up * walkSpeed * Time.deltaTime;
                }
                else
                {
                    NodeList[i].UpdatePosRot(NodeList[i - 1].GetQuePosRot());
                }
                NodeList[i].AddSelfPosRot();
            }
        }

    }
}
