using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackFinishedEvvent : MonoBehaviour
{

    public GameObject Sword;

    public void FinishedAttacke()
    {
      if(Sword !=null){
      Sword.SetActive(false);
      }
    }
}
