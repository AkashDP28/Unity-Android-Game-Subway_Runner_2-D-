using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgScalar : MonoBehaviour
{
    /*   private void Start()
       {
           SpriteRenderer sr = GetComponent<SpriteRenderer>();
           transform.localScale = new Vector3(1, 1, 1);

           var Height = Camera.main.orthographicSize * 2.0f;
           //  var Width = Height * Screen.width / Screen.height;
           var Width = Height / Screen.height * Screen.width;
           transform.localScale = new Vector3(Width, Height, 1);
       }*/

    //  public SpriteRenderer sr;
    /*    private void Start()
        {
            SpriteRenderer sr = GetComponent<SpriteRenderer>();

           // transform.localScale = new Vector3(16.66665f, 10, 1);

            float Width = sr.sprite.bounds.size.x;
            float Hight = sr.sprite.bounds.size.y;

            float WorldHeight = Camera.main.orthographicSize * 2f;

            float WorldWidth = WorldHeight / Screen.height * Screen.width;

            Vector3 tempscale = transform.localScale;
            tempscale.x = WorldWidth / Width;
            tempscale.y = WorldHeight / Hight;
           // tempscale.x = 1f;
          //  tempscale.y = 1f;
            transform.localScale = tempscale;
        }*/

    private void Update()
    {
        float Height = Camera.main.orthographicSize * 2;
        float width = Height / Screen.height * Screen.width;
        Vector2 tempscale = transform.localScale;
        tempscale.y = Height;
        tempscale.x = width;
        transform.localScale = tempscale;
        
    }

}
