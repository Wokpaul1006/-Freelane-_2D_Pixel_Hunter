using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Gem : MonoBehaviour
{
    private TextMeshProUGUI GemText;
void Start()
    {
       GemText = GameObject.Find("GemText").GetComponent<TextMeshProUGUI>();
    }

   void OnTriggerEnter2D(Collider2D other)
    {
       if (other.CompareTag("PlayerContainer"))
        {
            int gem = PlayerPrefs.GetInt("Gem");
            gem ++;
            PlayerPrefs.SetInt("Gem",gem);
            Debug.Log("Gem = " + gem);
            GemText.text = gem.ToString();
            Destroy(gameObject);
        }
        
    }
}
