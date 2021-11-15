using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Projectile : MonoBehaviour
{
    Slider adrSlide;
    Slider healthSlide;
    public float adrDivide = 1.5f;
    public int damage = 10;
    void Start()
    {
        adrSlide = Camera.main.GetComponentInChildren<Slider>();
       
    }

    // Update is called once per frame

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            Debug.Log(collision.ToString());
            Destroy(gameObject);
            collision.gameObject.GetComponentInChildren<Slider>().value -= damage;
            adrSlide.value /= 2f;
        }
    }
}
