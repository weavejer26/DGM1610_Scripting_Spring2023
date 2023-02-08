using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balloon : MonoBehaviour
{
    public int clickToPop = 3; // How many clicks before the balloon pops
    public float scaleToIncrease = 0.10f; // Scale increase each time the balloon is clicked
    public ScoreManager scoreManager; //A reference to the score manager
    public int scoretoGive = 100;
    
    
    // Start is called before the first frame update
    void Start()
    {
        //GetScoreManager Component
        scoreManager = GameObject.Find("scoreManager").GetComponent<ScoreManager>();
    }

     void OnMouseDown()
    {
        clickToPop --; //Reduce clicks by one
        //Inflate balloon
        transform.localScale += Vector3.one * scaleToIncrease;
        //Check to see if clickToPop has reached zero. Check to see if the balloon pops.
        if(clickToPop == 0)
        {
            //Tell the scoremanager to increase the score by a certain amount
            scoreManager.IncreaseScoreText(scoretoGive);
            Destroy(gameObject); //Destroy and remove popped balloon
        }

    }
}
