using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSoundEffects : MonoBehaviour
{
    public AudioSource crowAudio;
    private int rand;

    // Update is called once per frame
    void Start()
    {
        crowAudio = GetComponent<AudioSource>();
        rand = Random.Range(1,3);
    }
    
    void Update()
    {
        Invoke("CrowSound", rand);
    }

    void CrowSound()
    {
        Debug.Log("Sound loop");
        crowAudio.Play();
        rand = Random.Range(1,3);
    }
}
