using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnUnits : MonoBehaviour
{
    public float timeBetweenSpawning = 3f;
    public GameObject spawnUnit;
    float timer = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SpawnTimer();
    }

    private void SpawnTimer()
    {
        timer += Time.deltaTime;

        if (timer >= timeBetweenSpawning){
            SpawnAUnit();        
            timer = 0f;
        }
    }

    void SpawnAUnit(){
        Instantiate(spawnUnit, transform.position, Quaternion.identity);
    }
}
