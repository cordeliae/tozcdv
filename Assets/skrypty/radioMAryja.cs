using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UIElements;

public class radioMAryja : MonoBehaviour
{
    [SerializeField] private GameObject radio;
    [SerializeField] private GameObject music1;
    [SerializeField] private GameObject music2;
    [SerializeField] private GameObject music3;
    public AudioMixer audioMixer;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.M))
        {
            radio.SetActive(!radio.activeInHierarchy);
        }
    }
    public void Music1()
    {
        music1.SetActive(true);
        music2.SetActive(false);
        music3.SetActive(false);
    }
    public void Music2()
    {
        music2.SetActive(true);
        music1.SetActive(false);
        music2.SetActive(false);
    }
    public void AdjustRadioVolume(float value)
    {
        audioMixer.SetFloat("Volume", value);
    }
    public void Music3()
    {
        music3.SetActive(true);
        music2.SetActive(false);
        music1.SetActive(false);
    }
  
}
