using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Box : MonoBehaviour
{
    public PositionTrigger position;

	public Sprite[] sprites;

	public int currentItems;

	public int currentScore;

	public int minItems;
	
	public int minScore;
	
	public int maxScore;
    public string nextLevel;
    public GameObject feedBackBox;
    public string[] messages;
    [Header("Assign")]
    public Image imgB;

    public AudioClip sigh, whistle;
    AudioSource s;
	// Use this for initialization
	void Start () 
	{
		
        feedBackBox = GameObject.Find("FeedBackBox");
        s = GetComponent<AudioSource>();
        // static stuff
        minItems = GameManager.instance.minItems;
        minScore = GameManager.instance.minScore;
        maxScore = GameManager.instance.maxScore;
        imgB.enabled = false;

    }



    // Update is called once per frame
    void Update () 
	{
        currentItems = TheBox.Box.collectables.Count;
        currentScore = TheBox.Box.score;
        minItems = GameManager.instance.minItems;
        minScore = GameManager.instance.minScore;
        maxScore = GameManager.instance.maxScore;

        if (position.on)
		{	
			//CASE 3
			 if (currentItems >= minItems && currentScore < maxScore&& currentScore >= minScore)
            {
                feedBackBox.SetActive(true);

                // YOU DON'T HAVE THE MAX SCORE, BUT YOU CAN LEAVE
                feedBackBox.transform.GetChild(0).GetComponent<Text>().text = messages[2]; imgB.enabled = false;
                s.clip = sigh;
                if (!co && ObjectHandler.instance.interactionKeyPressed())
                {
                    StartCoroutine(playSound());
                    SceneManager.LoadScene(nextLevel);

                }

            }

            //CASE 4
            else if (currentItems >= minItems && currentScore >= maxScore)
            {
                    feedBackBox.SetActive(true);

                // YOU CAN LEAVE


                    feedBackBox.transform.GetChild(0).GetComponent<Text>().text = messages[3];
                    ObjectHandler.instance.EButton.GetComponent<Image>().enabled = true;
                    s.clip = whistle;
                if (!co && ObjectHandler.instance.interactionKeyPressed())
                {
                    StartCoroutine(playSound());
                    SceneManager.LoadScene(nextLevel);
                }
                

            }
            //CASE 1
            else if (currentItems < minItems)
            {
                // YOU HAVEN'T COLLECTED ENOUGH GOOD ITEMS
                feedBackBox.SetActive(true);
                feedBackBox.transform.GetChild(0).GetComponent<Text>().text = messages[0]; imgB.enabled = false;


            }
            //CASE 2
            else if (currentScore < minScore)
            {
                feedBackBox.SetActive(true);

                // YOU HAVEN'T REACHED THE MINIMUM SCORE
                feedBackBox.transform.GetChild(0).GetComponent<Text>().text = messages[1]; imgB.enabled = false;

            }


        }
        else
        {
            imgB.enabled = false;
            feedBackBox.SetActive(false);

        }


        // ALL THE SPRITES HAVE 40 UNITS
        for (int i = 0; i<sprites.Length; i++)
		{
			if (currentItems == i)
			{
				GetComponent<SpriteRenderer>().sprite = sprites[i];
				break;
			}
		}

//		switch (currentItems)
//		{
//
//			case 0: GetComponent<SpriteRenderer>().sprite = sprites[0]; break;
//			case 1: GetComponent<SpriteRenderer>().sprite = sprites[1]; break;
//			case 2: GetComponent<SpriteRenderer>().sprite = sprites[0]; break;
//			case 3: GetComponent<SpriteRenderer>().sprite = sprites[0]; break;
////			
//				
//		}
	}

    bool co;
    IEnumerator playSound()
    {
        co = true;
        if (!s.isPlaying)
            s.Play();
        yield return new WaitForSeconds(2);
        co = false;

    }
}
