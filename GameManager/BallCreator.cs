using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCreator : MonoBehaviour
{
    [SerializeField] GameObject[] balls;

    private float minX = -4.5f, maxX = 8f, minY = -2.5f, maxY = 1.5f;

    public void CreateBall(int index)
    {
        GameObject gameBall = Instantiate(balls[index],new Vector2(Random.Range(minX,maxX),Random.Range(minY,maxY)),Quaternion.identity) as GameObject;
    }
}
