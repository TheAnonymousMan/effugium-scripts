using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SanityHandler : MonoBehaviour
{
    [SerializeField]
    private float maxSanity;

    [SerializeField]
    private float rate;

    [SerializeField]
    private RawImage sanityMeter;

    [SerializeField]
    private GameObject gameOverPanel;

    [SerializeField]
    private Image sanityMeterBackground;

    [SerializeField]
    private Image sanityMeterForeground;

    [SerializeField]
    private AudioSource sanityAudio;

    private float currentSanity;

    // Start is called before the first frame update
    void Start()
    {
        currentSanity = maxSanity;
        sanityMeter.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        currentSanity -= Time.deltaTime * rate;

        if (sanityMeter.color.a < 0.25f)
        {
            sanityMeter.color = new Color(sanityMeter.color.r, sanityMeter.color.g, sanityMeter.color.b, (maxSanity - currentSanity) / (maxSanity * 3));
        }

        if (sanityAudio.volume < 0.3f)
        {
            sanityAudio.volume = ((maxSanity - currentSanity) / maxSanity) * 0.4f + 0.1f;
        }

        sanityMeterForeground.transform.localScale =
            new Vector3((currentSanity / maxSanity) * sanityMeterBackground.transform.localScale.x,
                        sanityMeterForeground.transform.localScale.y,
                        sanityMeterForeground.transform.localScale.z);



        Debug.Log("Current Sanity: " + currentSanity);

        if (currentSanity < 0)
        {
            // death comes for us all
            gameOverPanel.gameObject.SetActive(true);
            Time.timeScale = 0f;
        }
    }
}
