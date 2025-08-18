using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEditor;
using System.Runtime.CompilerServices;

public class GameController : MonoBehaviour
{
    public static GameController Instance;
    public GameObject gameStartMessage;
    public GameObject gameOverwin;
    public GameObject gameOverLose;
    private bool gameStart;
    public const string RACE_SCENE = "RabbitVSTortoise"; // ¹êÍÃÈüÅÜ³¡¾°
    public const string CHASE_SCENE = "RabbitVSWolf";   // ÍÃÀÇÈüÅÜ³¡¾°

    private void Awake()
    {
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        Init();
    }
    public void Win()
    { 
        gameOverwin.SetActive(true);
        gameStart = false;
    }
    public void Lose()
    {
        gameOverLose.SetActive(true);
        gameStart = false;
    }
    private void Init()
    { 
        gameStartMessage.SetActive(true);
        gameOverLose.SetActive(false);
        gameOverwin.SetActive(false);
        gameStart = false;
    }
    public bool GameStart()
    { 
        return gameStart;
    }
    public void OnBtnStart()
    {
        gameStartMessage.SetActive(false);
        gameStart = true;
    }
    public void OnBtnNext()
    {
        SceneManager.LoadScene("GameScene");
    }
    public void OnBtnReplay() 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void OnBtnQuit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }
    // Update is called once per frame
    void Update()
    {

    }
}
