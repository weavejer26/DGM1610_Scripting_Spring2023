using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupController : MonoBehaviour
{
    private PickupManager PickupManager; //A variable to hold the reference to the scoremanager
    public int pickupToGive;
    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if (collision.tag == "Player")
        {
            Destroy(gameObject);  
        }
        PickupManager.IncreasePickup(pickupToGive);
    }
     
     //Start is called before the first frame update
    void Start()
    {
       PickupManager = GameObject.Find("PickupManager").GetComponent<PickupManager>(); //Reference scoremanager
    }
}
