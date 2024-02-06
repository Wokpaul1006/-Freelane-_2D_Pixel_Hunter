using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerhealth : MonoBehaviour
{
  public int maxHealth = 100;
  public int currentHealth;
  public Healthbarr healthBar;
  public Animator anim;
  public Animator Shadowanim;
  public Rigidbody2D rb;
  public GameObject HealthCanvas;
  public float DamageAmplifier = 1;

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
         {
            TakeDamage(20);
         }
    }


public void TakeDamage(int damage){

    float what = currentHealth - (damage * DamageAmplifier);

   if(what <= 0){
        currentHealth = 0;
        Destroy(rb);
        Destroy(gameObject.GetComponent<BoxCollider2D>());
        Destroy(HealthCanvas);
        anim.SetBool("Death",true);
        anim.SetTrigger("Death 0");
        Shadowanim.SetBool("Death",true);
        Shadowanim.SetTrigger("Death 0");
   }else{
       anim.SetTrigger("Hurt");
       Shadowanim.SetTrigger("Hurt");
       currentHealth -= (int)(damage * DamageAmplifier);
   }

    healthBar.SetHealth(currentHealth);

}


public void TakeHealth(int health){

   float what = currentHealth + health;

   if(what > maxHealth){
       currentHealth = maxHealth;
   }else{
       currentHealth += health;
   }
    healthBar.SetHealth(currentHealth);

  }

  public void SetDamageAmplifier(float DamageAmplifierValue)
  {
    DamageAmplifier = DamageAmplifierValue;
  }

  public void SetHealthMax()
  {
    maxHealth = maxHealth + 20;
    Debug.Log("Max Health ="+ maxHealth);
    healthBar.SetMaxHealth(maxHealth);
    TakeHealth(maxHealth);
  }
}


