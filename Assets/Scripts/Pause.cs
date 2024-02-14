using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public GameObject pauseText;
    public GameObject mainMenuButton;
    public GameObject exitButton;
    public GameObject infoText;
    public static bool gameIsPaused = false;
    private AudioSource audioSource;
    public AudioClip audioClip;
    // Start is called before the first frame update
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.ignoreListenerPause = true;
    }
    private void OnPause()
    {
        
        
            if (gameIsPaused == false)
            {
                PauseGame();
            }
            else
            {
                gameIsPaused = false;
                UnpauseGame();
            }
        
    }
    public void PauseGame()
    {
        Time.timeScale = 0.0f;
        pauseText.SetActive(true); mainMenuButton.SetActive(true); infoText.SetActive(true); exitButton.SetActive(true);
        gameIsPaused = true;
        AudioListener.pause = true;
        audioSource.Stop();
        audioSource.PlayOneShot(audioClip);
    }
    public void UnpauseGame()
    {
        Time.timeScale = 1.0f;
        pauseText.SetActive(false); mainMenuButton.SetActive(false); exitButton.SetActive(false); infoText.SetActive(false);
        gameIsPaused = false;
        AudioListener.pause = false;
        audioSource.Stop();
        audioSource.Play();
    }
    public void Update()
    {
        if (gameIsPaused == true)
        {
            audioSource.loop = true;
        }
        
    }
}
