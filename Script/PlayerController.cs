using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Animator animator;

    Rigidbody2D rigid;
    public GameObject attackBox;
    Vector3 moveVelocity;
    Vector3 dashVelocity;
    float moveSpeed = 7.0f;
    float jumpPower = 20.0f;
    float dashPower = 10.0f;

    bool forTest = false;
    bool attackType = false;

    float timer = 0.3f;
    float attackTimer = 0.3f;

    // false = 좌, true = 우
    bool characterDirection;

    SpriteRenderer sRenderer;

    bool isMove;
    bool isJump;
    bool isAttack;
    bool isDash;

    int attackCount;

    private void Awake()
    {
        rigid = gameObject.GetComponent<Rigidbody2D>();
        sRenderer = gameObject.GetComponent<SpriteRenderer>();
        animator = gameObject.GetComponent<Animator>();
    }

    void Init()
    {
        characterDirection = true;
        isMove = false;
        isJump = false;
        isAttack = false;
        isDash = false;
        attackCount = 0;
        dashVelocity = Vector3.left;
    }

    // Use this for initialization
    void Start()
    {
        Init();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
            isJump = true;
        if (Input.GetKeyDown(KeyCode.Space))
            isDash = true;
        if (Input.GetKeyUp(KeyCode.X))
            Attack();
        if (Input.GetKey(KeyCode.X))
            AttackTimer();
    }

    private void FixedUpdate()
    {
        Jump();
        Move();
        Dash();
    }

    //--------------------------------------------
    // 이동 관련
    void Move()
    {
        moveVelocity = Vector3.zero;
        if (Input.GetKeyDown(KeyCode.RightArrow))
            this.transform.eulerAngles = new Vector3(0.0f, 180.0f, 0.0f);

        if (Input.GetKeyDown(KeyCode.LeftArrow))
            this.transform.eulerAngles = new Vector3(0.0f, 0.0f, 0.0f);


        if (Input.GetAxisRaw("Horizontal") == 0)
        {
            timer = 0.3f;
            forTest = false;
            return;
        }
        if (Input.GetAxisRaw("Horizontal") > 0)
        {
            characterDirection = true;
            moveVelocity = Vector3.right;
            forTest = true;
        }

        else if (Input.GetAxisRaw("Horizontal") < 0)
        {
            characterDirection = false;
            moveVelocity = Vector3.left;
            forTest = true;
        }

        transform.position += moveVelocity * moveSpeed * Time.deltaTime;
    }

    //--------------------------------------------
    // 점프 관련
    void Jump()
    {
        if (!isJump)
            return;

        rigid.velocity = Vector2.zero;

        Vector2 newVec = new Vector2(0, jumpPower);
        rigid.AddForce(newVec, ForceMode2D.Impulse);

        isJump = false;
    }

    //--------------------------------------------
    // 구르기 관련

    void Dash()
    {
        if (!isDash)
            return;

        rigid.AddForce(-dashVelocity * dashPower, ForceMode2D.Impulse);

        isDash = false;
    }

    //--------------------------------------------
    // 공격 관련

    void Attack()
    {
        if (isJump || isDash)
            return;

        // 기를 모은 공격
        if (attackType)
        {
            //print("기 발사!!");
        }

        // 기를 모으지 않은 일반 공격
        else
        {
            //print("평타!!");
            attackBox.GetComponent<BoxCollider2D>().enabled = true;
        }
        // 여기에서 공격력 초기화
        attackTimer = 0.3f;
    }

    // 여기에서 0.3초 이후 시간별로 이펙트, 애니메이션, 공격력 조절
    void AttackTimer()
    {
        attackTimer -= Time.deltaTime;
        if (timer <= 0.0f)
            attackType = true;
        else
            attackType = false;
    }

    // 임시
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Coin")
            Destroy(collision.gameObject);
    }
}