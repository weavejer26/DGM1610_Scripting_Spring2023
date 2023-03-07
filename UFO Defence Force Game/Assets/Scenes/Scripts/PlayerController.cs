using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float horizontalInput;
    public float speed = 25f;
   
    public float xRange = 30f;

    public Transform blaster;
    public GameObject LaserBolt;
    //Audio Variables
    private AudioSource blasterAudio;
    public AudioClip laserBlast;


    void Start()
    {
        //GetAudioSource Component
        blasterAudio = GetComponent<AudioSource>();
    }
   
    // Update is called once per frame
    void Update()
    {
    // Set horizontalInput to recieve values from keyboard
        horizontalInput = Input.GetAxis("Horizontal");
    
    //Moves Player from left and right
    transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);
    // Keep Player within bounds
    // Left side wall
    if(transform.position.x < -xRange)
     {
        transform.position = new Vector3(-xRange,transform.position.y, transform.position.z);
     }
    // Right side wall
     if(transform.position.x > xRange)
     {
        transform.position = new Vector3(xRange,transform.position.y, transform.position.z);
     }
    
    // If spacebar is pressed fire LaserBolt
    if(Input.GetKeyDown(KeyCode.Space))
     {
    // Create LaserBolt at the blaster transform position maintaining the objects rotation.
        blasterAudio.PlayOneShot(laserBlast,1.0f); //Play blasterAudio soundclip
        Instantiate(LaserBolt, blaster.transform.position, LaserBolt.transform.rotation);
     }
 
    }

    // Delete any object with a trigger that hits the Player
    private void OnTriggerenter(Collider other)
    {
        Destroy(other.gameObject);
    }
}
