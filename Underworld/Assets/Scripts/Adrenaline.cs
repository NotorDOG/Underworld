using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Adrenaline : MonoBehaviour
{
    int adrenalineAmount; 

    // Start is called before the first frame update
    void Start()
    {
        adrenalineAmount = 0;    
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    int GetAdrenaline()
    {
        return adrenalineAmount;
    }
    void setAdrenaline(int addAdrenaline)
    {
        adrenalineAmount += addAdrenaline;
    } 
}
