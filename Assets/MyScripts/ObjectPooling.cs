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
    

    public GameObject lookRoot;

    void Awake()
    {
        SharedInstance = this;
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            GameObject bullet = GetPooledObject();
            if (bullet != null)
            {
                bullet.transform.position = turret.transform.position;
                bullet.transform.rotation = turret.transform.rotation;
                //transform.Translate(Vector3.forward * 5 * Time.deltaTime);
                //bullet.transform.rotation = transform.rotation;
                    bullet.SetActive(true);
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
