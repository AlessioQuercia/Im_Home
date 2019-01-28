using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ButtonAnim : MonoBehaviour
{
    Image img;
    public Sprite s1, s2;
    public bool running= false;
    // Start is called before the first frame update
    void OnEnable()
    {
        img = gameObject.GetComponent<Image>();
        img.sprite = s1;
    }

     void Update()
    {
        if(!running)
        StartCoroutine(Animate());

    }

    IEnumerator Animate()
    {
        running = true;
        yield return new WaitForSeconds(.7f);
        if (img.sprite == s1) img.sprite = s2;
        else img.sprite = s1;
        running = false;
    }

    
}
