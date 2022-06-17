using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int speed = 2 ;
    float LifeTime;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnEnable()
    {
        LifeTime = 2f;
    }
    // Update is called once per frame
    void Update()
    {
        //rb.velocity=Vector3.forward ;
        transform.Translate(Vector3.forward * 5 * Time.deltaTime);
        //transform.position += Vector3.forward * speed * Time.deltaTime ;
        //transform.position += Vector3.forward * 5 * Time.deltaTime; 
        //transform.position = Vector3.MoveTowards(transform.position * Time.deltaTime * speed, bullet.position * Time.deltaTime * speed, 10f) ;
        //transform.localRotation = Quaternion.Euler(look_Angles.x, look_Angles.y, 0f);

        LifeTime -= Time.deltaTime;
        if (LifeTime <= 0.1f)
        {
            gameObject.SetActive(false);
            //transform.position = PlayerBehaviour.Instance.transform.position;
            // transform.gameObject.SetActive(false);
        }

    }
}
