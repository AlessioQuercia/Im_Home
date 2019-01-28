using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
public class ObjectHandler : MonoBehaviour
{

    [Header("Picking up")]
    public List<GameObject> pickables = new List<GameObject>();
    public float range;
    public bool inRange;
    public Vector2 charTemp, temp2;
    public Pickable objectInRange;
    [Header("Picking up")]
    public GameObject descriptionBox;
     public GameObject EButton;
     string[] interactionKeys = { "q","e", "r", "f", "g", "n" , "k", "c", "h","space","enter" };

    public static ObjectHandler instance;
    // Start is called before the first frame update
    void Awake()
    {
        pickables = GameObject.FindGameObjectsWithTag("Pickable").ToList();
        descriptionBox = GameObject.Find("DB");
        descriptionBox.SetActive(false);
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        charTemp = transform.position;
        
        for(int i =0;i<pickables.Count;i++)
        {
            temp2 = pickables[i].transform.position;
            inRange = Vector2.Distance(charTemp, temp2) < range;
            if (inRange)
                objectInRange = pickables[i].GetComponent<Pickable>() ;

        }

        if (objectInRange && Vector2.Distance(objectInRange.transform.position, charTemp) < range)
            inRange = true;
       // dependent on the inRange boolean
            HandleOutline(inRange);
            ShowDescription();

        if(interactionKeyPressed() && inRange && !objectInRange.thisObject.picked)
            Pickup();
        else if (interactionKeyPressed() && inRange && objectInRange.thisObject.picked)
            TakeBack();

    }

    void HandleOutline(bool n) {
        
        if (!objectInRange) return;
        SpriteOutline c = objectInRange.GetComponent<SpriteOutline>();
        if (n&&c.outlineSize<15)c.outlineSize++; if(!n &&c.outlineSize>0)c.outlineSize--;

        if (objectInRange.thisObject.picked)
        {
            c.outlineSize = 0; return;
        }
    }

    void ShowDescription()
    {
        descriptionBox.SetActive(inRange&&!objectInRange.thisObject.picked);
        if(inRange)
        descriptionBox.transform.GetChild(0).GetComponent<Text>().text = objectInRange.GetComponent<Pickable>().thisObject.description;
    }

    void Pickup()
    {
        if (TheBox.Box.collectables.Count < GameManager.instance.maxCarriableItems)
        {
            objectInRange.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, .3f);
            objectInRange.thisObject.picked = true;
            TheBox.Box.AddAnObject(objectInRange);
        }
    }

    void TakeBack()
    {
        objectInRange.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1f);
        objectInRange.thisObject.picked = false;
        TheBox.Box.TakeBakcAnObject(objectInRange);
                descriptionBox.SetActive(false);

    }

    public bool interactionKeyPressed()
    {
        bool v = false;
        for(int i =0;i<interactionKeys.Length;i++)
        {
            if (Input.GetKeyDown(interactionKeys[i])) v = true;
        }
        return v;
    }
}
