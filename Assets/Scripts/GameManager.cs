using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PostProcessing;
public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public PostProcessingBehaviour postProcessingBehaviour;
    public PostProcessingProfile c;

    bool good;
    bool bad;
    public int level, minScore, maxScore,minItems,maxCarriableItems;
    int carriableObjsCount, maxObjs;

    public float satAdd, ExpAdd,targetS,targetE,maxS,maxE,minS,minE;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        var o = c.colorGrading.settings;
        carriableObjsCount = ObjectHandler.instance.pickables.Count;
        ExpAdd = maxE / carriableObjsCount;
        satAdd = maxS / carriableObjsCount;
    }

    // Update is called once per frame
    void Update()
    { 

        // Handle screen coloring.
        var o = c.colorGrading.settings;
        //if (good)
        //{
        // o.basic.saturation += o.basic.saturation < 1  ?  Time.deltaTime : 0;
        // o.basic.postExposure += o.basic.postExposure < 1 ? Time.deltaTime : 0;
        if(o.basic.saturation >= minS - .2f && o.basic.saturation <= maxS +.2f)
        o.basic.saturation = Mathf.Lerp(o.basic.saturation, targetS, Time.deltaTime);

        if (o.basic.postExposure >= minE && o.basic.postExposure <= maxE + .2f)
            o.basic.postExposure = Mathf.Lerp(o.basic.postExposure, targetE, Time.deltaTime);

       

        
        postProcessingBehaviour.profile.colorGrading.settings = o;

        if(TheBox.Box.score >= 0)
        {
            targetS = 1;
            targetE = TheBox.Box.score * ExpAdd;
        }
        else
        {
            targetE = 0;
            targetS =  TheBox.Box.score * satAdd+1;

        }

        if (targetE < minE) targetE = minE;
        if (targetE > maxE) targetE = maxE;
        if (targetS < minS) targetS = minS;
        if (targetS > maxS) targetS = maxS;

        /*
        }
        else
        {
            o.basic.postExposure += o.basic.postExposure >0 ? -Time.deltaTime : 0;
        }
        if (bad)
        {
            o.basic.saturation += o.basic.saturation > .3f ? -Time.deltaTime : 0;
        }
        else
        {
            o.basic.saturation += o.basic.saturation < 1 ? Time.deltaTime : 0;

        }
        postProcessingBehaviour.profile.colorGrading.settings = o;
        */

    }

    public void UpdateSaturation(int score)
    {
        /*
        good = score >= 3;
        bad = score <= -3;

        if (score > -3 && score < 3)
        {
            bad = false;
            good = false;
        }
        */
        //targetS = targetSaturation(score);
        //targetE = targetExposure(score);

        }

    float targetSaturation(float score) // called one time.
    {
        var o = c.colorGrading.settings;
        return c.colorGrading.settings.basic.saturation + score * satAdd;
    }

    float targetExposure(float score) // called one time.
    {
        var o = c.colorGrading.settings;
        return c.colorGrading.settings.basic.saturation + score * ExpAdd;
    }



}
