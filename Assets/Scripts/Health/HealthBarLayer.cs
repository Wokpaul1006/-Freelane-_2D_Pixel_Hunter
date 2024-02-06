using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarLayer : MonoBehaviour
{
   private Canvas myCanvas;

    void Start()
    {
        myCanvas = this.GetComponent<Canvas>();
    }

    // Update is called once per frame
    void Update()
    {
      myCanvas.sortingOrder = transform.parent.gameObject.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer> ().sortingOrder;   

      
    }
}
