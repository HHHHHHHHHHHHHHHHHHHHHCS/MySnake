using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Instance_Base<GameManager>
{

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        StartGame();
    }

    public void StartGame()
    {
        MapManager.CreateMap();
        SnakeController.CreateSnake();
    }
}
