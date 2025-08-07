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
    [SerializeField] private float buttonAnimationDuration = 0.55f; // �������Ľ�ͼ

    [Header("Fade Out Settings")]
    [SerializeField] private CanvasGroup canvasGroup;
    [SerializeField] private float fadeOutDuration = 0.5f;

    private Button _startButton;
    private bool _isLoading = false;

    private void Awake()
    {
        // ��ȡ�������
        _startButton = GetComponent<Button>();

        if (buttonAnimator == null)
            buttonAnimator = GetComponent<Animator>();

        if (canvasGroup == null)
            canvasGroup = GetComponentInParent<CanvasGroup>();
    }

    private void Start()
    {
        // ȷ��Canvas��ʼ�ɼ�
        if (canvasGroup != null)
        {
            canvasGroup.alpha = 1;
            canvasGroup.interactable = true;
            canvasGroup.blocksRaycasts = true;
        }

        // ��ӵ���¼�
        _startButton.onClick.AddListener(OnStartButtonClick);
    }

    private void OnStartButtonClick()
    {
        if (_isLoading) return;
        _isLoading = true;

        // ���ð�ť��ֹ��ε��
        _startButton.interactable = false;

        // ��ʼ��������
        StartCoroutine(StartGameSequence());
    }

    private IEnumerator StartGameSequence()
    {
        // �ȴ���ť������ɣ��������Ľ�ͼ0:55��
        yield return new WaitForSeconds(buttonAnimationDuration);

        // ��ʼ����Canvas
        if (canvasGroup != null)
        {
            float timer = 0;
            while (timer < fadeOutDuration)
            {
                timer += Time.deltaTime;
                canvasGroup.alpha = Mathf.Lerp(1, 0, timer / fadeOutDuration);
                yield return null;
            }

            // ��ȫ����Canvas����
            canvasGroup.interactable = false;
            canvasGroup.blocksRaycasts = false;
        }
        else
        {
            // ���û��CanvasGroup��ֱ�ӽ���Canvas
            transform.root.gameObject.SetActive(false);
        }

        // ������Ϸ����
        SceneManager.LoadScene(gameSceneName, LoadSceneMode.Single);
    }

    private void OnDestroy()
    {
        // �����¼�����
        if (_startButton != null)
        {
            _startButton.onClick.RemoveListener(OnStartButtonClick);
        }
    }
}
