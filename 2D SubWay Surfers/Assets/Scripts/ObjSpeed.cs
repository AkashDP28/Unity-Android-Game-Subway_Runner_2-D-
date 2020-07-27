using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjSpeed : MonoBehaviour
{
    public static float Speed;
    [HideInInspector]
    public Rigidbody2D MyBody;

    public static ObjSpeed instance;


    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        MyBody = GetComponent<Rigidbody2D>();
        
      //  Debug.Log("Speed");
    }
    public void Update()
    {
        if (!GameManager.instance.IsPlayerDead)
        {
            MyBody.velocity = new Vector2(Speed, 0f);
        }
        if (GameManager.instance.IsPlayerDead)
        {
            MyBody.velocity = new Vector2(0f, 0f);
        }
    }
}
