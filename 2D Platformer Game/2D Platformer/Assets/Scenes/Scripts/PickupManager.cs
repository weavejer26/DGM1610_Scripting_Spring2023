using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PickupManager : MonoBehaviour
{
    public int pickup; //Store score value
    public TextMeshProUGUI pickupText; //Reference visual text UI element to change
    
    public void IncreasePickup(int amount)
    {
        pickup += amount; //Add amount to the score
        UpdatePickupText(); //Update the score UI text
    }
      public void UpdatePickupText()
    {
        pickupText.text = "Pickup: "+ pickup;
    }

}
