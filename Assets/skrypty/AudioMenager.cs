using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioMenager : MonoBehaviour
{
    [SerializeField] AudioSource musicSource;
    

    public AudioClip background;

    private void Start()
    {
        musicSource.clip = background;    
    }
}
