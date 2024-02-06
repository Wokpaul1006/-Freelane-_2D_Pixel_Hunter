using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatAI : MonoBehaviour
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
     private bool Died = true;

 
     private float timer ;
     public float timetoattack;
     private bool startWalk = true;



    public GameObject Spell1;
    public GameObject Spell2;
    public GameObject Spell3;
    public GameObject Spell4;
    public GameObject Spell5;
    public GameObject Weapon1;
    public GameObject Weapon2;
    public GameObject Weapon3;
    public GameObject Armor1;
    public GameObject Armor2;
    public GameObject Armor3;
    public GameObject Xp;
    public GameObject MedKit;


    void Start()
    {
        playerPos = GameObject.FindGameObjectWithTag("Player").transform;
        player = GameObject.FindGameObjectWithTag("PlayerContainer");
        timer = timetoattack;
        speed = speed * Random.Range(0.6f, 1.2f);
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
              rb.velocity= moveDir * speed;
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
           if((transform.position.y - (playerPos.position.y+1f)) > -0.2f){
              moveY = -1f; 
            }else{
           if((transform.position.y - (playerPos.position.y+1f)) < -0.2f){
                moveY= 1f;  
            }
         }
   iswalking = true;
     }else{
        iswalking = false;
     }
      Vector3 moveDir = new Vector3(moveX, moveY).normalized;
      rb.velocity= moveDir * speed ;

      if(iswalking == true)
      {
           if(this.anim.GetCurrentAnimatorStateInfo(0).IsName("Undead_Attack"))
           {
             // when the enemy attack needs to finish his attack cuase he has an event in the attack animtion
           }else{
            AttackWeapon.SetActive(false);
             anim.SetBool("Walk",true);
             if(startWalk == true){
              anim.Play("Bat_Walk", 0, Random.Range(0f, 1f));
              timer = timetoattack;
              startWalk = false;
             }
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
           anim.SetBool("Attack",true);
           Shadowanim.SetBool("Attack",true);
           AttackWeapon.SetActive(true);
         }else{
           timer -= Time.deltaTime;
           
         } 
           
         }else{ anim.SetBool("Attack",false);
                Shadowanim.SetBool("Attack",false);
         }
  
  /***********************************************************************************************************************/    

      }
      }else{
        if(Died == true)
        {
         ColliderBox.enabled = false;
         shadow.transform.position = new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z);
         gameObject.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sortingOrder = -1; 
         gameObject.transform.GetChild(0).GetChild(1).gameObject.GetComponent<SpriteRenderer>().sortingOrder = -2;
         Destroy(gameObject,2f);
         PlayerPrefs.SetInt("numberOfaBats", PlayerPrefs.GetInt("numberOfaBats")-1);
         int z = Random.Range(1,4);
         if(z==2 || z == 3)
         {
          spawnObject();
         }
         Died = false;
        }

        alphalevel = alphalevel + Time.deltaTime/2;
        gameObject.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().color = new Color (1f, 1f, 1f, 1 - alphalevel);
        gameObject.transform.GetChild(0).GetChild(1).gameObject.GetComponent<SpriteRenderer>().color = new Color (0f, 0f, 0f, 0.5f - alphalevel);
        
      }
    }


    public void spawnObject()
    {
      int y = Random.Range(1,30);
      if(y == 3)
      {
         int b = Random.Range(1,12);
         if(b==1)
         {
          Instantiate(Spell1, transform.position, Quaternion.identity);
         }
         if(b==2)
         {
          Instantiate(Spell2, transform.position, Quaternion.identity);
         }
         if(b==3)
         {
          Instantiate(Spell3, transform.position, Quaternion.identity);
         }
         if(b==4)
         {
          Instantiate(Spell4, transform.position, Quaternion.identity);
         }
         if(b==5)
         {
          Instantiate(Spell5, transform.position, Quaternion.identity);
         }

         if(b==6)
         {
          Instantiate(Weapon1, transform.position, Quaternion.identity);
         }
         if(b==7)
         {
          Instantiate(Weapon2, transform.position, Quaternion.identity);
         }
         if(b==8)
         {
          Instantiate(Weapon3, transform.position, Quaternion.identity);
         }
         if(b==9)
         {
          Instantiate(Armor1, transform.position, Quaternion.identity);
         }
         if(b==10)
         {
          Instantiate(Armor2, transform.position, Quaternion.identity);
         }
         if(b==11)
         {
          Instantiate(Armor3, transform.position, Quaternion.identity);
         }

      }else
      {
          int b = Random.Range(1,20);
          if(b==3)
         {
          Instantiate(MedKit, transform.position, Quaternion.identity);
         }else{
          Instantiate(Xp, transform.position, Quaternion.identity);
         }
      }
    }
}
