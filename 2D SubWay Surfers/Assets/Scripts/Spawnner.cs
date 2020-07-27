using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawnner : MonoBehaviour
{
    public GameObject[] BigTrainPrefab;
    public GameObject[] Train1Prefab;
    public GameObject[] Train2Prefab;
    public GameObject[] GoodPrefab;
    public GameObject[] ObsPrefab;
    public GameObject CoinPrefab;

    public float Timer,TimeWhat=0.5f;

   // public float TimeBigTrain, TimeTrain1, TimeTrain2, TimeGood, TimeObs, TimeCoin;
    public static Spawnner instance;

    public bool Phase0, Phase1, Phase2, Phase3, Phase4;
    public bool LetBool;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    void FixedUpdate()
    {
        if (!LetBool)
        {
            // TimeDekho();
            Timer = Random.Range(2, 6);
            if (!GameManager.instance.IsPlayerDead)
            {
                Invoke("Spawn", Timer);
            }
        }
    }
    public void Update()
    {
        LetBool = true;
    }
    /*   public void TimeDekho()
       {
           TimeBigTrain =TimeWhat+2;
           TimeTrain1 = TimeWhat +0.5f;
           TimeTrain2 = TimeWhat +1.5f;
           TimeGood = TimeWhat +0.2f;
           TimeObs = TimeWhat +0.1f;
           TimeCoin = TimeWhat;
       }*/
    void Spawn()
    {
        if (!GameManager.instance.IsPlayerDead)
        {
            if (Random.Range(0, 4) > 2)
            {
                SpawnObj();
            }
            else
            {
                SpawnCoin();
            }
            //     Invoke("Spawn",0.5f);
            Invoke("Spawn", TimeWhat);
        }
    }
    void SpawnObj()
    {
        if (!GameManager.instance.IsPlayerDead)
        {

            if (Random.Range(0, 7) > 5)
            {
                Instantiate(ObsPrefab[Random.Range(0, ObsPrefab.Length)], transform.position, Quaternion.identity);
             
            }
            else if (Random.Range(0, 7) > 4)
            {
                Instantiate(Train1Prefab[Random.Range(0, Train1Prefab.Length)], transform.position, Quaternion.identity);
               
            }
            else if (Random.Range(0, 7) > 3)
            {
                Instantiate(Train2Prefab[Random.Range(0, Train2Prefab.Length)], transform.position, Quaternion.identity);
               
            }
            else if (Random.Range(0, 7) > 2)
            {
                Instantiate(GoodPrefab[Random.Range(0, GoodPrefab.Length)], transform.position, Quaternion.identity);
                
            }
            else if (Random.Range(0, 7) > 0)
            {
                Instantiate(BigTrainPrefab[Random.Range(0, BigTrainPrefab.Length)], transform.position, Quaternion.identity);
               
            }
            
        }
    }

    void SpawnCoin()
    {
        if (!GameManager.instance.IsPlayerDead)
        {
            Instantiate(CoinPrefab, transform.position, Quaternion.identity);

           
        }
    }
}
