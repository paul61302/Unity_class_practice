using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    [Header("下一個關卡的名稱")]
    public string NextScreneName;
    public void NextScene()
    {
        // 如果場景名稱為Menu
        if (NextScreneName == "Menu")
        {
            // Destroy刪除物件
            Destroy(GameObject.Find("BGM").gameObject);
        }
        if(NextScreneName == "Movie")
        {
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
