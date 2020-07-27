using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star2xScript : MonoBehaviour
{
 
   
   
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {

            Destroy(gameObject);
           // HealthBarScript.instance.HealthBar.SetActive(true);
            HealthBarScript.instance.TwoX();
            SoundManager.instance.MagnetSoundPlay();
          
          
        }
    }

  
}
