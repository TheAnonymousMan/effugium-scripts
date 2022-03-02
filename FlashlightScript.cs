using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashlightScript : MonoBehaviour
{
    [SerializeField]
    private Light Flashlight;

    [SerializeField]
    private bool isFlashlightOn;

    // Start is called before the first frame update
    void Start()
    {
        isFlashlightOn = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (isFlashlightOn)
            {
                Flashlight.intensity = 0;
                isFlashlightOn = false;
            }
            else
            {
                Flashlight.intensity = 1;
                isFlashlightOn = true;
            }
        }

    }
}
