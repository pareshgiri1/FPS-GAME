using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FolloWPlayer : MonoBehaviour
{
    //Transform player;
    public float speed = 4f;
    private Rigidbody rb;
    public float distance = 5f;
    public Animator _animator;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
       
        //player  = gameObject.GetComponent<Transform>
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 v = MyPlayerMovement.instance.transform.position - transform.position;
        if (v.magnitude < distance)
        {
            rb.velocity = Vector3.zero;
            _animator.SetBool("Attack", true);
        }
        else
        {
            _animator.SetBool("Attack", false);
            Vector3 pos = Vector3.MoveTowards(transform.position, MyPlayerMovement.instance.transform.position, speed * Time.fixedDeltaTime);
            rb.MovePosition(pos);
            transform.LookAt(MyPlayerMovement.instance.transform);
        }
       

       
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.GetComponent<Bullet>() != null)
        {
            collision.gameObject.SetActive(false);
        }
    }
}
