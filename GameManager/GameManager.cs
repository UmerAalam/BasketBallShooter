using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [SerializeField] BallCreator ballCreator;
    private int index = 0;

    private void Awake()
    {
        MakeSingleton();
        ballCreator = GetComponent<BallCreator>();
    }

    private void MakeSingleton()
    {
        if (instance != null)
        {
          Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    private void OnLevelWasLoaded(int level)
    {
        if(SceneManager.GetActiveScene().name == "Main_Scene")
        {
            CreateBall(SelectBall.instance.ReturnIndex());
        }
    }
    public void CreateBall(int index)
    {
        ballCreator.CreateBall(index);
        SetBallIndex(index);
    }
    public void SetBallIndex(int index)
    {
        this.index = index;
    }
}
