using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheBox : MonoBehaviour
{

    public List<Pickable> collectables = new List<Pickable>();
    public int score;
    public static TheBox Box;

    private void Start()
    {
        Box = this;
    }
    public void AddAnObject(Pickable p)
    {
        collectables.Add(p);
        score += p.thisObject.points;
       // GameManager.instance.UpdateSaturation(p.thisObject.points);
        // change color
    }

    public void TakeBakcAnObject(Pickable p)
    {
        collectables.Remove(p);
        score -= p.thisObject.points;
        // change color
        //GameManager.instance.UpdateSaturation(score);
        


    }

}
