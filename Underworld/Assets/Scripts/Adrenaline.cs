using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Adrenaline : MonoBehaviour
{
    Slider adrSlider;
    bool couldAdrenaline = true;
    public float adrBuffer = 0.05f;
    public float adrGain = 1f;

    void Start()
    {
        adrSlider = Camera.main.GetComponentInChildren<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "BadProj" && couldAdrenaline && !(adrSlider.value == adrSlider.maxValue))
        {
            Debug.Log("Hello");
            AddAdrenaline(adrGain);
            StartCoroutine(GainAdrenaline());
        }
                
    }
    IEnumerator GainAdrenaline()
    {
        couldAdrenaline = false;
        yield return new WaitForSeconds(adrBuffer * Time.deltaTime);
        couldAdrenaline = true;
    }

    public void AddAdrenaline(float amount)
    {
        adrSlider.value += amount;
    }

    public void setAdrenaline(int value)
    {
        adrSlider.value = value;
    }
}
