using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Buff : MonoBehaviour
{
    private void Start()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Player")
        {
            if(gameObject.tag == "AdrBoost")
            {
                collision.gameObject.GetComponentInChildren<Adrenaline>().AddAdrenaline(25);
                Destroy(gameObject);
            }
            if(gameObject.tag == "Health")
            {
                collision.gameObject.GetComponentInChildren<Slider>().value += 10;
                Destroy(gameObject);
            }
        }
    }
}
