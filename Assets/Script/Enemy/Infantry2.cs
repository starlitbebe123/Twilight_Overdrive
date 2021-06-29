using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Infantry2 : MonoBehaviour
{
    #region ���
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

    //��l�t��
    private float speedOriginal;


    #endregion

    #region �ƥ�
    private void Start()
    {
        ani = GetComponent<Animator>();
        rig = GetComponent<Rigidbody2D>();
        //���a = �C������.�M��("����W��) �j�M�������Ҧ�����
        //transform.Find  �O�j�M�l����
        player = GameObject.FindGameObjectWithTag("Player").transform;

        //���ĤH�@�}�l�N�i�����
        cdTimer = cd;

        //��l�t��
        speedOriginal = speed;
    }

    private void Update()
    {
        Move();
    }

    private void OnDrawGizmos()
    {
        //�l�ܽd��
        Gizmos.color = new Color(0, 1, 0, 0.3f);
        Gizmos.DrawSphere(transform.position, radiusTrack);
        //�����d��
        Gizmos.color = new Color(1, 0, 0, 0.3f);
        Gizmos.DrawSphere(transform.position, radiusAttack);
        //�������e�O���O�a�O
        Gizmos.color = new Color(0.6f, 0.9f, 1, 0.7f);
        Gizmos.DrawSphere(transform.position + transform.right * groundOffset.x + transform.up * groundOffset.y, groundRadius);

        //�����d��
        Gizmos.color = new Color(0.3f, 0.3f, 1, 0.8f);
        Gizmos.DrawCube(transform.position + transform.right * attackOffset.x + transform.up * attackOffset.y, attackSize);
    }
    #endregion
    #region ��k
    private void Move()
    {
        

        //�Z�� = �T��V�q.�Z��(A�I-B�I)
        float dis = Vector3.Distance(player.position, transform.position);

        //�p�G ���a��ĤH �� �Z�� �p�󵥩� �����d�� �N����
        if (dis <= radiusAttack)
        {
            Attack();
            ani.SetBool("Attack",true);

        }
        //�_�h �p�G ���a��ĤH �� �Z�� �p�󵥩� �l�ܽd�� �N���e�貾��
        else if (dis <= radiusTrack && isAttacking == false)
        {
            rig.velocity = transform.right * speed * Time.deltaTime;
            ani.SetBool("Walk", speed != 0); //�t�פ�����s �~�|���� �����ʵe
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
        //�p�G �p�ɾ� <= �����N�o �N�֥[
        if (cdTimer <= cd)
        {
            cdTimer += Time.deltaTime;
        }
        //�_�h ���� �� �N�p�ɾ��k�s
        else
        {
            cdTimer = 0;
            
            //�I������ = 2D���z.�л\����(�����I, �ؤo, ����)
        }
    }

    private void LookAtPlayer()
    {
        //�p�G �ĤHx �j�� ���ax ���N���a�b���� ����180
        if (transform.position.x > player.position.x)
        {
            transform.eulerAngles = Vector3.zero;
        }
        //�_�h �ĤHx �p�� ���ax �N�N���a�b�k�� ����0
        else
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
    }

    //�ˬd�O�_���a�O
    private void CheckGround()
    {
        Collider2D hit = Physics2D.OverlapCircle(transform.position + transform.right * groundOffset.x + transform.up * groundOffset.y, groundRadius, 1 << 8);

        //�P�_�� �{���u���@�y (�@�Ӥ���) �i�H�ٲ� �j�A��
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
