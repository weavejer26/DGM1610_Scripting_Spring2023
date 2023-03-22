using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    [Header("Enemy Move Info")]
    public float speed; //How fast the enemy moves
    public float rayDistance; //How far the ray extends

    public bool isMovingRight = true; //Is the enemy moving right?

    public Transform groundDetection; //Is the enemy touching the ground?

    
    // Update is called once per frame
    void Update()
    {
        //Move the enemy to the right
        transform.Translate(Vector2.right * speed * Time.deltaTime);

        //Raycasting - Produces a ray from an origin point in a certain direction with set distance
        RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, rayDistance);

        if(groundInfo.collider == false)
        {
            if(isMovingRight == true)
            {
                //Flip Enemy at edge to move left
                transform.eulerAngles = new Vector3(0,-180,0);
                isMovingRight = false;
            }
            else
            {
                //Flip Enemy at edge to move right
                transform.eulerAngles = new Vector3(0,0,0);
                isMovingRight = true;
            }
        }  
    }
}
