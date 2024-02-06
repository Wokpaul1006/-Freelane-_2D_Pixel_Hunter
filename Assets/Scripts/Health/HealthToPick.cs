using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthToPick : MonoBehaviour
{
    public int health;
    void OnTriggerEnter2D(Collider2D other)
    {
       if (other.CompareTag("PlayerContainer"))
        {
            other.GetComponent<playerhealth>().TakeHealth(health);
            Destroy(gameObject);
        }
           
    }

}
