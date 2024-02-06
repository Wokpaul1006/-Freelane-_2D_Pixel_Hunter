using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickArmor : MonoBehaviour
{
    public float ArmorAffectSpeed; 
    public float DamageAmplifier = 1;
    public Sprite UI_Image;
    private Image imageLinker;
    
    void Start()
    {
       imageLinker = GameObject.Find("ArmorUI").GetComponent<Image>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
       if (other.CompareTag("PlayerContainer"))
        {
            other.GetComponent<PlayerMovement>().SetSpeedArmor(ArmorAffectSpeed);
            other.GetComponent<playerhealth>().SetDamageAmplifier(DamageAmplifier);
            imageLinker.GetComponent<Image>().sprite = UI_Image;
            imageLinker.color = Color.white;
            Destroy(gameObject);
        }
        
    }
}
