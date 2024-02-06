using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using TMPro;

public class XpPickUp : MonoBehaviour
{
    // private TextMeshProUGUI XPText;

    //New code by BaoHQ - 06/02/2024
    private LevelUp lvMN;
    //
    void Start()
     {
      // XPText = GameObject.Find("XPText").GetComponent<TextMeshProUGUI>();
      lvMN = GameObject.Find("GameManager").GetComponent<LevelUp>();
     }

    void OnTriggerEnter2D(Collider2D other)
    {
       if (other.CompareTag("PlayerContainer"))
       {
            int XP = PlayerPrefs.GetInt("XP");
            XP++;
            PlayerPrefs.SetInt("XP",XP);

            //Calling Level upgrade from this point
            lvMN.OnLevelUp();
            
            //XPText.text = XP.ToString();
            Destroy(gameObject);
       } 
    }
}
