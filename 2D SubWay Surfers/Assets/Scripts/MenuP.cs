using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuP : MonoBehaviour
{
    private Animator anim;
    bool idle;
    bool dead;
    public static MenuP instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
      //  idle = true;
        anim = GetComponent<Animator>();
    }
    private void Update()
    {
        if (GameManager.instance.IsPlayerDead)
        {
            dead = true;
            idle = false;
        }
        if (idle)
        {
            anim.Play("MenuPidle");
        }
        if (dead)
        {
            anim.Play("MenuPDead");
            dead = false;
            idle = true;
        }
    }
  /*  public void Trigged()
    {
        anim.SetTrigger("Dead");
    }*/
}
