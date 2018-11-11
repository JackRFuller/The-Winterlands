using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public static GameManager Instance
    {
        get
        {
            return instance;
        }
    }

    //Managers
    private TimeManager timeManager;


    [SerializeField]
    private PlayerView playerView;
    [SerializeField]
    private CameraView cameraView;

    public PlayerView PlayerView
    {
        get
        {
            return playerView;
        }
    }
    public CameraView CameraView
    {
        get
        {
            return cameraView;
        }
    }
    public TimeManager TimeManager
    {
        get
        {
            return timeManager;
        }
    }
   
    private GameState gameState = GameState.Playing;
    private enum GameState
    {
        Frozen,
        Playing,
    }

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        timeManager = GetComponent<TimeManager>();
    }

    public void ToggleGameState()
    {
        switch(gameState)
        {
            case GameState.Playing:
                FreezeGame();
                break;

            case GameState.Frozen:
                UnFreezeGame();              
                break;
        }
    }

    public void FreezeGame()
    {
        Time.timeScale = 0;
        gameState = GameState.Frozen;
        Debug.Log("Freeze Game");
    }

    public void UnFreezeGame()
    {
        Time.timeScale = 1;
        gameState = GameState.Playing;
        Debug.Log("Unfreeze Game");
    }
}
