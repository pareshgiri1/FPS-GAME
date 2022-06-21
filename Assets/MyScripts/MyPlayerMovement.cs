using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyPlayerMovement : MonoBehaviour
{
    public static MyPlayerMovement instance;
    public CharacterController character;
    public float speed = 5;
    float VerticalInput ;
    float HorizontalInput;
    private void Awake()
    {
        instance = this;
    }
    
    // Update is called once per frame
    void Update()
    {
        VerticalInput = Input.GetAxis("Vertical");
        HorizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.forward * VerticalInput * speed * Time.deltaTime);
        //transform.position += new Vector3(0, 0, VerticalInput * speed);
        transform.Translate(Vector3.right * HorizontalInput * speed * Time.deltaTime);
    }
}
