using System.Collections;
using UnityEngine;

public class BulletLifeTime : MonoBehaviour
{

    public float lifeTimer = 10.0f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(LifeTime());
    }

  
    IEnumerator LifeTime()
    {
        yield return new WaitForSeconds(lifeTimer);
        Destroy(gameObject);
    }
  
}
