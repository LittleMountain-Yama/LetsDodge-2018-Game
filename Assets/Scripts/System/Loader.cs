using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Loader : MonoBehaviour
{
    public GameObject player;
    public GameObject boss;

    private void Awake()
    {
        player = GameObject.Find("Player");
        boss = GameObject.Find("Boss");        
    }
    public void GoToMenu()
    {
        SceneManager.LoadScene("Menu");
    }
    public void GoToCredits()
    {
        SceneManager.LoadScene("Credits");
    }
    public void GoToSelect()
    {
        SceneManager.LoadScene("Select");
    }
    public void GoToLvl1()
    {
        SceneManager.LoadScene("Level 1");
    }
    public void GoToBoss()
    {
        SceneManager.LoadScene("Boss");
    }        
    public void Exit()

    {
        Application.Quit();
    }
}
