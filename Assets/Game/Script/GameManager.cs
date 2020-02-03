using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public MonoBehaviour playerController;
    public SpawnManager spawnManager;
    bool gameOver = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (gameOver)
        {
            Debug.Log("Game over");
            playerController.enabled = false;
            spawnManager.Stop();
        }
    }

    public void GameOver()
    {
        gameOver = true;
    }
}
