using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    
    public int maxHealth = 10;
    public int currentHealth;
    
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1; //Reset time back to regular time
        currentHealth = maxHealth;
    }

    public void TakeDamage(int dmgAmount)
        {
            currentHealth -= dmgAmount;
            Debug.Log("Player Health ="+ currentHealth);
            if(currentHealth <=0)
            {
                Debug.Log("You are dead! Game Over!"); //Game Over
                Time.timeScale = 0; //Freeze game
            }
        }    
    
    public void AddHealth(int healAmount)
    {
        currentHealth += healAmount;
        if(currentHealth >= maxHealth) //Puts a cap on current health
        {
            currentHealth = maxHealth;
        }
    }
}
