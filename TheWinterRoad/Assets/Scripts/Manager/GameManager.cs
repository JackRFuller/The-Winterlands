using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
}
