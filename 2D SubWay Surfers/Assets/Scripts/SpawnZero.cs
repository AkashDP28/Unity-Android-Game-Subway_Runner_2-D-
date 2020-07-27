using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnZero : MonoBehaviour
{
    public GameObject CoinZeroGPrefab;
    public GameObject[] Bonus;

    public static SpawnZero instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
   
   public void Spawn()
    {
        if (Random.Range(0, 5) > 0)
        {
            Instantiate(CoinZeroGPrefab, transform.position, Quaternion.identity);
        }
        else if(Random.Range(0,5)==0)
        {
            Instantiate(Bonus[Random.Range(0, Bonus.Length)], transform.position, Quaternion.identity);
        }
        Invoke("Spawn", 0.2f);
        StartCoroutine("Stop");
    }

    IEnumerator Stop()
    {
        yield return new WaitForSeconds(5.7f);
        CancelInvoke("Spawn");
    }
}
