using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSoundEffects : MonoBehaviour
{
    public AudioSource crowAudio;
    private float randomTime = 5;
    private float timeCounter = 0;

    void Update()
    {
        if(timeCounter > randomTime)
        {
            randomTime = Random.Range(5,10);
            timeCounter = 0;
            crowAudio.Play();
        }
        
        timeCounter += Time.deltaTime;
    }
}
