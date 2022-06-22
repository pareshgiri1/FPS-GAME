using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    private float spawnRangeX = 50;
    private float spawaPosZ = 50;
    public GameObject enemy;
    int i = 0;
    float LifeTime;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnEnable()
    {
        LifeTime = 5f;
    }
    // Update is called once per frame
    void Update()
    {
        LifeTime -= Time.deltaTime;
        if (LifeTime <= 0.1f)
        {
            if (i < 100)
            {
                Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, spawaPosZ);
                Instantiate(enemy, spawnPos, enemy.transform.rotation);
                i++;
            }
        }
        
        
    }
}
