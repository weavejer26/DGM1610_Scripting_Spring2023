using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeBase : MonoBehaviour
{
    private GameManager gm;
    private Renderer flagRend;
    
    
    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        flagRend = GameObject.Find("HomeFlag").GetComponent<Renderer>();

        flagRend.enabled = false; //Hide Flag
    }

    void OnTriggerEnter(Collider other) 
    {
        if(other.CompareTag("Player") && gm.hasFlag)
        {
            Debug.Log("Player has reached homebase!");
            //gm.PlaceFlag(); //Run Place flag function in GameManager
            flagRend.enabled = true; //Make flag visible
        }
    }
}
