using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutofBounds : MonoBehaviour
{
    public float topBounds = 60.0f;
    public float lowerBounds = -10.0f;
    public ScoreManager scoreManager; //Reference the score manager so that we can update the score
    private DetectCollisions detectCollisions;

    //Start is called before the first frame update
    void Start() 
    {
        scoreManager = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
        detectCollisions = GetComponent<DetectCollisions>();
    }
    
    // Update is called once per frame
    void Update()
    {
     if(transform.position.z > topBounds)
     {
        Destroy(gameObject);
     }
     
     else if(transform.position.z < lowerBounds)
     {
        scoreManager.DecreaseScore(detectCollisions.scoreToGive); //Everytime a UFO sneaks past the lower bounds deduct points
        Destroy(gameObject);
     }
    }
}
