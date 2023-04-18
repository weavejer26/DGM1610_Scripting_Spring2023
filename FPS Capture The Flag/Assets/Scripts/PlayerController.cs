using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Stats")]
    public float moveSpeed;         //movement speed in units per second
    public float jumpForce;         //Force applied upwards
    
    public int curHP;               //Current Health
    public int maxHP;               //Maximum amount of health
    
    [Header("Mouse Look")]
    public float lookSensitivity;   //Mouse look sensitivity
    public float maxLookX;          //Lowest we can look
    public float minLookX;          //Highest we can look
    private float rotX;             //Current X rotation of camera    
    
    private Camera camera;          //Main camera reference
    private Rigidbody rb;           //Rigidbody reference
    //private Weapon weapon;        //Weapon reference
    
    void Awake() 
    {
        //weapon = GetComponent<Weapon>();
        curHP = maxHP;
    }
    
    // Start is called before the first frame update
    void Start()
    {
       //Get component
       camera = Camera.main;
       rb = GetComponent<Rigidbody>();

       /* Initialize the UI
       GameUI.instance.UpdateHealthBar(curHP, maxHP);
       GameUI.instance.UpdateScoreText(0);
       GameUI.instance.UpdateAmmoText(weapon.curAmmo,weapon.maxAmmo); */
    }
    
    void Move()
        {
            float x = Input.GetAxis("Horizontal") * moveSpeed; //left and right input
            float z = Input.GetAxis("Vertical") * moveSpeed;    //forward and backward input

            //Move direction relative to camera
            Vector3 dir = transform.right * x + transform.forward * z;

            dir.y = rb.velocity.y; //Apply force upwards
            rb.velocity = dir; //Apply force in the relative direction of the camera
        }
    
    void CanLook()
    {
        float y = Input.GetAxis("Mouse X") * lookSensitivity;
        rotX += Input.GetAxis("Mouse Y") * lookSensitivity;

        rotX = Mathf.Clamp(rotX, minLookX, maxLookX);
        camera.transform.localRotation = Quaternion.Euler(-rotX, 0, 0);
        transform.eulerAngles += Vector3.up * y;
    }
    
    
    void Jump()
    {
        Ray ray = new Ray(transform.position, Vector3.down);

        if(Physics.Raycast(ray, 1.1f))
        {
            //Add force to jump
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    //Applies Damage to the Player
    public void TakeDamage(int damage)
    {
        curHP -= damage;

        if(curHP <- 0)
        {
            Die();
            //GameUI.instance.UpdateHealthBar(curHp, maxHp);
        }
     }
    
    //If Player health is reduced to zero or below the run Die()
    void Die()
     {
        //GameManager.instance.LoseGame();
        Debug.Log("Player has died! Game Over!");
        Time.timeScale = 0;
     }  
    
    public void Givehealth(int amountToGive)
     {
        //curHP = Mathf.Clamp(curHP + amountToGive, 0, maxHP);
        //GameUI.instance.UpdateHealthBar(curHP, maxHP);
        Debug.Log("Player has been healed!");
     } 

    public void GiveAmmo(int amountToGive)
    {
        //weapon.curAmmo - Mathf.Clamp(weapon.curAmmo + amountToGive, 0, weapon.maxAmmo);
        //GameUI.instance.UpdateAmmoText(weapon.curAmmo, weapon.maxAmmo);
        Debug.Log("Player has collected ammo!");
    }
    
    //Update is called once per frame
    void Update()
    {
        Move();
        CanLook();
    
        /*Fire Button
        if(Input.GetButton("Fire1"))
        {
            if(weapon.CanShoot())
            { 
                weapon.Shoot()
            }
        }*/
    
        //Jump Button
        if(Input.GetButtonDown("Jump"))
        {
            Jump();
        }
        /* //Don't do anything if the game is paused
        if(GameManager.instance.gamePaused == true)
        {
            return;
        } */
    }
}
