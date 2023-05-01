using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    
    [Header("Flag Stats")]
    public bool hasFlag;
    public bool flagPlaced;

    public int scoreToWin;
    public int curScore;
    
    public bool gamePaused;

    //Instance
    public static GameManager instance;
    
    void Awake() 
    {
       //Set the instance to this script
       instance = this; 
    }
    
    // Start is called before the first frame update
    void Start()
    {
        //Flag Bools
        hasFlag = false;
        flagPlaced = false;

        Time.timeScale = 1.0f;
    
    }


// Update is called once per frame
    void Update()
    {
        if(flagPlaced)
        {
            WinGame();
        }
        
        if(Input.GetButtonDown("Cancel")) //Esc key pauses game
        {
            TogglePauseGame();
        }
    }
    
    public void TogglePauseGame()
    {
        gamePaused = !gamePaused;
        Time.timeScale = gamePaused == true ? 0.0f : 1.0f;

        //Toggle the pause menu and cursor
        GameUI.instance.TogglePauseMenu(gamePaused);
        Cursor.lockState = gamePaused == true ? CursorLockMode.None : CursorLockMode.Locked;

    }

    public void AddScore(int score)
    {
        curScore += score;

        //Update score text
        GameUI.instance.UpdateScoreText(curScore);

        //Do have enough points to win
        if(curScore >= scoreToWin)
        {
            WinGame();
        }
    }

    void WinGame()
    {
        Debug.Log("You've won the game!");
        //Time.timeScale = 0; //Freeze game

        //Show win screen
        GameUI.instance.SetEndGameScreen(true, curScore);
    }
    public void LoseGame()
    {
        //Load and set end game screen
        GameUI.instance.SetEndGameScreen(false, curScore);
        Time.timeScale = 0.0f;
        gamePaused = true;
    }

    public void PlaceFlag()
    {
        flagPlaced = true;
    }

}
