﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float Speed;
    [Header("子彈多久被消滅")]
    public float DeleteTime;
    [Header("爆炸特效")]
    public GameObject Effect;
    [Header("爆炸聲音")]
    public AudioSource EffectAudio;
    

    // Start is called before the first frame update
    void Start()
    {
        EffectAudio = GameObject.Find("123212321").GetComponent<AudioSource>();
        // Destroy(要刪除的物件(型態只能為GameObject),多久以後物體自己毀滅)
        // gameObject
        Destroy(gameObject, DeleteTime);
    }

    // Update is called once per frame
    void Update()
    {
        // Vector3.up = (0,1,0) Vector3.down = (0,-1,0) Vector3.forward = (1,0,0)
        // transform.Translate(0,speed,0);
        transform.Translate(Vector3.up * Speed);
    }
    // 穿透型碰撞方式 OnTriggerEnter,OnTriggerStay,OnTriggerExit
    // 不穿透行碰撞 OnCollisionEnter,OnCollisionStay,OnCollisionExit
    // Enter 兩個物件一相撞，Function內的程式只會執行一次
    // Stay 兩個物件一相撞，沒有分開，Function內的程式會持續執行，直到兩個物件分離
    // Exit 兩個物件一相撞且分開，Function內的程式只會執行一次
    void OnTriggerEnter2D(Collider2D other)
    {
        // 玩家的子彈打到有Collider2D物件，就檢測該物件的標籤是否為Enemy
        if (other.GetComponent<Collider2D>().tag == "Enemy"&&gameObject.tag=="PlayerBullet")
        {
            //動態產生爆炸特效
            //other.transform.position兩個物件碰撞的位置
            //other.transform.rotation兩個物件碰撞的旋轉值
            Instantiate(Effect, other.transform.position, other.transform.rotation);
            GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().Score();
            //爆炸音效
            EffectAudio.Play();
            //敵機消滅
            Destroy(other.gameObject);
            //自己子彈物件被消滅
            Destroy(gameObject);
        }
        // 玩家子彈打到敵機子彈
        if(other.GetComponent<Collider2D>().tag =="EnemyBullet" && gameObject.tag == "PlayerBullet")
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
        // 敵機子彈打到玩家
        if (other.GetComponent<Collider2D>().tag == "Player" && gameObject.tag == "EnemyBullet")
        {
            // 敵機打到玩家呼叫玩家物件身上的Player腳本中的HurtPlayer進行扣血
            other.GetComponent<Player>().HurtPlayer(10f);
        }
    }
}
