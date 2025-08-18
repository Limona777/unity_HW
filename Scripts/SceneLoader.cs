using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneLoader : MonoBehaviour
{
    // 定义两个场景的名称常量
    public const string RACE_SCENE = "RabbitVSTortoise"; // 龟兔赛跑场景
    public const string CHASE_SCENE = "RabbitVSWolf";   // 兔狼赛跑场景

    public static SceneLoader Instance { get; private set; }

    private void Awake()
    {
        // 实现单例模式
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // 加载龟兔赛跑场景
    public void LoadRaceScene()
    {
        StartCoroutine(LoadSceneAsync(RACE_SCENE));
    }

    // 加载兔狼赛跑场景
    public void LoadChaseScene()
    {
        StartCoroutine(LoadSceneAsync(CHASE_SCENE));
    }

    // 切换场景（在龟兔赛跑和兔狼赛跑之间切换）
    public void ToggleScenes()
    {
        if (SceneManager.GetActiveScene().name == RACE_SCENE)
        {
            LoadChaseScene();
        }
        else
        {
            LoadRaceScene();
        }
    }

    // 加载下一关（从龟兔到兔狼，或从兔狼回龟兔）
    public void LoadNextScene()
    {
        if (SceneManager.GetActiveScene().name == RACE_SCENE)
        {
            LoadChaseScene();
        }
        else
        {
            LoadRaceScene();
        }
    }

    // 重新加载当前场景
    public void ReloadCurrentScene()
    {
        StartCoroutine(LoadSceneAsync(SceneManager.GetActiveScene().name));
    }

    // 异步加载场景的核心方法
    private IEnumerator LoadSceneAsync(string sceneName)
    {

        // 开始异步加载
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName);
        asyncLoad.allowSceneActivation = false;

        // 等待加载完成90%
        while (!asyncLoad.isDone)
        {

            // 达到0.9后等待用户确认（或直接继续）
            if (asyncLoad.progress >= 0.9f)
            {
                // 可以在这里添加"按任意键继续"功能
                // 如果不需要，直接激活场景
                break;
            }

            yield return null;
        }


        // 激活场景
        asyncLoad.allowSceneActivation = true;

    }

}