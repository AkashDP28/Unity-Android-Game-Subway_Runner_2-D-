using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleController : MonoBehaviour
{
    public GameObject Player;
    public bool IsDown;
    public bool IsUp;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (IsDown)
            {
                Vector2 temp = Player.transform.localScale;
                temp.y = 0.4f;
                Player.transform.localScale = temp;
            }
            if (IsUp)
            {
                Vector2 temp = Player.transform.localScale;
                temp.y = -0.4f;
                Player.transform.localScale = temp;
            }           
        }
    }
}
