﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ShootBall : MonoBehaviour
{
    public float power = 2.0f;
    public float life = 1.0f;
    public float dead_Sense = 25f;
    public int dots = 30;
    [SerializeField] GameObject Dots;
    private Vector2 startPosition;
    private bool shoot = false, aiming = false, hit_Ground = false;
    private List<GameObject> projectTilesPath;
    private Rigidbody2D myBody;
    private Collider2D myCollider;
    void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
        myCollider = GetComponent<Collider2D>();
    }
    private void Start()
    {
        myBody.isKinematic = true;
        myCollider.enabled = false;
        startPosition = transform.position;
        projectTilesPath = Dots.transform.Cast<Transform>().ToList().ConvertAll(t => t.gameObject);
        for(int i = 0;i < projectTilesPath.Count;i++)
        {
            projectTilesPath[i].GetComponent<SpriteRenderer>().enabled = false;
        }
    }
    private void Update()
    {
        Aim();
    }
    void Aim()
    {
        if (shoot)
            return;
        if(Input.GetAxis("Fire1") == 1)
        {
            if(!aiming)
            {
                aiming = true;
                startPosition = Input.mousePosition;
                CalculatePath();
                ShowPath();
            }
            else
            {
                CalculatePath();
            }
            else if(aiming && !shoot)
            {

            }
        }
    }
    Vector2 GetForce(Vector3 mousePosition)
    {
        return (new Vector2(startPosition.x, startPosition.y) - new Vector2 (mousePosition.x, mousePosition.y)) * power;
    }
    bool inDeadZone(Vector3 mouse)
    {
        return false;
    }
    bool inReleaseZone(Vector3 mouse)
    {
        return false;
    }
    void CalculatePath()
    {
        Vector3 velocity = GetForce(Input.mousePosition) * Time.fixedDeltaTime / myBody.mass; 

        for(int i = 0;i < projectTilesPath.Count;i++)
        {
            projectTilesPath[i].GetComponent<Renderer>().enabled = true;
            float t = i / 30f;
            Vector3 point = PathPoint(transform.position,velocity,t);
            point.z = 1f;
            projectTilesPath[i].transform.position = point;
        }
    }
    Vector2 PathPoint(Vector2 startPos, Vector2 startVelocity, float t)
    {
        return startPos + startVelocity * t * 0.5f * Physics2D.gravity * t * t; 
    }
    void HidePath()
    {
      for (int i = 0; i < projectTilesPath.Count; i++)
      {
            projectTilesPath[i].GetComponent<Renderer>().enabled = false;
      }
    }
    void ShowPath()
    {
      for (int i = 0; i < projectTilesPath.Count; i++)
      {
            projectTilesPath[i].GetComponent<Renderer>().enabled = true;
      }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }
}