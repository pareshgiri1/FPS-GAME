using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int speed = 10 ;
    float LifeTime;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnEnable()
    {
        LifeTime = 10f;
    }
    // Update is called once per frame
    void Update()
    {
        
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
            LifeTime -= Time.deltaTime;
            if (LifeTime <= 0.1f)
            {
                gameObject.SetActive(false);
            }
            
        

    }
}
