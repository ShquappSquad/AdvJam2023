using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrowSounds : MonoBehaviour
{
    public AudioSource crowAudio;
    public AudioSource truckAudio;
    private float randomTime = 5;
    private float timeCounter = 0;
    public GameObject player;
    private int zone;

    void Update()
    {
        zone = player.GetComponent<PlayerHealth>().zone;

        if(timeCounter > randomTime)
        {
            randomTime = Random.Range(10,20);
            timeCounter = 0;
            if(zone == 1)
            {
                crowAudio.Play();
            }
            if(zone == 2)
            {
                truckAudio.Play();
            } 
        }
        timeCounter += Time.deltaTime;
    }
} 
