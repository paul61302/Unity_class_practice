using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("敵機速度")]
    public float EnemySpeed;
    [Header("敵機多久被消滅")]
    public float DeleteTime = 7f;
    private void Start()
    {
        Destroy(gameObject, DeleteTime);
    }
    private void Update()
    {
        EnemyTranslate();
    }

    void EnemyTranslate()
    {
        
        gameObject.transform.Translate(new Vector3(0,-1,0) * EnemySpeed);
    }
}
