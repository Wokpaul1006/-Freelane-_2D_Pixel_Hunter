using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickWeapon : MonoBehaviour
{
    public int Damage;
    public float WeaponAffectSpeed; 
    public Sprite UI_Image;
    private Image imageLinker;
    
     void Start()
    {
       imageLinker = GameObject.Find("WeaponUI").GetComponent<Image>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
       if (other.CompareTag("PlayerContainer"))
        {
            other.transform.GetChild(0).GetChild(0).GetComponent<SowrdAttac>().SetDamage(Damage);
            other.GetComponent<PlayerMovement>().SetSpeedWeapon(WeaponAffectSpeed);
            imageLinker.GetComponent<Image>().sprite = UI_Image;
            imageLinker.color = Color.white;
            Destroy(gameObject);
        }
        
    }
}
