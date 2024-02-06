using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using TMPro;

public class XpPickUp : MonoBehaviour
{

    // private TextMeshProUGUI XPText;
     void Start()
    {
      // XPText = GameObject.Find("XPText").GetComponent<TextMeshProUGUI>();
    }

   void OnTriggerEnter2D(Collider2D other)
    {
       if (other.CompareTag("PlayerContainer"))
        {
            int XP = PlayerPrefs.GetInt("XP");
            XP ++;
            PlayerPrefs.SetInt("XP",XP);
            //XPText.text = XP.ToString();
            Destroy(gameObject);
        }
        
    }
}
