using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class animetion : MonoBehaviour
{
    public VideoPlayer Movie_;
    float Timer;

    private void Start()
    {
        //依照時間持續呼叫function
        //InvokeRepeating(function名稱, 遊戲一開始要等待幾秒才進行第一次呼叫, 第二次第三次...需要等待幾秒做呼叫);
        InvokeRepeating("CheckMovie", 3f, 0.1f);
    }

    private void Update()
    {
        //Timer = Timer + 0.1f;
        //Timer += 0.1f;
        /*Timer += Time.deltaTime;
        if (Timer > 3f)
        {
            //Movie_.isPlaying = true 影片還沒撥放結束
            //Movie_.isPlaying = false 影片播放結束
            if (Movie_.isPlaying == false)
            {
                Application.LoadLevel("HP");
            }
        }*/

    }

    void CheckMovie()
    {
        if(Movie_.isPlaying == false)
        {
            Application.LoadLevel("HP");
        }
    }


    public void Nextscene()
    {
        // Application.LoadLevel("場景名稱");
        // Application.LoadLevel(場景名稱ID);
        // Application.loadLevel讀取當前關卡名稱
        // Application.LoadLevel(Application.loadLevel);重新遊戲
        
        Application.LoadLevel("HP");
    }
}
