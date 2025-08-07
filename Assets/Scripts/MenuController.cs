// MenuController.cs
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public GameObject menuPanel;
    public Animator fadeAnimator;

    public void StartGame()
    {
        fadeAnimator.SetTrigger("FadeOut");
        Invoke("LoadGameScene", 1f);
    }

    private void LoadGameScene()
    {
        SceneManager.LoadScene("GameScene");
    }
}