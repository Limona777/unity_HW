using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneLoader : MonoBehaviour
{
    // �����������������Ƴ���
    public const string RACE_SCENE = "RabbitVSTortoise"; // �������ܳ���
    public const string CHASE_SCENE = "RabbitVSWolf";   // �������ܳ���

    public static SceneLoader Instance { get; private set; }

    private void Awake()
    {
        // ʵ�ֵ���ģʽ
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

    // ���ع������ܳ���
    public void LoadRaceScene()
    {
        StartCoroutine(LoadSceneAsync(RACE_SCENE));
    }

    // �����������ܳ���
    public void LoadChaseScene()
    {
        StartCoroutine(LoadSceneAsync(CHASE_SCENE));
    }

    // �л��������ڹ������ܺ���������֮���л���
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

    // ������һ�أ��ӹ��õ����ǣ�������ǻع��ã�
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

    // ���¼��ص�ǰ����
    public void ReloadCurrentScene()
    {
        StartCoroutine(LoadSceneAsync(SceneManager.GetActiveScene().name));
    }

    // �첽���س����ĺ��ķ���
    private IEnumerator LoadSceneAsync(string sceneName)
    {

        // ��ʼ�첽����
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName);
        asyncLoad.allowSceneActivation = false;

        // �ȴ��������90%
        while (!asyncLoad.isDone)
        {

            // �ﵽ0.9��ȴ��û�ȷ�ϣ���ֱ�Ӽ�����
            if (asyncLoad.progress >= 0.9f)
            {
                // �������������"�����������"����
                // �������Ҫ��ֱ�Ӽ����
                break;
            }

            yield return null;
        }


        // �����
        asyncLoad.allowSceneActivation = true;

    }

}