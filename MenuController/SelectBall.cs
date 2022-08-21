using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectBall : MonoBehaviour
{
    public static SelectBall instance;
    private List<Button> ballButtons = new List<Button>();
    int index;

    private void Start()
    {
        if (instance == null)
            instance = this;
        GetButtonAndAddListner();
    }
    void GetButtonAndAddListner()
    {
        GameObject[] btns = GameObject.FindGameObjectsWithTag("MenuBall");

        for(int i = 0; i< btns.Length; i++)
        {
            ballButtons.Add(btns[i].GetComponent<Button>());
            ballButtons[i].onClick.AddListener(() => BallSelect());
        }
    }
    void BallSelect()
    {
        index = int.Parse(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.transform.name);
    }
    public int ReturnIndex()
    {
        return index;
    }
}
