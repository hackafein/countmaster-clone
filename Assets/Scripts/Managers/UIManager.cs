using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class UIManager : MonoBehaviour
{
    #region PreGameFields
    [Header("PreGameFields")]
    public GameObject PreGamePanel;
    public TextMeshProUGUI CoinText;
    public TextMeshProUGUI DiamondText;
    public TextMeshProUGUI LevelText;
    #endregion

    #region OnGameFields
    [Header("OnGameFields")]
    public GameObject GamePanel;
    public TextMeshProUGUI GameCoinText;
    #endregion

    #region SettingFields
    [Header("SettingFields")]
    public GameObject SettingsPanel;

    #endregion


    #region EndGameFields
    [Header("OnGameFields")]
    public GameObject NextLevelPanel;
    public GameObject YouLosePanel;
    #endregion

    #region required Sheets
    public static UIManager instance;
    #endregion


    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        PreGamePanel.SetActive(true);
    }

    public void OnClickGame() // OYUN BAŞLAMA EVENTI BURADA TETIKLENECEK
    {
        PreGamePanel.SetActive(false);
        GamePanel.SetActive(true);
    }

    public void OnClickSettings() 
    {
        SettingsPanel.SetActive(true);
    }

    public void OnClickBackonSettings()
    {
        SettingsPanel.SetActive(false);
    }

    public void OnSuccessGame()
    {
        NextLevelPanel.SetActive(true);
        // Bu aşamada Kamera konumu level 2 ye gider player taşınır
    }


    public void OnFailedGame()
    {
        YouLosePanel.SetActive(true);
        // Bu aşamada Kamera konumu bulunan levele gider player taşınır
    }

    public void OnClickNextLevelButton()
    {
        NextLevelPanel.SetActive(false);
        GamePanel.SetActive(true);
    }

    public void OnClickTryAgainButton()
    {
        YouLosePanel.SetActive(false);
        GamePanel.SetActive(true);
    }

}
