using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowPoisen : MonoBehaviour
{
   
  public GameObject Poisen;
  
  


     void ExplosePoisen(){
        Instantiate(Poisen,new Vector3(transform.position.x , transform.position.y , transform.position.z ), Quaternion.identity);
        Destroy(gameObject);
    }
}
