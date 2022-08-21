using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    [SerializeField] Animator menuAnim, ballAnim;

    void Start()
    {
        menuAnim = GameObject.Find("ButtonsPanel").GetComponent<Animator>();
        ballAnim = GameObject.Find("BallSelectHolder").GetComponent<Animator>();
    }
    public void PlayGame()
    {
        SceneManager.LoadScene("Main_Scene");
    }
    public void BallAnimations()
    {
        ballAnim.Play("BallsFadeIn");
        menuAnim.Play("ButtonsFadeIn");
    }
    public void MenuAnimations()
    {
        ballAnim.Play("BallsFadeOut");
        menuAnim.Play("ButtonsFadeOut");
    }

}
