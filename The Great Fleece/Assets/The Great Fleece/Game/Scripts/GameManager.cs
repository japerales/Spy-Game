using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class GameManager : MonoBehaviour {

    private static GameManager _instance;

    public PlayableDirector pd;
    public bool HasCard;

    public static GameManager Instance
    {
        get {

            if (_instance == null)
            {
                Debug.LogError("Game Manager is Null!");
            }
                return _instance;
        }
        
    }

    private void Awake()
    {
        _instance = this;
    }

    private void Update()
    {
        
    }

}
