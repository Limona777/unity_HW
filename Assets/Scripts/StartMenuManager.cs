using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

[RequireComponent(typeof(Button))]
public class GameStartController : MonoBehaviour
{
    [Header("Scene Settings")]
    [SerializeField] private string gameSceneName = "GameScene";

    [Header("Animation Settings")]
    [SerializeField] private Animator buttonAnimator;
    [SerializeField] private float buttonAnimationDuration = 0.55f; // 根据您的截图

    [Header("Fade Out Settings")]
    [SerializeField] private CanvasGroup canvasGroup;
    [SerializeField] private float fadeOutDuration = 0.5f;

    private Button _startButton;
    private bool _isLoading = false;

    private void Awake()
    {
        // 获取组件引用
        _startButton = GetComponent<Button>();

        if (buttonAnimator == null)
            buttonAnimator = GetComponent<Animator>();

        if (canvasGroup == null)
            canvasGroup = GetComponentInParent<CanvasGroup>();
    }

    private void Start()
    {
        // 确保Canvas初始可见
        if (canvasGroup != null)
        {
            canvasGroup.alpha = 1;
            canvasGroup.interactable = true;
            canvasGroup.blocksRaycasts = true;
        }

        // 添加点击事件
        _startButton.onClick.AddListener(OnStartButtonClick);
    }

    private void OnStartButtonClick()
    {
        if (_isLoading) return;
        _isLoading = true;

        // 禁用按钮防止多次点击
        _startButton.interactable = false;

        // 开始加载流程
        StartCoroutine(StartGameSequence());
    }

    private IEnumerator StartGameSequence()
    {
        // 等待按钮动画完成（根据您的截图0:55）
        yield return new WaitForSeconds(buttonAnimationDuration);

        // 开始淡出Canvas
        if (canvasGroup != null)
        {
            float timer = 0;
            while (timer < fadeOutDuration)
            {
                timer += Time.deltaTime;
                canvasGroup.alpha = Mathf.Lerp(1, 0, timer / fadeOutDuration);
                yield return null;
            }

            // 完全禁用Canvas交互
            canvasGroup.interactable = false;
            canvasGroup.blocksRaycasts = false;
        }
        else
        {
            // 如果没有CanvasGroup，直接禁用Canvas
            transform.root.gameObject.SetActive(false);
        }

        // 加载游戏场景
        SceneManager.LoadScene(gameSceneName, LoadSceneMode.Single);
    }

    private void OnDestroy()
    {
        // 清理事件监听
        if (_startButton != null)
        {
            _startButton.onClick.RemoveListener(OnStartButtonClick);
        }
    }
}
