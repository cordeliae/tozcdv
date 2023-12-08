using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioMenager : MonoBehaviour
{
    [SerializeField] AudioSource musicSource;//to jest od muzyki ze mozna dodac nutke
    

    public AudioClip background;//i tam mozna dodac 

    private void Start()
    {
        musicSource.clip = background;    
    }
}
