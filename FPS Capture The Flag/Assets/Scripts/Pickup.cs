using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum PickupType
    {
        Health,
        Ammo
    }

public class Pickup : MonoBehaviour
{
    public PickupType type;
    public int healthAmount;
    public int ammoAmount;

    [Header("Bobbing Motion")]
    public float rotationSpeed;
    public float bobSpeed;
    public float bobHeight;
    private bool bobbingUp;
    private Vector3 startPos;
    //Get audio for pickup
    public AudioClip pickupSFX;
    
    // Start is called before the first frame update
    void Start()
    {
       startPos = transform.position;
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            PlayerController player = other.GetComponent<PlayerController>();
            
            switch(type)
            {
                case PickupType.Health:
                player.Givehealth(healthAmount);
                break;

                default:
                print("Type not accepted");
                break;
            }
        //Reference Audio Source to play sound effect
        //other.GetComponent<AudioSource>().PlayOneShot(pickupSFX);

        //Destroy Pickup
        Destroy(gameObject);
        }
    }
    // Update is called once per frame
    void Update()
    {
        //Rotates the pickup around the Y-Axis
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);

        Vector3 offset = (bobbingUp == true ? new Vector3(0, bobHeight / 2, 0): new Vector3(0, -bobHeight / 2, 0));

        transform.position = Vector3.MoveTowards(transform.position, startPos + offset, bobSpeed * Time.deltaTime);
        if(transform.position == startPos + offset)
            {
                bobbingUp = !bobbingUp;
            }
    }
}
