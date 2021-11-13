using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Projectile : MonoBehaviour
{
    Slider adrSlide;
    void Start()
    {
        adrSlide = Camera.main.GetComponentInChildren<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Player")
        {
            adrSlide.value /= 2;
            Destroy(gameObject);
        }
    }
}
