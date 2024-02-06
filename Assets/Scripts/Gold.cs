using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Gold : MonoBehaviour
{

    private TextMeshProUGUI GoldText;
  
  void Start()
    {
       GoldText = GameObject.Find("GoldText").GetComponent<TextMeshProUGUI>();
    }
   void OnTriggerEnter2D(Collider2D other)
    {
       if (other.CompareTag("PlayerContainer"))
        {
            int gold = PlayerPrefs.GetInt("Gold");
            gold ++;
            PlayerPrefs.SetInt("Gold",gold);
            Debug.Log("Gold = " + gold);
            GoldText.text = gold.ToString();
            Destroy(gameObject);
        }
        
    }
}
