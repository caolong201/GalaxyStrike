using UnityEngine;
using System;

public class MusicPlayer : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        int numberOfMusicPlayer = FindObjectsByType<MusicPlayer>(FindObjectsSortMode.None).Length;
        if (numberOfMusicPlayer > 1) 
        {
           Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }    
    }
    
}
