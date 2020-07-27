using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BachaoScript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bachao")
        {
            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "Cleaner")
        {
            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "CR2")
        {
            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "CB2")
        {
            Destroy(gameObject);
            PlayerSafe.instance.CoinRun += 10;
        }
    }
}
