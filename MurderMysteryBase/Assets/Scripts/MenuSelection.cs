﻿using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using Yarn.Unity;
using Yarn.Unity.GameScripts;

//!  Main Menu Class
/*!
 Controls the main menu and loads the new game.
*/

public class MenuSelection : MonoBehaviour
{
    public bool newGame;
    public bool options;
    public bool quit;
    // Use this for initialization

    public DialogueUI dialogueUI;

    private VariableStorage yarnVars;

    void Start()
    {
        dialogueUI = GameObject.FindObjectOfType<DialogueUI>();
        yarnVars = GameObject.Find("DialogueObject").GetComponentInChildren<VariableStorage>();
    }

    void Update()
    {
        if (dialogueUI == null)
        {
            dialogueUI = GameObject.FindObjectOfType<DialogueUI>();
        }
    }

    void OnMouseUp()
    {
        //Currently both options select the map screen, easy to change.
        if (newGame)
        {
			Debug.Log("Button: New Game");
            StartCoroutine(LoadNewGame());
        }
       
        if (options)
        {
			Debug.Log("Button: Options");
            yarnVars.SetValue("NewGameIntroDone", new Yarn.Value(true));
            StartCoroutine(LoadNewGame());
			//SceneManager.LoadScene("optionsScene");
        }
        if (quit)
        {
			Debug.Log("Button: Quit");
            Application.Quit();
        }
    }

    IEnumerator LoadNewGame()
    {
        float fadeTime = GameObject.Find("FadeController").GetComponent<FadeBetweenScreens>().BeginFade(1);
        yield return new WaitForSeconds(fadeTime);
        SceneManager.LoadScene("detectivesOffice");
    }
}