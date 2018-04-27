using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinStateActivation : MonoBehaviour {

    public GameObject WinCutscene;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && GameManager.Instance.HasCard)
        {
            WinCutscene.SetActive(true);
        }
    }
}
