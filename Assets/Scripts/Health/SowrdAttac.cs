using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SowrdAttac : MonoBehaviour
{

    public int damage;

   void OnTriggerEnter2D(Collider2D other)
    {
       if (other.CompareTag("Undead"))
        {
            other.GetComponent<playerhealth>().TakeDamage(damage);
        }
    }

    public void SetDamage(int damageValue)
  {
      damage = damageValue;
  }

  public void SetDamageLevelUP()
  {
    damage = damage + 50;
  }
 
}
