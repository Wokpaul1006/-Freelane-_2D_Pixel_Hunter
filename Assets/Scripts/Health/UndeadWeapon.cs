using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UndeadWeapon : MonoBehaviour
{

    public int damage;

    void OnTriggerEnter2D(Collider2D other)
    {
       if (other.CompareTag("PlayerContainer"))
        {
            other.GetComponent<playerhealth>().TakeDamage(damage);
        }
           
    }

}
