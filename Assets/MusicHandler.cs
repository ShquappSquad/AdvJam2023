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
    }

    //Call from transition code in PlayerHealth
    public void PlayConstruction()
    {
        Debug.Log("Play Construction Music");
    }
}
