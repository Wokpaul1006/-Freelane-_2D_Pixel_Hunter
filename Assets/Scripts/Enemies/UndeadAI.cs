using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UndeadAI : MonoBehaviour
{
     private Transform playerPos;
     public float distanceToFollow;
     private bool iswalking;
     public float distanceNoFollow;
     public Rigidbody2D rb;
     public float speed;
     public Animator anim;
     public Animator Shadowanim;
     public int damage;
     private GameObject player;
     public Transform enemyChild;
     public GameObject AttackWeapon;
     public GameObject shadow;
     public Collider2D ColliderBox;
     private float alphalevel = 0;

 
     private float timer ;
     public float timetoattack;

    void Start()
    {
        playerPos = GameObject.FindGameObjectWithTag("Player").transform;
        player = GameObject.FindGameObjectWithTag("PlayerContainer");
        timer = 0;
    }

 
    void Update()
    {
      //Checking if Rigidbody Exist meaning the Enemy is alive Cause when his health iz zero he get is rigibody destroyed//

      if(rb != null){
         //*************************** Enemy Movement *****************************/
              Vector2 enem = new Vector2(transform.position.x, transform.position.y);
              float moveX = 0f;
              float moveY = 0f;
          // checking if the enemy geting damge so he can't walk
          if(this.anim.GetCurrentAnimatorStateInfo(0).IsName("Undead_Hurt")){
              Vector3 moveDir = new Vector3(moveX, moveY).normalized;
              rb.velocity= moveDir  * speed;
          }else{
             if(Vector2.Distance( transform.position, playerPos.position) < distanceToFollow && Vector2.Distance( enem, playerPos.position) > distanceNoFollow){
                if((transform.position.x - playerPos.position.x) > 0.4f  ){
                   moveX = -1f; 
                   enemyChild.localScale = new Vector3(-1f, 1, 1);
                 }else{
                     if((transform.position.x - playerPos.position.x) < -0.4f  ){
                      moveX = 1f;
                      enemyChild.localScale = new Vector3(1f, 1, 1);
                  }
              }
           if((transform.position.y - (playerPos.position.y-1f)) > 0.4f){
              moveY = -1f; 
            }else{
           if((transform.position.y - (playerPos.position.y-1f)) < -0.4f){
                moveY= 1f;  
            }
         }
   iswalking = true;
     }else{
        iswalking = false;
     }
      Vector3 moveDir = new Vector3(moveX, moveY).normalized;
      rb.velocity= moveDir  * speed;

      if(iswalking == true)
      {
           if(this.anim.GetCurrentAnimatorStateInfo(0).IsName("Undead_Attack"))
           {
             // when the enemy attack needs to finish his attack cuase he has an event in the attack animtion
           }else{
             anim.SetBool("Walk",true);
             Shadowanim.SetBool("Walk",true);
           }
           
      }else{
        anim.SetBool("Walk",false);
        Shadowanim.SetBool("Walk",false);

      }
          //*************************** End of Enemy Movement *****************************/


          //*************************** Enemy Attacking *****************************/

    if(Vector2.Distance( enem, playerPos.position) < distanceNoFollow){
      
        ///// Activate collision of the enemy attacker and disactivate it in the animation event when he finish the attack
         if(timer <= 0f){
           timer = timetoattack;
         }else{
           timer -= Time.deltaTime;
         } 
           anim.SetBool("Attack",true);
           Shadowanim.SetBool("Attack",true);
           AttackWeapon.SetActive(true);
         }else{ anim.SetBool("Attack",false);
                Shadowanim.SetBool("Attack",false);
         }
  
  /***********************************************************************************************************************/    

      }
      }else{
        shadow.transform.position = new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z);
        ColliderBox.enabled = false;
        gameObject.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sortingOrder = -1; 
        alphalevel = alphalevel + Time.deltaTime/2;
        gameObject.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().color = new Color (1f, 1f, 1f, 1 - alphalevel);
        gameObject.transform.GetChild(0).GetChild(1).gameObject.GetComponent<SpriteRenderer>().sortingOrder = -2;
        gameObject.transform.GetChild(0).GetChild(1).gameObject.GetComponent<SpriteRenderer>().color = new Color (0f, 0f, 0f, 0.5f - alphalevel);
        Destroy(gameObject,2f);
      }
    }
}
