using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public bool gameOver;
    // Start is called before the first frame update
    void Start()
    {
        if(!instance)
        {
            instance = this;
        }
        gameOver = false;
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void GameStart()
    {
        UIManager.instance.GameStart();
        ScoreManager.instance.StartScore();
        GameObject.Find("PlatformSpawner").GetComponent<PlatformSpawner>().StartSpawningPlatforms();
        Debug.Log("Run");
    }
     public void GameOver()
    {
        UIManager.instance.GameOver();
        ScoreManager.instance.StopScore();
        gameOver = true;
    }
}
