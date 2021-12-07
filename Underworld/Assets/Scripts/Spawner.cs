using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public float maxHealth = 100f;
    private float currentHealth;
    public float timeSpawn = 3.0f;
    public int numberSpawn = 4;
    public float bufferTimeSpawn = .2f;
    public List<GameObject> spawnable;
    // Start is called before the first frame update
   
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
