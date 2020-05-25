using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level : MonoBehaviour
{
    [Header("下一個關卡的名稱")]
    public string NextScreneName;
    public int LevelID;
    public Text LevelText;
    [Header("設定每個關卡最高得分數")]
    public float SetHeightScore;
    // 儲存每個關卡最高得分數
    string SaveHeightScore = "SaveHeightScore";
    string SaveLevelID = "SaveLevelID";
    //int value;
    // 紀錄要開啟的關卡數量
    static public int OpenLevelID = 1;
    // 抓取所有Level頁面所有關卡按鈕
    public GameObject[] LevelButton;
    
    private void Start()
    {
        if (Application.loadedLevelName == "Level" && GetComponentInChildren<Text>()!=null)
        {
            // 抓去子物件
            LevelText = GetComponentInChildren<Text>();
            // 字串轉成整數值
            LevelID = int.Parse(LevelText.text);
            
        }
        // 自動抓取tag為LevelButton的按鈕放入陣列中
        //LevelButton = GameObject.FindGameObjectsWithTag("LevelButton");
        // 用for迴圈開啟按鈕
        for (int i = 0; i < OpenLevelID; i++)
        {
            LevelButton[i].GetComponent<Button>().interactable = true;
        }
    }

    public void NextScene()
    {
        // 如果場景名稱為Menu
        if (NextScreneName == "Menu")
        {
            // Destroy刪除物件
            Destroy(GameObject.Find("BGM").gameObject);
        }
        if(NextScreneName == "animetion")
        {
            PlayerPrefs.SetFloat(SaveLevelID, LevelID);

            // 跳關卡到Game畫面前，先將每關最高得分數儲存
            PlayerPrefs.SetFloat(SaveHeightScore + LevelID, SetHeightScore);
            //Debug.Log(PlayerPrefs.GetFloat(SaveHeightScore + SaveLevelID));
            // GameObject.Find(物件名稱).SetActive判斷物件是否要開啟
            // GameObject.Find("BGM").SetActive(false);
            // GameObject.Find(物件名稱).GetComponent<元件名稱>().enabled判斷物件身上的元件是否要開啟
            GameObject.Find("BGM").GetComponent<AudioSource>().enabled = false;
        }
        if (NextScreneName == "Game")
        {
            // GameObject.Find("BGM").SetActive(true);
            GameObject.Find("BGM").GetComponent<AudioSource>().enabled = true;
        }

        Application.LoadLevel(NextScreneName);
    }
}
