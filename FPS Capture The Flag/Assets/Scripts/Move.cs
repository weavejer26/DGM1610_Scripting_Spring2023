using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    private float hInput;
    private float vInput;
    public float rotSpeed;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        hInput = Input.GetAxis("Horizontal");
        vInput = Input.GetAxis("Vertical");

        transform.Translate(Vector3.right * hInput);
        transform.Translate(Vector3.forward * vInput);

        transform.Rotate(Vector3.right, rotSpeed * vInput * Time.deltaTime);
    }
}
