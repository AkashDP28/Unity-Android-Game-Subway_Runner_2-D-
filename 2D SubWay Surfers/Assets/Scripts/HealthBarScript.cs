using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarScript : MonoBehaviour
{
    public Slider slider;
    public static HealthBarScript instance;
    [HideInInspector]
    public int MaxTime = 100;
    [HideInInspector]
    public float CurrentTime;
    bool Two;
    public GameObject HealthBar;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

  
    public void Update()
    {
        if (!GameManager.instance.IsPlayerDead)
        {
            if (Two)
            {
                CurrentTime -= 8 * Time.deltaTime;
                SetHealth(CurrentTime);
                PlayerSafe.Double = true;
                if (CurrentTime <= 0)
                {
                    Two = false;
                    PlayerSafe.Double = false;
                    //  HealthBar.SetActive(false);
                }
            }
        }
    }

    public void SetHealth(float Health)
    {
        slider.value = Health;
    }

    public void SetMaxHealth(int Health)
    {
        slider.maxValue = Health;
        slider.value = Health;
    }

    public void TwoX()
    {
        SetMaxHealth(MaxTime);
        CurrentTime = MaxTime;
        Two = true;
      //  HealthBar.SetActive(true);
    }
}
