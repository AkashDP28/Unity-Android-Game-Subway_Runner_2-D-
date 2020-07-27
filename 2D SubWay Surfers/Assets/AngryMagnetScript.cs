using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngryMagnetScript : MonoBehaviour
{
    //  GameObject Target11;
    // GameObject[] Target1,Target2,Target3,Target4,Target5,Target6,Target7,Target8,Target9,Target10,Target11;
    /*   public GameObject Target1;
       public GameObject Target2;
       public GameObject Target3;
       public GameObject Target4;
       public GameObject Target5;
       public GameObject Target6;
       public GameObject Target7;
       public GameObject Target8;
       public GameObject Target9;
       public GameObject Target10;
       public GameObject Target11;*/

    /*  GameObject Target2;
      GameObject Target3;
      GameObject Target4;
      GameObject Target5;
      GameObject Target6;
      GameObject Target7;
      GameObject Target8;
      GameObject Target9;
      GameObject Target10;*/
    /*  float TimeStamp;
      float TimeStamp1, TimeStamp2, TimeStamp3, TimeStamp4, TimeStamp5, TimeStamp6, TimeStamp7, TimeStamp8, TimeStamp9, TimeStamp10, TimeStamp11;
      bool FlyToPlayer;
      bool FlyToPlayer1, FlyToPlayer2, FlyToPlayer3, FlyToPlayer4, FlyToPlayer5, FlyToPlayer6, FlyToPlayer7, FlyToPlayer8, FlyToPlayer9, FlyToPlayer10, FlyToPlayer11;
      Vector2 ObsDirection;
      Vector2 ObsDirection1, ObsDirection2, ObsDirection3, ObsDirection4, ObsDirection5, ObsDirection6, ObsDirection7, ObsDirection8, ObsDirection9, ObsDirection10, ObsDirection11;
      public GameObject[] Bombs;

      public GameObject Player;*/
    //  GameObject[] AllObs;
    // Rigidbody2D BombBody;


    private void Awake()
    {
        // Bombs = GameObject.FindWithTag("Bombs") as GameObject;
        //  BombBody = Bombs.gameObject.GetComponent<Rigidbody2D>() as Rigidbody2D;
        // BombBody = Bombs.GetComponent<Rigidbody2D>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        /*  if (collision.gameObject.tag == "AllObs")
           {
               Debug.Log("AAya");
               TimeStamp = Time.time;
               Target = GameObject.FindWithTag("AllObs") as GameObject;
               FlyToPlayer = true;
               Instantiate(Bombs, Player.transform.position, Quaternion.identity);
           }*/


        /*     if (collision.gameObject.tag == "BT1")
             {
                 Debug.Log("AAya");
                 TimeStamp1 = Time.time;
                 Target1 = GameObject.FindWithTag("BT1") as GameObject;
                 FlyToPlayer1 = true;
                 Instantiate(Bombs[0], Player.transform.position, Quaternion.identity);
             }
             if (collision.gameObject.tag == "BT2")
             {
                 Debug.Log("AAya");
                 TimeStamp2 = Time.time;
                 Target2 = GameObject.FindWithTag("BT2") as GameObject;
                 FlyToPlayer2 = true;
                 Instantiate(Bombs[1], Player.transform.position, Quaternion.identity);
             }
            if (collision.gameObject.tag == "BT5")
             {
                 Debug.Log("AAya");
                 TimeStamp3 = Time.time;
                 Target3 = GameObject.FindWithTag("BT5") as GameObject;
                 FlyToPlayer3 = true;
                 Instantiate(Bombs[2], Player.transform.position, Quaternion.identity);
             }
            if (collision.gameObject.tag == "O1")
             {
                 Debug.Log("AAya");
                 TimeStamp4 = Time.time;
                 Target4 = GameObject.FindWithTag("O1") as GameObject;
                 FlyToPlayer4 = true;
                 Instantiate(Bombs[3], Player.transform.position, Quaternion.identity);
             }
            if (collision.gameObject.tag == "O2")
             {
                 Debug.Log("AAya");
                 TimeStamp5 = Time.time;
                 Target5 = GameObject.FindWithTag("O2") as GameObject;
                 FlyToPlayer5 = true;
                 Instantiate(Bombs[4], Player.transform.position, Quaternion.identity);
             }
             if (collision.gameObject.tag == "RT1")
             {
                 Debug.Log("AAya");
                 TimeStamp6 = Time.time;
                 Target6 = GameObject.FindWithTag("RT1") as GameObject;
                 FlyToPlayer6 = true;
                 Instantiate(Bombs[5], Player.transform.position, Quaternion.identity);
             }
             if (collision.gameObject.tag == "RT2")
             {
                 Debug.Log("AAya");
                 TimeStamp7 = Time.time;
                 Target7 = GameObject.FindWithTag("RT2") as GameObject;
                 FlyToPlayer7 = true;
                 Instantiate(Bombs[6], Player.transform.position, Quaternion.identity);
             }
             if (collision.gameObject.tag == "RT4")
             {
                 Debug.Log("AAya");
                 TimeStamp8 = Time.time;
                 Target8 = GameObject.FindWithTag("RT4") as GameObject;
                 FlyToPlayer8 = true;
                 Instantiate(Bombs[7], Player.transform.position, Quaternion.identity);
             }
             if (collision.gameObject.tag == "YT1")
             {
                 Debug.Log("AAya");
                 TimeStamp9 = Time.time;
                 Target9 = GameObject.FindWithTag("YT1") as GameObject;
                 FlyToPlayer9 = true;
                 Instantiate(Bombs[8], Player.transform.position, Quaternion.identity);
             }
             if (collision.gameObject.tag == "YT2")
             {
                 Debug.Log("AAya");
                 TimeStamp10 = Time.time;
                 Target10 = GameObject.FindWithTag("YT2") as GameObject;
                 FlyToPlayer10 = true;
                 Instantiate(Bombs[9], Player.transform.position, Quaternion.identity);
             }
             if (collision.gameObject.tag == "YT5")
             {
                 Debug.Log("AAya");
                 TimeStamp11 = Time.time;
                 Target11 = GameObject.FindWithTag("YT5") as GameObject;
                 FlyToPlayer11 = true;
                 Instantiate(Bombs[10], Player.transform.position, Quaternion.identity);
             }
         }*/

        /*   private void Update()
           {


             /*  if (FlyToPlayer)
               {
                   ObsDirection = ( Target.transform.position - Player.transform.position).normalized;
                   //  BombBody.velocity = new Vector2(ObsDirection.x, ObsDirection.y) * 10f * (Time.time / TimeStamp);
                   // Debug.Log("Yeeeeeeeeeeee");
                   BombScript.MyBody.velocity = new Vector2(ObsDirection.x, ObsDirection.y) * 10f * (Time.time / TimeStamp);
               }*/
        /*      if (FlyToPlayer1)
              {
                  ObsDirection1 = (Target1.transform.position - Player.transform.position).normalized;
                  BombScript.instance.MyBody.velocity = new Vector2(ObsDirection1.x, ObsDirection1.y) * 10f * (Time.time / TimeStamp1);
              }
              if (FlyToPlayer2)
              {
                  ObsDirection2 = (Target1.transform.position - Player.transform.position).normalized;
                  BombScript.instance.MyBody.velocity = new Vector2(ObsDirection2.x, ObsDirection2.y) * 10f * (Time.time / TimeStamp2);
              }
              if (FlyToPlayer3)
              {
                  ObsDirection3 = (Target1.transform.position - Player.transform.position).normalized;
                  BombScript.instance.MyBody.velocity = new Vector2(ObsDirection3.x, ObsDirection3.y) * 10f * (Time.time / TimeStamp3);
              }
              if (FlyToPlayer4)
              {
                  ObsDirection4 = (Target1.transform.position - Player.transform.position).normalized;
                  BombScript.instance.MyBody.velocity = new Vector2(ObsDirection4.x, ObsDirection4.y) * 10f * (Time.time / TimeStamp4);
              }
              if (FlyToPlayer5)
              {
                  ObsDirection5 = (Target1.transform.position - Player.transform.position).normalized;
                  BombScript.instance.MyBody.velocity = new Vector2(ObsDirection5.x, ObsDirection5.y) * 10f * (Time.time / TimeStamp5);
              }
              if (FlyToPlayer6)
              {
                  ObsDirection6 = (Target1.transform.position - Player.transform.position).normalized;
                  BombScript.instance.MyBody.velocity = new Vector2(ObsDirection6.x, ObsDirection6.y) * 10f * (Time.time / TimeStamp6);
              }
              if (FlyToPlayer7)
              {
                  ObsDirection7 = (Target1.transform.position - Player.transform.position).normalized;
                  BombScript.instance.MyBody.velocity = new Vector2(ObsDirection7.x, ObsDirection7.y) * 10f * (Time.time / TimeStamp7);
              }
              if (FlyToPlayer8)
              {
                  ObsDirection8 = (Target1.transform.position - Player.transform.position).normalized;
                  BombScript.instance.MyBody.velocity = new Vector2(ObsDirection8.x, ObsDirection8.y) * 10f * (Time.time / TimeStamp8);
              }
              if (FlyToPlayer9)
              {
                  ObsDirection9 = (Target1.transform.position - Player.transform.position).normalized;
                  BombScript.instance.MyBody.velocity = new Vector2(ObsDirection9.x, ObsDirection9.y) * 10f * (Time.time / TimeStamp9);
              }
              if (FlyToPlayer10)
              {
                  ObsDirection10 = (Target1.transform.position - Player.transform.position).normalized;
                  BombScript.instance.MyBody.velocity = new Vector2(ObsDirection10.x, ObsDirection10.y) * 10f * (Time.time / TimeStamp10);
              }
              if (FlyToPlayer11)
              {
                  ObsDirection11 = (Target1.transform.position - Player.transform.position).normalized;
                  BombScript.instance.MyBody.velocity = new Vector2(ObsDirection11.x, ObsDirection11.y) * 10f * (Time.time / TimeStamp11);
              }

          }*/
    }//end
}
