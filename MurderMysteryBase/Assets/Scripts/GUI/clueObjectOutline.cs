﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class clueObjectOutline : MonoBehaviour {
	
	public int objectNumber; 	//the slot number of clue in inventory
	private Color startcolor;	//initial outline color of cube
	public GameObject Player;	
	public Transform cluePosition;	//Position of the clue object
	public Transform playerPosition; 
	public GameObject clueObject;
	public Canvas interaction;
	public float range = 2;

    private bool mouseIsOver = false;

    void Start()
	{
        startcolor = GetComponent<Renderer>().material.GetColor("_OutlineColor");
        interaction = GameObject.FindGameObjectWithTag("Interaction").GetComponent<Canvas>();
        interaction.enabled = false;
	}

	void Update()
	{
		if(Input.GetKeyDown("e") && Vector3.Distance(playerPosition.position, cluePosition.position) < range ) //if player presses interact hotkey & is in range of clue
		{
			//clueObject.SetActive(false);
			Player.GetComponent<HUD>().slots[objectNumber] = true;
			//interaction.enabled = false;
		}
        if (Vector3.Distance(playerPosition.position, cluePosition.position) < range && mouseIsOver)
        {
            GetComponent<Renderer>().material.SetColor("_OutlineColor", Color.yellow);
            GetComponent<Renderer>().material.SetFloat("_Outline width", 1f);
            interaction.enabled = true;
        }
        else if (Vector3.Distance(playerPosition.position, cluePosition.position) > range && mouseIsOver)
        {
            GetComponent<Renderer>().material.SetColor("_OutlineColor", startcolor);
            GetComponent<Renderer>().material.SetFloat("_Outline width", 0.002f);
            interaction.enabled = false;
        }
    }

	void OnMouseEnter()
	{
        mouseIsOver = true;
    }

	void OnMouseExit()
	 {
        mouseIsOver = false;
        GetComponent<Renderer>().material.SetColor("_OutlineColor", startcolor);
        interaction.enabled = false;
    }
}
