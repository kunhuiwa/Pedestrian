using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayBotton : MonoBehaviour
{
    public AudioSource playMusic;
    private void Start()
    {
        //playMusic = GetComponent<AudioSource>();
        DontDestroyOnLoad(playMusic);
    }

    
    public void PlayGame()
    {
        playMusic.Play();
        
        SceneManager.LoadScene("Level1");
        
        //SceneManager.LoadScene("Background_Paper");
    }

   public void QuitButton()
    {
        Application.Quit();
        Debug.Log("Quit Game");
    }
}
