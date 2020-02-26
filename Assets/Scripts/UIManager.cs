using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class UIManager : MonoBehaviour
{

    //
    public static UIManager instance;
    //
    public GameObject zigzacPanel;
    public GameObject gameOverPanel;
    public GameObject taptext;
    public Text score;
    public Text highScore1;
    public Text highScore2;
    private void Awake()
    {
        if(!instance)
        {
            instance = this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        highScore1.text = "High Score: "+PlayerPrefs.GetInt("highScore");
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void GameStart()
    {
        highScore1.text = PlayerPrefs.GetInt("highScore").ToString();
        taptext.SetActive(false);
        zigzacPanel.GetComponent<Animator>().Play("PanelMoveUp");
    }
    public void GameOver()
    {
        score.text = PlayerPrefs.GetInt("score").ToString();
        highScore2.text = PlayerPrefs.GetInt("highScore").ToString();
        gameOverPanel.SetActive(true);
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
