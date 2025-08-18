using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Button settingBtn;
    public Button closePlayerBtn;
    public Button closeSettingBtn;
    public GameObject settingPanel;
    public GameObject playerPanel;
    void Start()
    {
        settingBtn.onClick.AddListener(OnClickSetting);
        closePlayerBtn.onClick.AddListener(OnClickClosePlay);
        closeSettingBtn.onClick.AddListener(OnClickCloseSetting);

        settingPanel.SetActive(false);
    }

    void Update()
    {


    }

    public void OnClickSetting()
    {
        settingPanel.SetActive(true);
    }

    public void OnClickClosePlay()
    {
        playerPanel.SetActive(false);
    }
    public void OnClickCloseSetting()
    {
        settingPanel.SetActive(false);
    }

    public void OnClickOpenPlay()
    {
        playerPanel.SetActive(true);
    }
}
