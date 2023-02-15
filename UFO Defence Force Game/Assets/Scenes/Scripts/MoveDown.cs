using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDown : MonoBehaviour
{
    public float moveSpeed = 1.0f;
    public float lowerBound = 15f;
    
    // Update is called once per frame
    void Update()
    {
        //Make the Pick Up Item move down
        transform.Translate(Vector3.down * moveSpeed * Time.deltaTime);
    }
}
