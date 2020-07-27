using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    [HideInInspector]
    public static Rigidbody2D MyBody;

    public static PlayerScript instance;
    public GameObject CoinMagnet;//,PlayerSafe;
    public GameObject Particle,ParticleMagnet;
    bool Do;
    bool Invoked;

    private Animator anim;

    public GameObject RedCodeObj,RedCode2Obj;
    public GameObject BluePotionParticle,CB2;

    public Text RedText, BlueText;
    public void Awake()
    {
        anim = GetComponent<Animator>();
        if (instance == null)
        {
            instance = this;
        }
        MyBody = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        if (!PlayerPrefs.HasKey("RedNumber"))
        {
            PlayerPrefs.SetInt("RedNumber", 2);
        }
        if (!PlayerPrefs.HasKey("BlueNumber"))
        {
            PlayerPrefs.SetInt("BlueNumber", 2);
        }

    }
    public void Update()
    {
       // RedCode();
        if (Input.GetMouseButtonDown(0))
        {
         
            MyBody.gravityScale = -MyBody.gravityScale;
            Invoke("ChangeScale", 0.5f);
           
        }

        if (Do)
        {
            MyBody.gravityScale = 0f;
            Vector2 temp = transform.position;
            temp.y = 0;
            transform.position = temp;
         
        }
        //PotionText
        RedText.text = "x " + PlayerPrefs.GetInt("RedNumber");
        BlueText.text = "x " + PlayerPrefs.GetInt("BlueNumber");
    }

    void ChangeScale()
    {
        Vector2 temp = transform.localScale;
        temp.y = -temp.y;
        transform.localScale = temp;
    }
 
   public void DO()
    {
      
        SpawnZero.instance.Spawn();
        Do = true;
        Particle.SetActive(true);
        Invoke("Dont", 7f);
        anim.SetBool("IsSlide", true);
    }

   public void Dont()
    {
        MyBody.gravityScale = 3f;
        Vector3 tempScale = transform.localScale;
        tempScale.y = 0.4f;
        transform.localScale = tempScale;
        Do = false;
        Particle.SetActive(false);
        anim.SetBool("IsSlide", false);
    }

    public void ForMagnet()
    {
        if (!GameManager.instance.IsPlayerDead)
        {
            if (!Invoked)
            {
                // PlayerSafe.SetActive(true);
                CoinMagnet.SetActive(true);
                Invoke("StopMagnet", 6f);
                Invoked = true;
                ParticleMagnet.SetActive(true);
            }
        }
    }

    public void StopMagnet()
    {
      //  Invoke("Safe", 1f);
        CoinMagnet.SetActive(false);
        ParticleMagnet.SetActive(false);
        Invoked = false;
    }

    /*   public void Safe()
       {
           PlayerSafe.SetActive(false);
       }
       */

    public void RedCode()
    {
        if (PlayerPrefs.GetInt("RedNumber") > 0)
        {
            RedCodeObj.SetActive(true);
            RedCode2Obj.SetActive(true);
            StartCoroutine(StopCodeRed());
            PlayerPrefs.SetInt("RedNumber", PlayerPrefs.GetInt("RedNumber") - 1);
            
        }
    }

  /*  IEnumerator StopCodeRed()
    {
        yield return new WaitForSeconds(8f);
        RedCodeObj.SetActive(false);
        RedCode2Obj.SetActive(false);
    }*/

    IEnumerator StopCodeRed()
    {
        float time = 16f;
        while (time > 0)
        {
            SoundManager.instance.RedSoundPlay();
            yield return new WaitForSeconds(0.5f);
            time--;
        }
        
        RedCodeObj.SetActive(false);
        RedCode2Obj.SetActive(false);
    }

    public void InvincibleCode()
    {
        if (PlayerPrefs.GetInt("BlueNumber")>0)
        {
            BluePotionParticle.SetActive(true);
            CB2.SetActive(true);
            StartCoroutine(StopInvincibleCode());
            PlayerPrefs.SetInt("BlueNumber", PlayerPrefs.GetInt("BlueNumber") - 1);
        }
    }

   /* IEnumerator StopInvincibleCode()
    {
        yield return new WaitForSeconds(8f);
        BluePotionParticle.SetActive(false);
        CB2.SetActive(false);
    }*/

    IEnumerator StopInvincibleCode()
    {
        float time = 8f;
        while (time > 0)
        {
            SoundManager.instance.BlueSoundPlay();
            yield return new WaitForSeconds(1f);
            time--;
        }
        
        BluePotionParticle.SetActive(false);
        CB2.SetActive(false);
    }
}
