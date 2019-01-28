using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{

    public string scene;
    string[] interactionKeys = { "q", "e", "r", "f", "g", "n", "k", "c", "h", "space", "enter" };

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (interactionKeyPressed())
            SceneManager.LoadScene(scene);
    }
    public bool interactionKeyPressed()
    {
        bool v = false;
        for (int i = 0; i < interactionKeys.Length; i++)
        {
            if (Input.GetKeyDown(interactionKeys[i])) v = true;
        }
        return v;
    }
}
