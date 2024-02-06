using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HoldBotlleSpell : MonoBehaviour
{
    public int SpellNumber;

    
    void OnTriggerEnter2D(Collider2D other)
    {
       if (other.CompareTag("PlayerContainer"))
        {
           if(SpellNumber == 1)
           {
             PlayerPrefs.SetInt("GreenPoisen", PlayerPrefs.GetInt("GreenPoisen") + 1);
             GameObject.Find("HolderText1").GetComponent<TextMeshProUGUI>().text = PlayerPrefs.GetInt("GreenPoisen").ToString();
           }
           if(SpellNumber == 2)
           {
             PlayerPrefs.SetInt("SliceSpell", PlayerPrefs.GetInt("SliceSpell") + 1);
             GameObject.Find("HolderText2").GetComponent<TextMeshProUGUI>().text = PlayerPrefs.GetInt("SliceSpell").ToString();
           }
           if(SpellNumber == 3)
           {
             PlayerPrefs.SetInt("FireSpell", PlayerPrefs.GetInt("FireSpell") + 1);
             GameObject.Find("HolderText3").GetComponent<TextMeshProUGUI>().text = PlayerPrefs.GetInt("FireSpell").ToString();
           }
           if(SpellNumber == 4)
           {
             PlayerPrefs.SetInt("TreeSpell", PlayerPrefs.GetInt("TreeSpell") + 1);
             GameObject.Find("HolderText4").GetComponent<TextMeshProUGUI>().text = PlayerPrefs.GetInt("TreeSpell").ToString();
           }
           if(SpellNumber == 5)
           {
             PlayerPrefs.SetInt("StormSpell", PlayerPrefs.GetInt("StormSpell") + 1);
             GameObject.Find("HolderText5").GetComponent<TextMeshProUGUI>().text = PlayerPrefs.GetInt("StormSpell").ToString();
           }
           
           Destroy(gameObject);
           
        }
    }
}
