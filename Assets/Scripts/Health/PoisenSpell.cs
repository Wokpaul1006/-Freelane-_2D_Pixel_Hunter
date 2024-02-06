using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoisenSpell : MonoBehaviour
{



    public int damage;

   void OnTriggerStay2D(Collider2D other)
    {
       if (other.CompareTag("Undead"))
        {
            other.GetComponent<playerhealth>().TakeDamage(damage);
        }
    }

    public void DestroySpell()
    {
        Destroy(gameObject);
    }
 
}