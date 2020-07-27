using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MetreScript : MonoBehaviour
{
    private Rigidbody2D MyBody;
   // [HideInInspector]
    public float Speed=50f;

    public Text MeterText;
    [HideInInspector]
    public static bool TakeMeter;
    private void Awake()
    {
        MyBody = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        MyBody.velocity = new Vector2(Speed, 0f);
    }

    
    void Update()
    {
        if (TakeMeter)
        {
            PlayerPrefs.SetInt("CurrentMeter", (int)transform.position.x);
        }
        // SpeedController();
        ControlSpawnSpeed();
        MeterText.text = transform.position.x.ToString("0");
    }

 /*   void SpeedController()
    {
        Vector2 temp = transform.position;
        if (temp.x > 60 && temp.x<120)
        {
            Debug.Log("phase 1");
            BGscroll.instance.ScrollSpeed = -0.3f;
            ObjSpeed.instance.Speed = -7.2f;
            Spawnner.instance.TimeWhat = 0f;
            Debug.Log(Spawnner.instance.TimeWhat);
            Spawnner.instance.LetBool = false;

            Spawnner.instance.Phase0 = false;
            Spawnner.instance.Phase1 = true;
            Spawnner.instance.Phase2 = false;
            Spawnner.instance.Phase3 = false;
            Spawnner.instance.Phase4 = false;
        }
        else if (temp.x > 120 && temp.x < 180)
        {
            Debug.Log("Phase 2");
            BGscroll.instance.ScrollSpeed = -0.35f;
            ObjSpeed.instance.Speed = -8.4f;
            Spawnner.instance.TimeWhat = 1.0f;

            Spawnner.instance.Phase0 = false;
            Spawnner.instance.Phase1 = false;
            Spawnner.instance.Phase2 = true;
            Spawnner.instance.Phase3 = false;
            Spawnner.instance.Phase4 = false;
        }
        else if(temp.x > 180 && temp.x <240)
        {
            Debug.Log("Phase 3");
            BGscroll.instance.ScrollSpeed = -0.4f;
            ObjSpeed.instance.Speed = -9.6f;
            Spawnner.instance.TimeWhat = 1.25f;

            Spawnner.instance.Phase0 = false;
            Spawnner.instance.Phase1 = false;
            Spawnner.instance.Phase2 = false;
            Spawnner.instance.Phase3 = true;
            Spawnner.instance.Phase4 = false;
        }
        else if(temp.x > 240 && temp.x < 300)
        {
            Debug.Log("Phase 4");
            BGscroll.instance.ScrollSpeed = -0.45f;
            ObjSpeed.instance.Speed = -10.8f;
            Spawnner.instance.TimeWhat = 1.5f;

            Spawnner.instance.Phase0 = false;
            Spawnner.instance.Phase1 = false;
            Spawnner.instance.Phase2 = false;
            Spawnner.instance.Phase3 = false;
            Spawnner.instance.Phase4 = true;
        }

        else
        {
            Debug.Log("Phase 0");
            Spawnner.instance.Phase0 = true;
            Spawnner.instance.Phase1 = false;
            Spawnner.instance.Phase2 = false;
            Spawnner.instance.Phase3 = false;
            Spawnner.instance.Phase4 = false;
        }
    }*/

    void ControlSpawnSpeed()
    {
        Vector2 temp = transform.position;
        if (temp.x > 0 && temp.x <80)
        {
            //SpawnNew.instance.SpawnTime = 0.5f;
            SpawnNew.SpawnTime = 0.5f;
            BGscroll.instance.ScrollSpeed = -0.3f;
            //ObjSpeed.instance.Speed = -6f;
            ObjSpeed.Speed = -6f;
            Debug.Log("a");
        }
        if (temp.x > 80 && temp.x < 160)
        {
            /*  SpawnNew.instance.SpawnTime = 0.8f;
              BGscroll.instance.ScrollSpeed = -0.33f;
              ObjSpeed.instance.Speed = -7.2f;
              Debug.Log("b");
              Debug.Log(SpawnNew.instance.SpawnTime);*/
            // SpawnNew.instance.SpawnTime = 0.65f;
            //  SpawnNew.SpawnTime = 0.65f;
            SpawnNew.SpawnTime = 0.46f;
            BGscroll.instance.ScrollSpeed = -0.35f;
            //ObjSpeed.instance.Speed = -6f;
            ObjSpeed.Speed = -7.2f;

        }
        if (temp.x > 160 && temp.x < 240)
        {
            /* SpawnNew.instance.SpawnTime = 1.1f;
             BGscroll.instance.ScrollSpeed = -0.36f;
             ObjSpeed.instance.Speed = -8.4f;
             Debug.Log("c");
             Debug.Log(SpawnNew.instance.SpawnTime);*/
            // SpawnNew.instance.SpawnTime = 0.8f;
            //  SpawnNew.SpawnTime = 0.8f;
            SpawnNew.SpawnTime = 0.42f;
            BGscroll.instance.ScrollSpeed = -0.40f;
            // ObjSpeed.instance.Speed = -6f;
            ObjSpeed.Speed = -8.4f;
        }
        if (temp.x >240 && temp.x < 320)
        {
            /* SpawnNew.instance.SpawnTime = 1.4f;
             BGscroll.instance.ScrollSpeed = -0.39f;
             ObjSpeed.instance.Speed = -9.6f;
             Debug.Log("d");
             Debug.Log(SpawnNew.instance.SpawnTime);*/
            //    SpawnNew.instance.SpawnTime = 0.95f;
            //   SpawnNew.SpawnTime = 0.95f;
            SpawnNew.SpawnTime = 0.38f;
            BGscroll.instance.ScrollSpeed = -0.45f;
            //  ObjSpeed.instance.Speed = -6f;
            ObjSpeed.Speed = -9.6f;
        }
        if (temp.x > 320 && temp.x < 400)
        {
            //  SpawnNew.instance.SpawnTime = 1.10f;
            //  SpawnNew.SpawnTime = 1.1f;
            SpawnNew.SpawnTime = 0.34f;
            BGscroll.instance.ScrollSpeed = -0.5f;
            ObjSpeed.Speed = -10.8f;
        }
        if (temp.x > 400 && temp.x < 480)
        {
            //SpawnNew.instance.SpawnTime = 1.25f;
            //  SpawnNew.SpawnTime = 1.25f;
            SpawnNew.SpawnTime = 0.3f;
            BGscroll.instance.ScrollSpeed = -0.55f;
            ObjSpeed.Speed = -12.0f;
        }
        if (temp.x > 480 && temp.x < 560)
        {
            // SpawnNew.instance.SpawnTime = 1.4f;
            //  SpawnNew.SpawnTime = 1.4f;
            SpawnNew.SpawnTime = 0.26f;
            BGscroll.instance.ScrollSpeed = -0.60f;
            ObjSpeed.Speed = -13.2f;
        }
        if (temp.x > 560 && temp.x < 640)
        {
            //  SpawnNew.instance.SpawnTime = 1.55f;
            //    SpawnNew.SpawnTime = 1.55f;
            SpawnNew.SpawnTime = 0.22f;
            BGscroll.instance.ScrollSpeed = -0.65f;
            ObjSpeed.Speed = -14.4f;
        }
        if (temp.x > 640 && temp.x < 720)
        {
            //SpawnNew.instance.SpawnTime = 1.7f;
            //  SpawnNew.SpawnTime = 1.7f;
            SpawnNew.SpawnTime = 0.20f;
            BGscroll.instance.ScrollSpeed = -0.7f;
            ObjSpeed.Speed = -14.42f;
        }
        if (temp.x > 720 && temp.x < 800)
        {
            //SpawnNew.instance.SpawnTime = 1.7f;
            //  SpawnNew.SpawnTime = 1.7f;
            SpawnNew.SpawnTime = 0.20f;
            BGscroll.instance.ScrollSpeed = -0.75f;
            ObjSpeed.Speed = -14.44f;
        }
        if (temp.x > 800 && temp.x < 880)
        {
            //SpawnNew.instance.SpawnTime = 1.7f;
            //  SpawnNew.SpawnTime = 1.7f;
            SpawnNew.SpawnTime = 0.20f;
            BGscroll.instance.ScrollSpeed = -0.8f;
            ObjSpeed.Speed = -14.46f;
        }
        if (temp.x > 880 && temp.x < 960)
        {
            //SpawnNew.instance.SpawnTime = 1.7f;
            //  SpawnNew.SpawnTime = 1.7f;
            SpawnNew.SpawnTime = 0.20f;
            BGscroll.instance.ScrollSpeed = -0.85f;
            ObjSpeed.Speed = -14.48f;
        }
        if (temp.x > 960 && temp.x < 1040)
        {
            SpawnNew.SpawnTime = 0.20f;
            BGscroll.instance.ScrollSpeed = -0.9f;
            ObjSpeed.Speed = -14.50f;
        }
        /* if(temp.x>0 && temp.x < 60)
         {
             SpawnNew.instance.SpawnTime = 0.05f;
         }

         else if( temp.x>60 && temp.x < 120)
         {
             SpawnNew.instance.SpawnTime = 0.05f;
         }*/
    }
}
