using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    public float timeSpawn = 3.0f;
    public int numberSpawn = 4;
    public GameObject spawnable;
    // Start is called before the first frame update
    private void Start()
    {
        StartCoroutine(SpawnEnemy());
    }
    IEnumerator SpawnEnemy()
    {
        while (true)
        {
            if (!GetComponent<Renderer>().isVisible)
                continue;
            yield return new WaitForSeconds(timeSpawn);
            for (int i = 0; i <= numberSpawn; i++)
            {
                yield return new WaitForSeconds(.1f);
                Instantiate(spawnable, transform.position, transform.rotation); }
        }
    }
}
