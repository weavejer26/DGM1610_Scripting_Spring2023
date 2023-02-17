using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpCollisions : MonoBehaviour
{
    void OnTriggerEnter(Collider other) 
    {
       if(other.gameObject.CompareTag("Pick Up"))
       {
            Destroy(gameObject); //Destroy this game Object (PickUp)
       }
    }
}
