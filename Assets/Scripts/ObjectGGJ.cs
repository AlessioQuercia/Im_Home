using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ObjectGGJ 
{
    public string name,description;
    public int points;
    public enum RelationShip {Bad,Good,BitterSweet};
    public RelationShip relation;
    public bool picked;

    public void BitterSweet(int min,int max)
    {
        if (relation == RelationShip.BitterSweet)
        points = Random.Range(min, max);
    }
}
