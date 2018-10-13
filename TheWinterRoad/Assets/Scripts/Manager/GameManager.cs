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
    }
}
