using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnNew : MonoBehaviour
{
    public GameObject[] BigTrainPrefab;
    public GameObject[] Train1Prefab;
    public GameObject[] Train2Prefab;
    public GameObject[] GoodPrefab;
 //   public GameObject[] MagnetPrefab;
  //  public GameObject[] StarPrefab;
  //  public GameObject[] BonusPrefab;
    public GameObject[] ObsPrefab;
    public GameObject CoinPrefab;

    public static SpawnNew instance;

    public bool Spawnned;
    //   [HideInInspector]
    public static float SpawnTime;//=0.5f;
    void Awake()
    {
     //   SpawnTime = 0.4f;
        if (instance == null)
        {
            instance = this;
        }
    }

    public void Update()
    {
        if (!Spawnned)
        {
            //  SpawnWithTimer(SpawnTime);
            if (!GameManager.instance.IsPlayerDead)
            {
                SpawnWithTimerSecond(SpawnTime);
            }
        }
    }

    void SpawnWithTimerSecond(float Timer)
    {
        if (Random.Range(0, 4) > 2)
        {
            //   SpawnObj();
            if (Random.Range(0, 9) > 5)
            {
                Instantiate(ObsPrefab[Random.Range(0, ObsPrefab.Length)], transform.position, Quaternion.identity);
                Invoke("SpawnWithTimerSecond", Timer);
                Spawnned = true;
                Invoke("MakeTrue", Timer * 1.2f);

            }
            else if (Random.Range(0, 9) > 4)
            {
                Instantiate(Train1Prefab[Random.Range(0, Train1Prefab.Length)], transform.position, Quaternion.identity);
                Invoke("SpawnWithTimerSecond", Timer);
                Spawnned = true;
                Invoke("MakeTrue", Timer * 2f);

            }
            else if (Random.Range(0, 9) > 3)
            {
                Instantiate(Train2Prefab[Random.Range(0, Train2Prefab.Length)], transform.position, Quaternion.identity);
                Invoke("SpawnWithTimerSecond", Timer);
                Spawnned = true;
                Invoke("MakeTrue", Timer * 4f);

            }
            else if (Random.Range(0, 9) > 2)
            {
                Instantiate(GoodPrefab[Random.Range(0, GoodPrefab.Length)], transform.position, Quaternion.identity);
                Invoke("SpawnWithTimerSecond", Timer);
                Spawnned = true;
                Invoke("MakeTrue", Timer * 1.4f);

            }
            else if (Random.Range(0, 9) > 0)
            {
                Instantiate(BigTrainPrefab[Random.Range(0, BigTrainPrefab.Length)], transform.position, Quaternion.identity);
                Invoke("SpawnWithTimerSecond", Timer);
                Spawnned = true;
                Invoke("MakeTrue", Timer * 5);

            }

        }
        else
        {
            // SpawnCoin();
            Instantiate(CoinPrefab, transform.position, Quaternion.identity);
            Invoke("SpawnWithTimerSecond", Timer);
            Spawnned = true;
            Invoke("MakeTrue", Timer);
        }
    }
  /*  void SpawnWithTimer(float Timer)
    {
        if (Random.Range(0, 10) > 6)
        {

            if (Random.Range(0, 53) > 0 && Random.Range(0, 53) < 2)
            {
                Instantiate(CoinPrefab, transform.position, Quaternion.identity);
                Invoke("SpawnWithTimer", Timer);
                Spawnned = true;
                Invoke("MakeTrue", Timer);
            }

            else if (Random.Range(0, 53) > 1 && Random.Range(0, 53) < 10)
            {
                Instantiate(ObsPrefab[Random.Range(0, ObsPrefab.Length)], transform.position, Quaternion.identity);
                Invoke("SpawnWithTimer", Timer);
                Spawnned = true;
                Invoke("MakeTrue", Timer*1.2f);
            }
            else if (Random.Range(0, 53) > 9 && Random.Range(0, 53) < 12)
            {
                Instantiate(MagnetPrefab[Random.Range(0, MagnetPrefab.Length)], transform.position, Quaternion.identity);
                Invoke("SpawnWithTimer", Timer);
                Spawnned = true;
                Invoke("MakeTrue", Timer*1.4f);
            }
            else if (Random.Range(0, 53) > 11 && Random.Range(0, 53) < 14)
            {
                Instantiate(StarPrefab[Random.Range(0, StarPrefab.Length)], transform.position, Quaternion.identity);
                Invoke("SpawnWithTimer", Timer);
                Spawnned = true;
                Invoke("MakeTrue", Timer*1.4f);
            }
            else if (Random.Range(0, 53) == 14)
            {
                Instantiate(BonusPrefab[Random.Range(0, BonusPrefab.Length)], transform.position, Quaternion.identity);
                Invoke("SpawnWithTimer", Timer);
                Spawnned = true;
                Invoke("MakeTrue", Timer*1.4f);
            }
            else if (Random.Range(0, 53) > 14 && Random.Range(0, 53) < 21)
            {
                Instantiate(BigTrainPrefab[Random.Range(0, BigTrainPrefab.Length)], transform.position, Quaternion.identity);
                Invoke("SpawnWithTimer", Timer);
                Spawnned = true;
                Invoke("MakeTrue", Timer*5);
            }
            else if (Random.Range(0, 53) > 20 && Random.Range(0, 53) < 37)
            {
                Instantiate(Train1Prefab[Random.Range(0, Train1Prefab.Length)], transform.position, Quaternion.identity);
                Invoke("SpawnWithTimer", Timer);
                Spawnned = true;
                Invoke("MakeTrue", Timer*2f);
            }
            else if (Random.Range(0, 53) > 36 && Random.Range(0, 53) < 49)
            {
                Instantiate(Train2Prefab[Random.Range(0, Train2Prefab.Length)], transform.position, Quaternion.identity);
                Invoke("SpawnWithTimer", Timer);
                Spawnned = true;
                Invoke("MakeTrue", Timer*4f);
            }
            else if (Random.Range(0, 53) > 48 && Random.Range(0, 53) < 53)
            {
                Instantiate(CoinPrefab, transform.position, Quaternion.identity);
                Invoke("SpawnWithTimer", Timer);
                Spawnned = true;
                Invoke("MakeTrue", Timer);
            }
            else
            {
                Instantiate(Train2Prefab[Random.Range(0, Train2Prefab.Length)], transform.position, Quaternion.identity);
                Invoke("SpawnWithTimer", Timer);
                Spawnned = true;
                Invoke("MakeTrue", Timer*4f);
            }
        }
        else if (Random.Range(0, 10) < 7)
        {
            Instantiate(CoinPrefab, transform.position, Quaternion.identity);
            Invoke("SpawnWithTimer", Timer);
            Spawnned = true;
            Invoke("MakeTrue", Timer);
        }

    
    }
    */
    void MakeTrue()
    {
        Spawnned = false;
    }
 /*   IEnumerator WaitSpawn(float timer)
    {
        yield return new WaitForSeconds(timer);
        if (Random.Range(0, 2) > 0)
        {
            Instantiate(CoinPrefab, transform.position, Quaternion.identity);
            StartCoroutine("WaitSpawn",timer);
        }

        else if (Random.Range(0, 2) == 0)
        {
            Instantiate(ObsPrefab[Random.Range(0, ObsPrefab.Length)], transform.position, Quaternion.identity);
            StartCoroutine("WaitSpawn", timer);
        }
    }*/
}
