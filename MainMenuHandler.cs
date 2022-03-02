using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuHandler : MonoBehaviour
{
    [SerializeField]
    private AudioSource onClickSFX;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayGame(string nextScene)
    {
        StartCoroutine(DelayTransition(nextScene));
    }

    public void QuitGame()
    {
        StartCoroutine(DelayExit());
    }

    IEnumerator DelayTransition(string nextScene)
    {
        onClickSFX.Play();

        yield return new WaitForSeconds(0.5f);

        SceneManager.LoadScene(nextScene);
    }

    IEnumerator DelayExit()
    {
        onClickSFX.Play();

        yield return new WaitForSeconds(0.5f);

        // Quitting from the editor
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #endif

        // Quitting from the application
        Application.Quit();
    }
}
