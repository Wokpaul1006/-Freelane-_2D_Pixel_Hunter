using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerMovement : MonoBehaviour
{
    //Advice: You should'n leave those variables as "public", prefer put it in "private" or "internal".
    public float moveSpeed = 5f;
    public float SpeedAffectedByWeapon = 1f;
    public float SpeedAffectedByArmor = 1f;
    public Rigidbody2D rb;
    Vector2 movement;
    public Animator anim;
    public Animator Shadowanim;
    public Transform playerChild;
    private bool canAttack = true;
 
    public GameObject Sword;

    public GameObject GreenPoisenSpell;
    public GameObject SliceSpell;
    public GameObject FireSpell;
    public GameObject StormSpell;
    public GameObject TreeSpell;
    public TextMeshProUGUI GreenPoisenText;
    public TextMeshProUGUI SliceSpellText;
    public TextMeshProUGUI FireSpellText;
    public TextMeshProUGUI TreeSpellext;
    public TextMeshProUGUI StormSpellText;
    public ParticleSystem Partical_System;

    void Start()
    {
        PlayerPrefs.SetInt("GreenPoisen",2);
        PlayerPrefs.SetInt("SliceSpell",2);
        PlayerPrefs.SetInt("FireSpell",2);
        PlayerPrefs.SetInt("TreeSpell",2);
        PlayerPrefs.SetInt("StormSpell",2);

        GreenPoisenText.text = PlayerPrefs.GetInt("GreenPoisen").ToString();
        SliceSpellText.text = PlayerPrefs.GetInt("SliceSpell").ToString();
        FireSpellText.text = PlayerPrefs.GetInt("FireSpell").ToString();
        TreeSpellext.text = PlayerPrefs.GetInt("TreeSpell").ToString();
        StormSpellText.text = PlayerPrefs.GetInt("StormSpell").ToString(); 
    }

    void Update()
    {
        // verifying if rigidbody exist means the player is alive and we can controll him  
        if(rb != null)
        {
            // fighting 
            if (Input.GetMouseButtonDown(0) && canAttack == true)
            {
                anim.SetTrigger("Fight");
                Shadowanim.SetTrigger("Fight");
                Sword.SetActive(true);
            }
            // Spells 
            if (Input.GetKeyDown(KeyCode.Alpha1) && PlayerPrefs.GetInt("GreenPoisen") > 0)
            {
                PlayerPrefs.SetInt("GreenPoisen", PlayerPrefs.GetInt("GreenPoisen") - 1);
                GreenPoisenText.text = PlayerPrefs.GetInt("GreenPoisen").ToString();
                Green_Poisen_Spell();
            }
            if (Input.GetKeyDown(KeyCode.Alpha2) && PlayerPrefs.GetInt("SliceSpell") > 0)
            {
                PlayerPrefs.SetInt("SliceSpell", PlayerPrefs.GetInt("SliceSpell") - 1);
                SliceSpellText.text = PlayerPrefs.GetInt("SliceSpell").ToString();
                Slice_Spell();
            }
            if (Input.GetKeyDown(KeyCode.Alpha3) && PlayerPrefs.GetInt("FireSpell") > 0)
            {
                PlayerPrefs.SetInt("FireSpell", PlayerPrefs.GetInt("FireSpell") - 1);
                FireSpellText.text = PlayerPrefs.GetInt("FireSpell").ToString();
                Fire_Spell();
            }
            if (Input.GetKeyDown(KeyCode.Alpha4) && PlayerPrefs.GetInt("TreeSpell") > 0)
            {
                PlayerPrefs.SetInt("TreeSpell", PlayerPrefs.GetInt("TreeSpell") - 1);
                TreeSpellext.text = PlayerPrefs.GetInt("TreeSpell").ToString();
                Tree_Spell();
            }
            if (Input.GetKeyDown(KeyCode.Alpha5) && PlayerPrefs.GetInt("StormSpell") > 0)
            {
                PlayerPrefs.SetInt("StormSpell", PlayerPrefs.GetInt("StormSpell") - 1);
                StormSpellText.text = PlayerPrefs.GetInt("StormSpell").ToString();
                Storm_Spell();
            }
            if (this.anim.GetCurrentAnimatorStateInfo(0).IsName("Fight"))
            {
                movement.x = 0f;
                movement.y = 0f;
                canAttack = false;
                var em = Partical_System.emission;
                em.enabled = false;
            }
            else
            {
                canAttack = true;
                movement.x = Input.GetAxisRaw("Horizontal");
                movement.y = Input.GetAxisRaw("Vertical");
            }
            if(movement.x != 0f || movement.y != 0f)
            {
                anim.SetBool("Run",true);
                Shadowanim.SetBool("Run",true);
                var em = Partical_System.emission;
                em.enabled = true;
            }
            else
            {
                anim.SetBool("Run",false);
                Shadowanim.SetBool("Run",false);
                var em = Partical_System.emission;
                em.enabled = false;
            }
            if(movement.x > 0f)
            {
                playerChild.localScale = new Vector3(1f, 1, 1);
            }
            if(movement.x < 0f)
            {
                playerChild.localScale = new Vector3(-1f, 1, 1);
            }
        }        
    }
    void FixedUpdate()
    {
        if(rb != null)
        {
            rb.MovePosition(rb.position + movement.normalized * (moveSpeed * SpeedAffectedByWeapon * SpeedAffectedByArmor) * Time.fixedDeltaTime);
        }
    }
    public void Green_Poisen_Spell()
    {
        GameObject Poisennn = Instantiate(GreenPoisenSpell, new Vector3(transform.position.x , transform.position.y +1f, transform.position.z ), transform.rotation);
        Poisennn.transform.localScale = new Vector3( playerChild.transform.localScale.x, 1, 1 );
    }
    public void Slice_Spell()
    {
        GameObject Poisennn = Instantiate(SliceSpell, new Vector3(transform.position.x , transform.position.y -1.5f, transform.position.z ), transform.rotation);
    }
    public void Fire_Spell()
    {
        GameObject Poisennn = Instantiate(FireSpell, new Vector3(transform.position.x + (2f * playerChild.transform.localScale.x), transform.position.y -0.4f, transform.position.z ), transform.rotation,gameObject.transform);
        Poisennn.transform.localScale = new Vector3( Poisennn.transform.localScale.x * playerChild.transform.localScale.x, Poisennn.transform.localScale.y, Poisennn.transform.localScale.z );
    }
    public void Tree_Spell()
    {
        Instantiate(TreeSpell, new Vector3(transform.position.x, transform.position.y , transform.position.z ), transform.rotation);
        Instantiate(TreeSpell, new Vector3(transform.position.x + 1.5f, transform.position.y , transform.position.z ), transform.rotation);
        Instantiate(TreeSpell, new Vector3(transform.position.x - 1.5f, transform.position.y , transform.position.z ), transform.rotation);
        Instantiate(TreeSpell, new Vector3(transform.position.x , transform.position.y + 1.5f, transform.position.z ), transform.rotation);
        Instantiate(TreeSpell, new Vector3(transform.position.x , transform.position.y - 1.5f, transform.position.z ), transform.rotation);
    }
    public void Storm_Spell()
    {
        Instantiate(StormSpell, new Vector3(transform.position.x + 1f, transform.position.y , transform.position.z ), transform.rotation);
        Instantiate(StormSpell, new Vector3(transform.position.x - 1f, transform.position.y , transform.position.z ), transform.rotation);
        Instantiate(StormSpell, new Vector3(transform.position.x + 2f, transform.position.y , transform.position.z ), transform.rotation);
        Instantiate(StormSpell, new Vector3(transform.position.x - 2f, transform.position.y , transform.position.z ), transform.rotation);
        Instantiate(StormSpell, new Vector3(transform.position.x , transform.position.y + 2f, transform.position.z ), transform.rotation);
        Instantiate(StormSpell, new Vector3(transform.position.x , transform.position.y - 2f , transform.position.z ), transform.rotation);
    }
    public void SetSpeedWeapon(float speedValue)
    { 
        SpeedAffectedByWeapon = speedValue;
    }
    public void SetSpeedArmor(float speedValue)
    { 
        SpeedAffectedByArmor = speedValue;
    }
}
