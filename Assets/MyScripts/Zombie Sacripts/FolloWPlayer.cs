using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FolloWPlayer : MonoBehaviour
{
    //Transform player;
    public float speed = 4f;
    private Rigidbody rb;
    float distance = 2f;
    public Animator _animator;
    public float attackaTime;
    NavMeshAgent agent;
  
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        agent = GetComponent<NavMeshAgent>();
        attackaTime = 2;
        //player  = gameObject.GetComponent<Transform>
    }

    // Update is called once per frame
    void Update()
    {
        attackaTime -= Time.deltaTime;
        Vector3 v = MyPlayerMovement.instance.transform.position - transform.position;
        if (v.magnitude < distance)
        {
            rb.velocity = Vector3.zero;
            if (attackaTime<=0)
            {
                _animator.SetBool("Attack", true);
                MyPlayerMovement.instance.ReduceHealth(5f);
                attackaTime = 2;
            }
           
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
            Destroy(gameObject);
          
        }
    }
}
