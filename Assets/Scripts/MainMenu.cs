using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{    
    public Animator animator;
    public int secondsToMusicFade = 2;
    public AudioSource audioMusic;

    //Called when the Play button is clicked
    public void PlayGame()
    {
        StartFadeOut(1);
    }

    //Called when the Quit button is clicked
    public void QuitGame()
    {
        Application.Quit();
    }

    public void StartFadeOut(int sceneIndex)
    {
        //Trigger fade to black animation then switch scenes after a delay
        animator.SetTrigger("FadeOut");
        findAudio(); 
    }

    public void StartDialogue()
    {
        Invoke("StartSceneChange", 1f);
    }
    
    //Change to next scene
    public void StartSceneChange()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    //Fade Music
    public void findAudio()
    {
        // Call findAudioAndFadeOut Coroutine
        StartCoroutine(findAudioAndFadeOut());
    }

    IEnumerator findAudioAndFadeOut()
    {
        // Find Audio Music in scene
        audioMusic = GameObject.Find("Main Menu").GetComponent<AudioSource>();
 
        // Check Music Volume and Fade Out
        while (audioMusic.volume > 0.01f)
        {
            audioMusic.volume -= Time.deltaTime / secondsToMusicFade;
            yield return null;
        }
 
        // Make sure volume is set to 0
        audioMusic.volume = 0;
 
        // Stop Music
        audioMusic.Stop();
 
        // Destroy
        Destroy (this);
    }
}