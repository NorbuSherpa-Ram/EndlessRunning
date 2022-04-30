using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerManager : MonoBehaviour
{

    public GameObject[] obstaclePatterns;

    [SerializeField] float timeBtwSpawn = 1.5f;
    [SerializeField] float resetTime;
    [SerializeField] float decreaseTime = 0.1f;
    [SerializeField] float minTime = 0.7f;

    private void Start()
    {
        resetTime = timeBtwSpawn;
    }
    // Update is called once per frame
    void Update()
    {
        if (timeBtwSpawn <= 0)
        {
            int randomIndex = Random.Range(0, obstaclePatterns.Length);
            Instantiate(obstaclePatterns [randomIndex ], transform.position, Quaternion.identity);
            timeBtwSpawn = resetTime;
            if (resetTime > minTime)
            {
                resetTime -= decreaseTime;
            }
        }
        else
        {
            timeBtwSpawn  -= Time.deltaTime;
        }
    }
}
