using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreResult : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if(PlayerPrefs.HasKey("Player1Coins"))
        {
            Debug.Log(PlayerPrefs.GetInt("Player1Coins"));
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
