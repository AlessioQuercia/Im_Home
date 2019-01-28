using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{

    public GameObject credits;
    public string nextlevel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            Credits(false);
    }


    public void Startgame()
    {
        SceneManager.LoadScene(nextlevel);
    }
    public void Credits(bool c)
    {
        credits.SetActive(c);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
