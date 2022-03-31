using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TruckFallTrigger : MonoBehaviour
{
    public GameObject[] trucks = new GameObject[4];


    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !other.isTrigger)
        {
            for(int i = 0; i < 4; i++)
            {
                trucks[i].SetActive(true);
            }
            
        }
    }
}
