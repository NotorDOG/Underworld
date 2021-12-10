using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public float maxHealth = 100f;
    public float currentHealth;

    private float timeSpawn = 3.0f;
    private int numberSpawn = 4;
    private float bufferTimeSpawn = 1f;
    public List<GameObject> spawnable;
    // Start is called before the first frame update
   
    private void Start()
    {
        currentHealth = maxHealth;
    }
    

    IEnumerator SpawnEnemy()
    {
        
        while (true)
        {
            
            yield return new WaitForSeconds(timeSpawn);
            for (int i = 0; i <= numberSpawn; i++)
            {
            yield return new WaitForSeconds(bufferTimeSpawn);
            Instantiate(spawnable[0], transform.position, transform.rotation); 
            }
            yield return new WaitForSeconds(bufferTimeSpawn + 0.2f);
            Instantiate(spawnable[1], transform.position, transform.rotation);
        }
    }
    private void OnBecameInvisible()
    {
        
        StopAllCoroutines();
        
    }
    private void OnBecameVisible()
    {
        StartCoroutine(SpawnEnemy());
    }
    
        
    }
   

