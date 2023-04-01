using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
   private float attackDelay;
   public float startDelay;
   public Transform attackPos;

   public LayerMask whatisEnemies;
   public float attackRange;
   public int damage;
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(attackDelay <= 0) //If attack delay is zero allow an attack
        {
            if(Input.GetKey(KeyCode.F)) //Wait for key press
            {
                Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, whatisEnemies);

                for(int i=0; i < enemiesToDamage.Length; i++)
                {
                    enemiesToDamage[i].GetComponent<Enemy>().TakeDamage(damage);
                }
       
            } 
        
            attackDelay = startDelay;
        }
            else
            {
                attackDelay -= Time.deltaTime; //Countdown
            }
    }
    //Render gizmos on screen in a red wire sphere
    void OnDrawGizmosSelected() 
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }
    



}
