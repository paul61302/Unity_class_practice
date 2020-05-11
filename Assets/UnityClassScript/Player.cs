using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Range(0f,1f)]public float Speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /*// Input.GetKey("a")按下A鍵if條件內的腳本持續執行
        if (Input.GetKey("a"))
        {
            transform.position = new Vector3(transform.position.x - 0.05f, transform.position.y, transform.position.z);
        }
        // Input.GetKeyUp("d")按下D鍵且放開，if條件內的腳本執行一次
        // Input.GetKeyDown("d")按下D鍵，if條件內的腳本執行一次
        if (Input.GetKey("d"))
        {
            transform.position = new Vector3(transform.position.x + 0.05f, transform.position.y, transform.position.z);
        }*/

        //Input.GetAxis("Horizontal")沒有按按鍵的時候回傳值為0
        //Input.GetAxis("Horizontal")按A或是左鍵的時候回傳值為-1
        //Input.GetAxis("Horizontal")按D或是右鍵的時候回傳值為1
        //Input.GetAxis("Vertical")沒有按按鍵的時候回傳值為0
        //Input.GetAxis("Vertical")按S或是下鍵的時候回傳值為-1
        //Input.GetAxis("Vertical")按W或是上鍵的時候回傳值為1
#if UNITY_STANDALONE
        transform.Translate(Speed * Input.GetAxis("Horizontal"), Speed * Input.GetAxis("Vertical"), 0f);
#endif
#if UNITY_ANDROID
        transform.Translate(Speed * Input.acceleration.x, Speed * Input.acceleration.y, 0f);
#endif
        /*if(transform.position.x >=2.3f)
            transform.position=new Vector3(2.3f,transform.position.y,transform.position.z)
            */

        //限制數值Mathf.Clamp(限制的項目,最小值,最大值)
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -2.3f, 2.3f), Mathf.Clamp(transform.position.y, -4.6f, 4.6f), transform.position.z);

    }
}
