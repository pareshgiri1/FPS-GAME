using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyPlayerMovement : MonoBehaviour
{
    public CharacterController character;
    public float speed = 5;
    float VerticalInput ;
    float HorizontalInput;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        VerticalInput = Input.GetAxis("Vertical");
        HorizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.forward * VerticalInput * speed * Time.deltaTime);
        transform.Translate(Vector3.right * HorizontalInput * 10 * Time.deltaTime);
    }
}
