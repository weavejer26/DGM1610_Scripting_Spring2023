using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutofBounds : MonoBehaviour
{
    public float topBounds = 60.0f;
    public float lowerBounds = -10.0f;

    
    void Awake()
    {
        //Time.timeScale = 1;
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
            Debug.Log("Game Over!");
            Destroy(gameObject);
            //Time.timeScale = 0;
       }
    }
}
