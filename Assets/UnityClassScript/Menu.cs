using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine;未包含UI程式庫，如果要宣告UI相關變數需要使用UI程式庫using UnityEngine.UI;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    bool ControlSound = false;

    [Header("聲音的按鈕")]
    public Image SoundButtonImage;
    [Header("聲音開啟圖")]
    public Sprite SoundOpenSprite;
    [Header("聲音關閉圖")]
    public Sprite SoundCloseSprite;
    [Header("聲音拉霸")]
    public Slider Soundslider;
    [Header("下拉選單")]
    public Dropdown ScreenSizeDropdown;
    //Playerperfs 儲存/取值資料欄位的名稱
    string SaveAudioSlider = "SaveAudioSlider";
    public float LastSound = 1;

    public void Start()
    {
        Control_Sound();
        //Soundslider.value = SaveData.SaveAudioSlider;
        Soundslider.value = PlayerPrefs.GetFloat(SaveAudioSlider);
        AudioListener.volume = Soundslider.value;
    }

    private void Update()
    {
        AudioListener.volume = Soundslider.value;
        // print("ScreenSizeDropdown:" + ScreenSizeDropdown.value);
        /*if(ScreenSizeDropdown.value == 0)
        {
            // 設定遊戲執行檔的解析度Screen.SetResolution(寬度, 高度, 是否全螢幕);
            Screen.SetResolution(1080, 1920, false);
        }
        if (ScreenSizeDropdown.value == 1)
        {
            Screen.SetResolution(480, 800, false);
        }
        if (ScreenSizeDropdown.value == 2)
        {
            Screen.SetResolution(720, 1280, false);
        }*/
        switch (ScreenSizeDropdown.value)
        {
            case 0:
                Screen.SetResolution(480, 800, false);
                break;
            case 1:
                Screen.SetResolution(720, 1280, false);
                break;
            case 2:
                Screen.SetResolution(1080, 1920, false);
                break;

        }

        /*if(AudioListener.volume == 0)
        {
            SoundButtonImage.sprite = SoundCloseSprite;
        }*/


    }

    #region 下一關
    public void Nextscene()
    {
        // Application.LoadLevel("場景名稱");
        // Application.LoadLevel(場景名稱ID);
        // Application.loadLevel讀取當前關卡名稱
        // Application.LoadLevel(Application.loadLevel);重新遊戲
        //SaveData.SaveAudioSlider = Soundslider.value;
        // 儲存浮點數 PlayerPerfs.SetFloat(儲存欄位名稱，儲存浮點數)
        // 儲存字串 PlayerPerfs.SetString(儲存欄位名稱，儲存字串)
        // 儲存整數 PlayerPerfs.SetInt(儲存欄位名稱，儲存整數值)
        PlayerPrefs.SetFloat(SaveAudioSlider, Soundslider.value);
        Application.LoadLevel("Level");
    }
    #endregion

    #region 遊戲關閉
    public void Quit()
    {
        // 輸出成遊戲執行檔才可以進行測試
        Application.Quit();
    }
    #endregion
    #region 控制聲音
    public void Control_Sound()
    {
        ControlSound = !ControlSound;
        if (ControlSound == true)
        {
            // AudioListener.pause = false;整體遊戲聲音開啟
            AudioListener.pause = false;
            // 聲音的按鈕圖換成 開聲音的圖片
            SoundButtonImage.sprite = SoundOpenSprite;
            //Soundslider.value = LastSound;
            
        }
        else
        {
            // AudioListener.pause = false;整體遊戲聲音關閉
            AudioListener.pause = true;
            // 聲音的按鈕圖換成 關聲音的圖片
            SoundButtonImage.sprite = SoundCloseSprite;

            //LastSound = Soundslider.value;
            //Soundslider.value = 0;

        }
    }
    #endregion

    public void ChangeAudioSlider()
    {
        if(Soundslider.value == 0)
        {
            ControlSound = true;
            Control_Sound();
        }
        else
        {
            ControlSound = false;
            Control_Sound();
        }
    }

}
