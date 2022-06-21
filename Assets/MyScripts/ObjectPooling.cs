using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ObjectPooling : MonoBehaviour
{
    public static ObjectPooling SharedInstance;
    public List<GameObject> pooledObjects;
    public GameObject objectToPool;
    public int amountToPool;
    public GameObject turret;
    public Animator _animator;

    public GameObject lookRoot;

    void Awake()
    {
        SharedInstance = this;
    }
    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            GameObject bullet = GetPooledObject();
            if (bullet != null)
            {
                bullet.transform.position = turret.transform.position;
                bullet.transform.rotation = turret.transform.rotation;
                bullet.SetActive(true);
                _animator.SetTrigger("Fire");
            }
        }
    }
    void Start()
    {
        pooledObjects = new List<GameObject>();
        GameObject tmp;
        for (int i = 0; i < amountToPool; i++)
        {
            tmp = Instantiate(objectToPool);
            tmp.SetActive(false);
            pooledObjects.Add(tmp);
        }
    }
    public GameObject GetPooledObject()
    {
        for (int i = 0; i < amountToPool; i++)
        {
            if (!pooledObjects[i].activeInHierarchy)
            {
                return pooledObjects[i];
            }
        }
        return null;
    }

}
