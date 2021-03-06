﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GM : MonoBehaviour
{
    [Header("所有敵機物件")]
    public GameObject[] Enemy;
    [Header("設定每幾秒要產出敵機")]
    public float CreateTime;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("CreateEnemy", CreateTime, CreateTime);
    }

    void CreateEnemy() 
    {
        //生成位置Random
        Vector3 pos = new Vector3(Random.Range(-2.3f, 2.3f), transform.position.y/*Random.Range(1.5f, 4.6f)*/, transform.position.z);
        //生成動態
        Instantiate(Enemy[Random.Range(0, Enemy.Length)], pos, transform.rotation);
    }
}
