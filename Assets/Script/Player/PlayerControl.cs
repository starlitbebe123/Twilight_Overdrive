using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    //物件欄位
    Transform playerTra;
    SpriteRenderer playerSpr;
    Rigidbody2D playerRig;
    Animator playerAni;
    AnimatorStateInfo playerAniStateInfo;

    //玩家前一幀位置
    public Vector3 playerOffset;

    //Force
    [Header("移動"), Tooltip("移動速度"), Range(0, 999)]
    public float forceX = 30;
    [Header("跳躍"), Tooltip("跳躍高度"), Range(0, 999)]
    public float forceJump = 30;
 
    public float forceDash = 100;

    //Attack
    public bool canAttack = false;
    public bool isAttacking = false;
    public int countAttack = 0;
    [Header("攻擊段數"), Tooltip("攻擊段數"), Range(1, 3)]
    public int multiAttack = 3;
    [Header("攻擊冷卻"), Tooltip("攻擊冷卻"), Range(0, 10)]
    public float cooldownAttack = 0.10f;
    public float damageAttack = 0;

    //Jump
    public bool canJump = false;
    public int countJump = 0;
    [Header("跳躍段數"), Tooltip("跳躍段數"), Range(1, 3)]
    public int multiJump = 2;
    [Header("跳躍冷卻"), Tooltip("跳躍冷卻"), Range(0, 10)]
    public float cooldownJump = 0.10f;

    //Dash
    public bool canDash = false;
    public bool isDashing = false;
    public int countDash = 0;
    [Header("衝刺段數"), Tooltip("衝刺段數"), Range(1, 3)]
    public int multiDash = 2;
    [Header("衝刺冷卻"), Tooltip("衝刺冷卻"), Range(0, 10)]
    public float cooldownDash = 0.10f;

    //Hurt
    public bool canHurt = false;

    //Ground
    public bool isGrounded = false;
    public Vector3 groundOffset = new Vector3(-1.00f, 0.00f, 0.00f);
    public float groundRadius = 0.05f;
    public Collider2D groundHit;
    public bool groundEnter;

    //Rise
    public bool isRising = false;

    //Fall
    public bool isFalling = false;

    //Hurt(彤的作法
    public bool isHurting;

    //Dead
    public bool isDead = false;

    public AudioClip SlashAud;
    public AudioClip JumpAud;
    public AudioClip DodgeAud;
    AudioSource audioSource;

    private void Start()
    {
        //設定初始參數
        playerTra = GetComponent<Transform>();
        playerSpr = GetComponent<SpriteRenderer>();
        playerRig = GetComponent<Rigidbody2D>();
        playerAni = GetComponent<Animator>();
        canAttack = true;
        canJump = true;
        canDash = true;
        canHurt = true;
        audioSource = GetComponent<AudioSource>();


    }

    private void Update()
    {
        //取得動畫狀態
        playerAniStateInfo = playerAni.GetCurrentAnimatorStateInfo(0);

        //持續監聽並執行以下方法
        if (!(isHurting || isDead))
        {
            //動畫監聽
            if (!isRising)
                IsRising();
            if (!isFalling)
                IsFalling();

            //指令監聽
            if (!((isAttacking && isGrounded) || isDashing))
                MovementX();
            if (!isDashing)
                Attack();
            if (!((isAttacking && isGrounded) || isDashing))
                Jump();
            //if (!isAttacking)
                Dash();
        }

        //儲存當前位置，於下一幀用作上一幀的位置
        playerOffset = playerTra.position;
        groundHit = Physics2D.OverlapCircle(transform.position + transform.right * groundOffset.x + transform.up * groundOffset.y, groundRadius, 1 << 8);

        if (groundHit && groundHit.CompareTag("Ground"))
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
            groundEnter = false;
        }

        if (isGrounded && !groundEnter)
        {
            groundEnter = true;
            countJump = 0;
            countDash = 0;
            canJump = true;
            canDash = true;

            if (isAttacking)
                canAttack = true;

            ResetAni();
        }

        if (isGrounded)
        {
            isGrounded = true;
            isRising = false;
            isFalling = false;
            playerAni.SetBool("isJumping", false);
            playerAni.SetBool("isFalling", false);
            countDash = 0;
        }
    }

    private void OnDrawGizmos()
    {
        //1.指定顏色
        Gizmos.color = new Color(1, 0, 0, 0.5f);

        //2.繪製圖形
        Gizmos.DrawSphere(transform.position + transform.right * groundOffset.x + transform.up * groundOffset.y, groundRadius);
    }

    //重設動作
    void ResetAni()
    {
        //isAttacking = false;
        isRising = false;
        isFalling = false;
        //isDashing = false;
        countAttack = 0;
        playerAni.SetInteger("attack", countAttack);
        playerAni.SetBool("isJumping", false);
        playerAni.SetBool("isFalling", false);
        playerAni.SetBool("isDashing", false);
    }

    //水平移動
    void MovementX()
    {
        //左右同時按我就不動
        if ((Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D)) && (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A)))
        {
            playerAni.SetBool("isMoving", false);
        }
        //右
        else if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            playerTra.eulerAngles = Vector3.zero;
            playerRig.transform.Translate(transform.right * forceX * Time.deltaTime);

            if (isGrounded)
                playerAni.SetBool("isMoving", true);
            else
                playerAni.SetBool("isMoving", false);
        }
        //左
        else if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            playerTra.eulerAngles = new Vector3(0, 180, 0);
            playerRig.transform.Translate(-transform.right * forceX * Time.deltaTime);

            if (isGrounded)
                playerAni.SetBool("isMoving", true);
            else
                playerAni.SetBool("isMoving", false);
        }
        //其它
        else
        {
            playerAni.SetBool("isMoving", false);
        }
    }

    //攻擊
    void Attack()
    {
        if (!(playerAniStateInfo.IsTag("ATK01") || playerAniStateInfo.IsTag("ATK02")
            || playerAniStateInfo.IsTag("ATK03")) && isAttacking)
            StartCoroutine(CooldownAttack());

        if ((playerAniStateInfo.IsTag("ATK01") || playerAniStateInfo.IsTag("ATK02")
            || playerAniStateInfo.IsTag("ATK03")) && playerAniStateInfo.normalizedTime > 1.00f)
            StartCoroutine(CooldownAttack());

        if (countAttack >= multiAttack)
            canAttack = false;

        //J攻擊
        if (Input.GetKeyDown(KeyCode.J))
        {
            if (isHurting == false)
            {
                if (canAttack)
                    if (countAttack == 0)
                    {
                        ResetAni();
                        countAttack = 1;
                        DoAttack();
                        damageAttack = 2;
                        audioSource.PlayOneShot(SlashAud, 1F);
                    }
                    else if (playerAniStateInfo.IsTag("ATK01") && countAttack == 1 && playerAniStateInfo.normalizedTime < 0.8f)
                    {
                        countAttack = 2;
                        damageAttack = 3;
                        audioSource.PlayOneShot(SlashAud, 1F);
                    }
                    else if (playerAniStateInfo.IsTag("ATK02") && countAttack == 2 && playerAniStateInfo.normalizedTime < 0.8f)
                    {
                        countAttack = 3;
                        damageAttack = 5;
                        audioSource.PlayOneShot(SlashAud, 1F);
                    }
            }
        }
    }

    void DoAttack()
    {
        playerAni.SetInteger("attack", countAttack);
        isAttacking = true;
    }

    IEnumerator CooldownAttack()
    {
        countAttack = 0;
        playerAni.SetInteger("attack", countAttack);
        isAttacking = false;
        canAttack = false;

        yield return new WaitForSeconds(cooldownAttack);

        canAttack = true;
    }

    //跳躍
    void Jump()
    {
        if (countJump >= multiJump)
            canJump = false;

        //K跳躍
        if (Input.GetKeyDown(KeyCode.K))
            if (canJump)
            {
                ResetAni();
                DoJump();
                StartCoroutine(CooldownJump());
                audioSource.PlayOneShot(JumpAud, 1F);
            }
    }

    void DoJump()
    {
        countJump++;
        playerRig.velocity = new Vector2(0, 0);
        playerRig.velocity = transform.up * forceJump;
        IsRising();
    }

    IEnumerator CooldownJump()
    {
        canJump = false;

        yield return new WaitForSeconds(cooldownJump);

        canJump = true;
    }

    //衝刺
    void Dash()
    {
        if (!playerAniStateInfo.IsTag("Dash") && isDashing)
            StartCoroutine(CooldownDash());

        if (countDash >= multiDash)
            canDash = false;

        //L衝刺
        if (Input.GetKeyDown(KeyCode.L))
            if (canDash)
            {
                ResetAni();
                StartCoroutine(DoDash());
                StartCoroutine(CooldownDash());
                audioSource.PlayOneShot(DodgeAud, 1F);
            }
    }

    IEnumerator DoDash()
    {
        countDash++;
        playerRig.velocity = new Vector2(0, 0);
        playerRig.gravityScale = 0.0f;

        if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.A))
        {
            forceDash = 0;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            playerTra.eulerAngles = Vector3.zero;
            forceDash = 15;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            playerTra.eulerAngles = new Vector3(0, 180, 0);
            forceDash = 15;
        }
        else
        {
            forceDash = 0;
        }

        playerRig.velocity = transform.right * forceDash;
        playerAni.SetBool("isDashing", true);
        isDashing = true;

        yield return new WaitForSeconds(cooldownDash);

        playerRig.velocity = new Vector2(0, 0);
        playerRig.gravityScale = 5.0f;
    }

    IEnumerator CooldownDash()
    {
        canDash = false;

        yield return new WaitForSeconds(cooldownDash);

        playerAni.SetBool("isDashing", false);
        isDashing = false;
        canDash = true;
    }

    IEnumerator IsDead()
    {
        isDead = true;
        playerRig.velocity = new Vector2(0, 0);
        playerAni.SetBool("isDead", true);
        yield return 0;

        /*
        playerAni.SetBool("isDead", false);
        */
    }

    //是否正在上升
    void IsRising()
    {
        if (playerTra.position.y - playerOffset.y > 0 && !isGrounded)
        {
            isRising = true;
            isFalling = false;
            playerAni.SetBool("isJumping", true);
            playerAni.SetBool("isFalling", false);
        }
        else
        {
            isRising = false;
            playerAni.SetBool("isJumping", false);
        }
    }

    //是否正在下降
    void IsFalling()
    {
        if (playerTra.position.y - playerOffset.y < 0 && !isGrounded)
        {
            isFalling = true;
            isRising = false;
            playerAni.SetBool("isFalling", true);
            playerAni.SetBool("isJumping", false);
        }
        else
        {
            isFalling = false;
            playerAni.SetBool("isFalling", false);
        }
    }

    //動畫事件
    void GoToNextAttackAction()
    {
        playerAni.SetInteger("attack", countAttack);
    }
}
