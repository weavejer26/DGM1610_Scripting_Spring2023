using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{   
    
    private PlayerHealth playerHealth; //Referencing the player health script
    public int damage =1; //Storing a value
    
    // Start is called before the first frame update
    void Start()
    {
      playerHealth = GameObject.Find("Player").GetComponent<PlayerHealth>();  
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        playerHealth.TakeDamage(damage);
        Debug.Log("Player takes "+ damage + " points of damage");
    }
}
