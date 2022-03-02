using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightFlickering : MonoBehaviour
{
    private Light light;
    private bool isLightOn;
    private float timeBetweenFlicker;

    [SerializeField]
    float lightIntensity = 1f;

    // Start is called before the first frame update
    void Start()
    {
        light = GetComponent<Light>();
        timeBetweenFlicker = Random.Range(0.01f, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        if (timeBetweenFlicker > 0)
        {
            timeBetweenFlicker -= Time.deltaTime;
        }
        else
        {
            if (isLightOn)
            {
                light.intensity = 0;
                isLightOn = false;
            }
            else
            {
                light.intensity = 1 * lightIntensity;
                isLightOn = true;
            }

            timeBetweenFlicker = Random.Range(0.01f, 0.5f);
        }
    }
}
