using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class end : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("exit", 5);
    }

    // Update is called once per frame
    void exit()
    {
        Application.Quit();
    }
}
