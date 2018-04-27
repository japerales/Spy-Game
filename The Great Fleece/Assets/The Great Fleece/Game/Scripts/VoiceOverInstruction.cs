using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoiceOverInstruction : MonoBehaviour {

    public AudioClip instruction;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            AudioManager.Instance.PlayVoiceOver(instruction);
            gameObject.SetActive(false);
        }
    }
}
