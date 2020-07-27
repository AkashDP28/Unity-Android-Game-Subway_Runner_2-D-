using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour
{
    public float LerpRate = 1f;
    GameObject Target;

    float TimeStamp;
    bool FlyToPlayer;
    Vector2 PlayerDirection;

    public static CoinScript instance;

    private Rigidbody2D MyBody;

    private void Awake()
    {
        MyBody = GetComponent<Rigidbody2D>();
        if (instance == null)
        {
            instance = this;
        }
    
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
    }

 
    private void Update()
    {
        if (!GameManager.instance.IsPlayerDead)
        {
            if (FlyToPlayer)
            {
                PlayerDirection = -(transform.position - Target.transform.position).normalized;
                MyBody.velocity = new Vector2(PlayerDirection.x, PlayerDirection.y) * 10f * (Time.time / TimeStamp);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "CoinMagnet")
        {
            TimeStamp = Time.time;
            Target = GameObject.FindWithTag("Player") as GameObject;
            FlyToPlayer = true;
        }
    }
}
