using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    //�������
    Transform playerTra;
    SpriteRenderer playerSpr;
    Rigidbody2D playerRig;
    Animator playerAni;
    AnimatorStateInfo playerAniStateInfo;

    //���a�e�@�V��m
    public Vector3 playerOffset;

    //Force
    [Header("����"), Tooltip("���ʳt��"), Range(0, 999)]
    public float forceX = 30;
    [Header("���D"), Tooltip("���D����"), Range(0, 999)]
    public float forceJump = 30;
 
    public float forceDash = 100;

    //Attack
    public bool canAttack = false;
    public bool isAttacking = false;
    public int countAttack = 0;
    [Header("�����q��"), Tooltip("�����q��"), Range(1, 3)]
    public int multiAttack = 3;
    [Header("�����N�o"), Tooltip("�����N�o"), Range(0, 10)]
    public float cooldownAttack = 0.10f;
    public float damageAttack = 0;

    //Jump
    public bool canJump = false;
    public int countJump = 0;
    [Header("���D�q��"), Tooltip("���D�q��"), Range(1, 3)]
    public int multiJump = 2;
    [Header("���D�N�o"), Tooltip("���D�N�o"), Range(0, 10)]
    public float cooldownJump = 0.10f;

    //Dash
    public bool canDash = false;
    public bool isDashing = false;
    public int countDash = 0;
    [Header("�Ĩ�q��"), Tooltip("�Ĩ�q��"), Range(1, 3)]
    public int multiDash = 2;
    [Header("�Ĩ�N�o"), Tooltip("�Ĩ�N�o"), Range(0, 10)]
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

    //Hurt(�ͪ��@�k
    public bool isHurting;

    //Dead
    public bool isDead = false;

    public AudioClip SlashAud;
    public AudioClip JumpAud;
    public AudioClip DodgeAud;
    AudioSource audioSource;

    private void Start()
    {
        //�]�w��l�Ѽ�
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
        //���o�ʵe���A
        playerAniStateInfo = playerAni.GetCurrentAnimatorStateInfo(0);

        //�����ť�ð���H�U��k
        if (!(isHurting || isDead))
        {
            //�ʵe��ť
            if (!isRising)
                IsRising();
            if (!isFalling)
                IsFalling();

            //���O��ť
            if (!((isAttacking && isGrounded) || isDashing))
                MovementX();
            if (!isDashing)
                Attack();
            if (!((isAttacking && isGrounded) || isDashing))
                Jump();
            //if (!isAttacking)
                Dash();
        }

        //�x�s��e��m�A��U�@�V�Χ@�W�@�V����m
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
        //1.���w�C��
        Gizmos.color = new Color(1, 0, 0, 0.5f);

        //2.ø�s�ϧ�
        Gizmos.DrawSphere(transform.position + transform.right * groundOffset.x + transform.up * groundOffset.y, groundRadius);
    }

    //���]�ʧ@
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

    //��������
    void MovementX()
    {
        //���k�P�ɫ��ڴN����
        if ((Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D)) && (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A)))
        {
            playerAni.SetBool("isMoving", false);
        }
        //�k
        else if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            playerTra.eulerAngles = Vector3.zero;
            playerRig.transform.Translate(transform.right * forceX * Time.deltaTime);

            if (isGrounded)
                playerAni.SetBool("isMoving", true);
            else
                playerAni.SetBool("isMoving", false);
        }
        //��
        else if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            playerTra.eulerAngles = new Vector3(0, 180, 0);
            playerRig.transform.Translate(-transform.right * forceX * Time.deltaTime);

            if (isGrounded)
                playerAni.SetBool("isMoving", true);
            else
                playerAni.SetBool("isMoving", false);
        }
        //�䥦
        else
        {
            playerAni.SetBool("isMoving", false);
        }
    }

    //����
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

        //J����
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

    //���D
    void Jump()
    {
        if (countJump >= multiJump)
            canJump = false;

        //K���D
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

    //�Ĩ�
    void Dash()
    {
        if (!playerAniStateInfo.IsTag("Dash") && isDashing)
            StartCoroutine(CooldownDash());

        if (countDash >= multiDash)
            canDash = false;

        //L�Ĩ�
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

    //�O�_���b�W��
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

    //�O�_���b�U��
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

    //�ʵe�ƥ�
    void GoToNextAttackAction()
    {
        playerAni.SetInteger("attack", countAttack);
    }
}
