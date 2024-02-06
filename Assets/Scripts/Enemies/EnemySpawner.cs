using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public Transform pos1;
    public Transform pos2;
    public Transform pos3;
    public Transform pos4;
    public Transform pos5;
    public Transform pos6;
    public Transform pos7;
    public Transform pos8;
    public Transform pos9;
    public Transform pos10;
    public Transform pos11;


    public GameObject Bat;
    public Transform Player;
    private int TotalEnemiesSpawned = 0;
    private float timer = 20;


    void Start()
    {
        PlayerPrefs.SetInt("numberOfaBats", 0);   
    }

    void Update()
    {
      if(TotalEnemiesSpawned >= 0 && TotalEnemiesSpawned < 100 ){
       normalSpawner(10); 
      }
      
      if(TotalEnemiesSpawned >= 100 && TotalEnemiesSpawned < 150 ){
      
        if(timer < 0){
          WaveOfBat(Random.Range(-5,5));
        }else
        {
          timer -= Time.deltaTime;
        }
      }

      if(TotalEnemiesSpawned >= 150 && TotalEnemiesSpawned < 300 ){
        if(timer < -20){
          normalSpawner(20); 
        }else
        {
          timer -= Time.deltaTime;
        }
      }

      if(TotalEnemiesSpawned >= 300 && TotalEnemiesSpawned < 400 ){
      
        if(timer < -40){
          WaveOfBat(Random.Range(-5,5));
        }else
        {
          timer -= Time.deltaTime;
        }
      }
        
      if(TotalEnemiesSpawned >= 400 && TotalEnemiesSpawned < 600 ){
        if(timer < -60){
          normalSpawner(30); 
        }else
        {
          timer -= Time.deltaTime;
        }
      }

      if(TotalEnemiesSpawned >= 600 && TotalEnemiesSpawned < 800 ){
      
        if(timer < -80){
          WaveOfBat(Random.Range(-5,5));
        }else
        {
          timer -= Time.deltaTime;
        }
      }
      

    }



     public void normalSpawner(int max)
    {
       int num = PlayerPrefs.GetInt("numberOfaBats");
        if(num < max)
        {
          
          int posnum = Random.Range(1,12);
          if(posnum == 1 && Vector2.Distance( pos1.position, Player.position) > 15)
          {
            Instantiate(Bat, pos1.position, Quaternion.identity);
            TotalEnemiesSpawned++;
            PlayerPrefs.SetInt("numberOfaBats", (num + 1)); 
          }
          if(posnum == 2 && Vector2.Distance( pos2.position, Player.position) > 15)
          {
            Instantiate(Bat, pos2.position, Quaternion.identity);
            TotalEnemiesSpawned++;
            PlayerPrefs.SetInt("numberOfaBats", (num + 1));
          }
          if(posnum == 3 && Vector2.Distance( pos3.position, Player.position) > 15)
          {
            Instantiate(Bat, pos3.position, Quaternion.identity);
            TotalEnemiesSpawned++;
            PlayerPrefs.SetInt("numberOfaBats", (num + 1));
          }
          if(posnum == 4 && Vector2.Distance( pos4.position, Player.position) > 15)
          {
            Instantiate(Bat, pos4.position, Quaternion.identity);
            TotalEnemiesSpawned++;
            PlayerPrefs.SetInt("numberOfaBats", (num + 1));
          }
          if(posnum == 5 && Vector2.Distance( pos5.position, Player.position) > 15)
          {
            Instantiate(Bat, pos5.position, Quaternion.identity);
            TotalEnemiesSpawned++;
            PlayerPrefs.SetInt("numberOfaBats", (num + 1));
          }
          if(posnum == 6 && Vector2.Distance( pos6.position, Player.position) > 15)
          {
            Instantiate(Bat, pos6.position, Quaternion.identity);
            TotalEnemiesSpawned++;
            PlayerPrefs.SetInt("numberOfaBats", (num + 1));
          }
          if(posnum == 7 && Vector2.Distance( pos7.position, Player.position) > 15)
          {
            Instantiate(Bat, pos7.position, Quaternion.identity);
            TotalEnemiesSpawned++;
            PlayerPrefs.SetInt("numberOfaBats", (num + 1));
          }
          if(posnum == 8 && Vector2.Distance( pos8.position, Player.position) > 15)
          {
            Instantiate(Bat, pos8.position, Quaternion.identity);
            TotalEnemiesSpawned++;
            PlayerPrefs.SetInt("numberOfaBats", (num + 1));
          }
          if(posnum == 9 && Vector2.Distance( pos9.position, Player.position) > 15)
          {
            Instantiate(Bat, pos9.position, Quaternion.identity);
            TotalEnemiesSpawned++;
            PlayerPrefs.SetInt("numberOfaBats", (num + 1));
          }
          if(posnum == 10 && Vector2.Distance( pos10.position, Player.position) > 15)
          {
            Instantiate(Bat, pos10.position, Quaternion.identity);
            TotalEnemiesSpawned++;
            PlayerPrefs.SetInt("numberOfaBats", (num + 1));
          }
          if(posnum == 11 && Vector2.Distance( pos11.position, Player.position) > 15)
          {
            Instantiate(Bat, pos11.position, Quaternion.identity);
            TotalEnemiesSpawned++;
            PlayerPrefs.SetInt("numberOfaBats", (num + 1));
          }
         
          
        }
    }

    public void WaveOfBat(int x)
    {
      TotalEnemiesSpawned += 19;

      Instantiate(Bat,new Vector3(Player.position.x + 20f, Player.position.y +x, Player.position.z), Quaternion.identity);
      Instantiate(Bat,new Vector3 (Player.position.x + 16f, Player.position.y +4f +x, Player.position.z), Quaternion.identity);
      Instantiate(Bat,new Vector3 (Player.position.x + 12f, Player.position.y +8f +x, Player.position.z), Quaternion.identity);
      Instantiate(Bat,new Vector3 (Player.position.x + 8f, Player.position.y +12f +x, Player.position.z), Quaternion.identity);
      Instantiate(Bat,new Vector3 (Player.position.x + 4f, Player.position.y +16f +x, Player.position.z), Quaternion.identity);
      
      Instantiate(Bat,new Vector3 (Player.position.x + 16f, Player.position.y -4f -x, Player.position.z), Quaternion.identity);
      Instantiate(Bat,new Vector3 (Player.position.x + 12f, Player.position.y -8f-x, Player.position.z), Quaternion.identity);
      Instantiate(Bat,new Vector3 (Player.position.x + 8f, Player.position.y -12f-x, Player.position.z), Quaternion.identity);
      Instantiate(Bat,new Vector3 (Player.position.x + 4f, Player.position.y -16f-x, Player.position.z), Quaternion.identity);
      Instantiate(Bat,new Vector3 (Player.position.x , Player.position.y -20f-x, Player.position.z), Quaternion.identity);

      Instantiate(Bat,new Vector3(Player.position.x - 20f, Player.position.y +x, Player.position.z), Quaternion.identity);
      Instantiate(Bat,new Vector3 (Player.position.x - 16f, Player.position.y +4f+x, Player.position.z), Quaternion.identity);
      Instantiate(Bat,new Vector3 (Player.position.x - 12f, Player.position.y +8f+x, Player.position.z), Quaternion.identity);
      Instantiate(Bat,new Vector3 (Player.position.x - 8f, Player.position.y +12f+x, Player.position.z), Quaternion.identity);
      Instantiate(Bat,new Vector3 (Player.position.x - 4f, Player.position.y +16f+x, Player.position.z), Quaternion.identity);
      
      Instantiate(Bat,new Vector3 (Player.position.x - 16f, Player.position.y -4f+x, Player.position.z), Quaternion.identity);
      Instantiate(Bat,new Vector3 (Player.position.x - 12f, Player.position.y -8f+x, Player.position.z), Quaternion.identity);
      Instantiate(Bat,new Vector3 (Player.position.x - 8f, Player.position.y -12f+x, Player.position.z), Quaternion.identity);
      Instantiate(Bat,new Vector3 (Player.position.x - 4f, Player.position.y -16f+x, Player.position.z), Quaternion.identity);
      

      
    }

}
