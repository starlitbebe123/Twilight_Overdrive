using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Infantry2 : MonoBehaviour
{
    #region 欄位
    public float speed = 1f;

    public float attack = 10f;

    public float radiusTrack;

    public float radiusAttack;

    public float cd;
    public float cdTimer;

    private Transform player;
    private Rigidbody2D rig;
    private Animator ani;

   
    public Vector3 groundOffset;
    public float groundRadius = 0.1f;

    public Vector3 attackOffset;
    public Vector3 attackSize;

    public bool isAttacking;

    //原始速度
    private float speedOriginal;


    #endregion

    #region 事件
    private void Start()
    {
        ani = GetComponent<Animator>();
        rig = GetComponent<Rigidbody2D>();
        //玩家 = 遊戲物件.尋找("物件名稱) 搜尋場景內所有物件
        //transform.Find  是搜尋子物件
        player = GameObject.FindGameObjectWithTag("Player").transform;

        //讓敵人一開始就進行攻擊
        cdTimer = cd;

        //原始速度
        speedOriginal = speed;
    }

    private void Update()
    {
        Move();
    }

    private void OnDrawGizmos()
    {
        //追蹤範圍
        Gizmos.color = new Color(0, 1, 0, 0.3f);
        Gizmos.DrawSphere(transform.position, radiusTrack);
        //攻擊範圍
        Gizmos.color = new Color(1, 0, 0, 0.3f);
        Gizmos.DrawSphere(transform.position, radiusAttack);
        //偵測面前是不是地板
        Gizmos.color = new Color(0.6f, 0.9f, 1, 0.7f);
        Gizmos.DrawSphere(transform.position + transform.right * groundOffset.x + transform.up * groundOffset.y, groundRadius);

        //攻擊範圍
        Gizmos.color = new Color(0.3f, 0.3f, 1, 0.8f);
        Gizmos.DrawCube(transform.position + transform.right * attackOffset.x + transform.up * attackOffset.y, attackSize);
    }
    #endregion
    #region 方法
    private void Move()
    {
        

        //距離 = 三圍向量.距離(A點-B點)
        float dis = Vector3.Distance(player.position, transform.position);

        //如果 玩家跟敵人 的 距離 小於等於 攻擊範圍 就攻擊
        if (dis <= radiusAttack)
        {
            Attack();
            ani.SetBool("Attack",true);

        }
        //否則 如果 玩家跟敵人 的 距離 小於等於 追蹤範圍 就往前方移動
        else if (dis <= radiusTrack && isAttacking == false)
        {
            rig.velocity = transform.right * speed * Time.deltaTime;
            ani.SetBool("Walk", speed != 0); //速度不等於零 才會播放 走路動畫
            LookAtPlayer();
            //CheckGround();
        }
        else
        {
            ani.SetBool("Walk", false);
        }
    }

    private void Attack()
    {
        
        ani.SetBool("Walk", false);
        //如果 計時器 <= 攻擊冷卻 就累加
        if (cdTimer <= cd)
        {
            cdTimer += Time.deltaTime;
        }
        //否則 攻擊 並 將計時器歸零
        else
        {
            cdTimer = 0;
            
            //碰撞物件 = 2D物理.覆蓋盒形(中心點, 尺寸, 角度)
        }
    }

    private void LookAtPlayer()
    {
        //如果 敵人x 大於 玩家x 較代表玩家在左邊 角度180
        if (transform.position.x > player.position.x)
        {
            transform.eulerAngles = Vector3.zero;
        }
        //否則 敵人x 小於 玩家x 就代表玩家在右邊 角度0
        else
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
    }

    //檢查是否有地板
    private void CheckGround()
    {
        Collider2D hit = Physics2D.OverlapCircle(transform.position + transform.right * groundOffset.x + transform.up * groundOffset.y, groundRadius, 1 << 8);

        //判斷式 程式只有一句 (一個分號) 可以省略 大括號
        if (hit && (hit.tag == "Ground"))
            speed = speedOriginal;
        else speed = 0;

    }

    private void StartAttack()
    {
        isAttacking = true;
    }
    private void EndAttack() 
    {
        isAttacking = false; 
        ani.SetBool("Attack",false);
    }

    #endregion
}
