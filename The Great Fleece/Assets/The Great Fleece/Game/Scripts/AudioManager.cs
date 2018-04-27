using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {

    private static AudioManager _Instance;

    public static AudioManager Instance
    {
        get {
            if (_Instance == null)
            {
                Debug.LogError("The instance is null");
            }
                return _Instance;
        }
    }

    public AudioSource voiceOver;

    private void Awake()
    {
        _Instance = this;
    }

    public void PlayVoiceOver(AudioClip clipToPlay)
    {
        voiceOver.clip = clipToPlay;
        voiceOver.Play();
    }

}
