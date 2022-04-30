using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowFall : MonoBehaviour
{
    [SerializeField] GameObject snowPartical;
    [SerializeField] GameObject rainPartical ;

    [SerializeField] bool isRaning = false;

    [SerializeField] float  timeToStartRaining;
    [SerializeField] float  timeToStartSnow;
    [SerializeField] float  timeBtwRaninSnow;

    // Start is called before the first frame update
    void Start()
    {
         snowPartical.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
      
        if( timeToStartRaining <=0)
        {
            rainPartical.SetActive(true);
            isRaning = true;
        }
        else
        {
            timeToStartRaining  -= Time.deltaTime;
        }

        if(isRaning )
        {
            if(timeToStartSnow <=0)
            {
                snowPartical.SetActive(true);
                if(timeBtwRaninSnow <=0)
                {
                    rainPartical.SetActive(false);
                }
                else
                {
                    timeBtwRaninSnow -= Time.deltaTime;
                }
            }
            else
            {
                timeToStartSnow -= Time.deltaTime;
            }
        }
    }
}
