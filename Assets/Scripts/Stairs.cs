using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stairs : MonoBehaviour
{
	public Transform player;
	
	public PositionTrigger position1;

	public PositionTrigger position2;

	private bool teleported;

	private int coolDown = 0;
	
	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player").transform;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (position1.on && Input.GetKeyDown(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
		{
			player.transform.position = position2.transform.position;
		}

		if (position2.on && Input.GetKeyDown(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
		{	
			player.transform.position = position1.transform.position;
		}
	}

}
