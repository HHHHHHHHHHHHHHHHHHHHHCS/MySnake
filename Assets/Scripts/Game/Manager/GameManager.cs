using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Instance_Base<GameManager>
{
    private SnakeController mainPlayer;

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
        mainPlayer = SnakeController.CreateSnake();
    }
}
