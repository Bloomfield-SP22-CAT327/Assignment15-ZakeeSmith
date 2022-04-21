using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    private AudioMixer audioMixer;
    private Slider masterVolumeSlider;

    float master;

    private void Awake()
    {
        audioMixer = Resources.Load("Audio/MasterVolume") as AudioMixer;
        masterVolumeSlider = GameObject.Find("MasterVolumeSlider").GetComponent<Slider>();
    }

    private void Start()
    {
        audioMixer.GetFloat("masterVolume", out master);

        Debug.Log("Master: " + master);

        masterVolumeSlider.value = master;
    }

    private void Update()
    {
        if(Input.GetKeyDown("a"))
        {
            StartCoroutine(FadeSound());
        }
    }

    IEnumerator FadeSound()
    {
        for(float a= 1f; a>= 0; a-= 0.1f)
        {
            audioMixer.SetFloat("masterVolume", master - 2.5f);
            yield return null;
        }
        
    }

    public void ChangeMasterVolumeSlider()
    {
        audioMixer.SetFloat("masterVolume", masterVolumeSlider.value);
    }
}
