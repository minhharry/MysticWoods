using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobSpawnerScript : MonoBehaviour
{
    public GameObject slime;
    public float spawnRate;
    float timerSpawn = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timerSpawn += Time.deltaTime;
        if (timerSpawn > spawnRate)
        {
            timerSpawn = 0;
            Instantiate(slime, new Vector3(transform.position.x + Random.Range(-0.1f, 0.1f), transform.position.y + Random.Range(-0.1f, 0.1f), 0f), transform.rotation);
        }
    }
}
