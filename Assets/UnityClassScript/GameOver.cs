using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    // 儲存分數的欄位
    string SaveScore = "SaveScre";
    public Text ScoreText;
    string SaveHeightScore = "SaveHeightScore";
    string SaveLevelID = "SaveLevelID";
    public Text HeightScoreText;
    [Header("重新開始按紐")]
    public Button ReGameButton;
    [Header("下一關的按鈕")]
    public Button NextButton;

    // Start is called before the first frame update
    void Start()
    {
        ScoreText.text = "Score:" + PlayerPrefs.GetFloat(SaveScore);

        HeightScoreText.text = "Height Score:" + PlayerPrefs.GetFloat(SaveHeightScore + PlayerPrefs.GetFloat(SaveLevelID));
        Debug.Log(PlayerPrefs.GetFloat(SaveHeightScore + SaveLevelID));
        // 如果目標分數 > 目前得分數 = 失敗
        if(PlayerPrefs.GetFloat(SaveHeightScore + PlayerPrefs.GetFloat(SaveLevelID)) > PlayerPrefs.GetFloat(SaveScore))
        {
            NextButton.interactable = false;
        }
        // 如果目標分數 < 目前得分數 = 成功
        else
        {
            NextButton.interactable = true;
        }

        // 鼠標顯示
        Cursor.visible = true;

    }
    // 下一關
    public void NextGame()
    {
        if (PlayerPrefs.GetFloat(SaveLevelID) >= Level.OpenLevelID)
            Level.OpenLevelID++;
        Application.LoadLevel("Level");
    }
    // 重新遊戲
    public void ReGame()
    {
        Application.LoadLevel("HP");
    }
    // 回首頁
    public void Menu()
    {
        Application.LoadLevel("Menu");
    }

    // Update is called once per frame
    void Update()
    {
        // 設定九個關卡的最高得分數
        // 如果最高得分 != null，判定得分 < 最高得分，挑戰失敗
        // 如果最高得分 != null，判定得分 > 最高得分，挑戰成功

    }
}
