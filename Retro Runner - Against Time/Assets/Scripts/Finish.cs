using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour
{
    private AudioSource finishSound;

    [SerializeField] private bool isPlayer1;
    public bool p1LevelCompleted = false;
    public bool p2LevelCompleted = false;

    [SerializeField] private GameObject invisibleWallPlayer1;
    [SerializeField] private GameObject invisibleWallPlayer2;

    // Start is called before the first frame update
    void Start()
    {
        finishSound = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Player1" && !p1LevelCompleted && isPlayer1)
        {
            finishSound.Play();
            p1LevelCompleted = true;
            FinishTracker.Instance.PlayerGetCheckpoint(1);
            invisibleWallPlayer1.SetActive(true);
        }
        if(collision.gameObject.name == "Player2" && !p2LevelCompleted && !isPlayer1)
        {
            finishSound.Play();
            p2LevelCompleted = true;
            FinishTracker.Instance.PlayerGetCheckpoint(2);
            invisibleWallPlayer2.SetActive(true);
        }
    }
}
