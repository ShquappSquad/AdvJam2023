using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicHandler : MonoBehaviour
{
    public GameObject forestSong;
    public GameObject constructionSong;
    //public GameObject bossSong;
    public GameObject player;
    private int zone;

    //Call from transition code in PlayerHealth
    public void PlayForest()
    {
        Debug.Log("Play Forest Music");
        zone = 1;
    }

    //Call from transition code in PlayerHealth
    public void PlayConstruction()
    {
        Debug.Log("Play Construction Music");
        zone = 2;
    }

    void FadeAudio()
    {
        //StartCoroutine(findAudioAndFadeOut());
    }

    /* IEnumerator findAudioAndFadeOut()
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
        } */
}
