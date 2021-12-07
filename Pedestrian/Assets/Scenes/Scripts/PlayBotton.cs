using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayBotton : MonoBehaviour
{
   public void PlayGame()
    {
        SceneManager.LoadScene("Level1");
        SceneManager.LoadScene("Background_Paper");
    }
}
