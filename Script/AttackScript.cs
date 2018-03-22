using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackScript : MonoBehaviour
{
    enum keyCode { X, C, RightArrow, LeftArrow, UpArrow, DownArrow, Space, NULL };

    public GameObject Player;

    float timer = 0.3f;
    bool isKeyDown = false;

    int inputCount = 0;

    bool comCheck = false;
    public int comSlot = 999;

    List<bool> comL = new List<bool>();

    // ForTest
    List<int> inputKeyList = new List<int>();
    List<int> testList = new List<int>();

    List<List<int>> cList = new List<List<int>>();

    // 위,아래 공격
    List<int> upperAttack = new List<int>();
    List<int> downAttack = new List<int>();

    // 백스탭 + 어택
    List<int> backStepAttack = new List<int>();

    List<int> leftDash = new List<int>();
    List<int> rightDash = new List<int>();

    List<int> attack = new List<int>();

    // 입력받을때마다 커맨드를 체크
    void ComCheck()
    {
        // cList라는 미리 지정해둔 커맨드들을 모두 체크
        for (int i = 0; i < cList.Count; i++)
        {
            for (int j = 0; j < cList[i].Count; j++)
            {
                // 앞에서부터 체크 중 틀린 자리가 있으면 바로 다음커맨드로 넘어감
                if (inputKeyList[j] != cList[i][j]) break;
                if (cList[i].Count - 1 == j)
                {
                    comSlot = i;
                    ActionCom();
                    print("Shot");
                    return;
                }
            }
        }

        inputKeyList.RemoveRange(0, inputKeyList.Count - 1);
    }

    // 커맨드가 일치했을 때 실행하는 것들
    void ActionCom()
    {
        inputKeyList.Clear();

        if (comSlot == 0)
            print("up attack");
        else if (comSlot == 1)
            print("down attack");
        else if (comSlot == 2)
        {
            Player.GetComponent<Rigidbody2D>().AddForce(new Vector2(-20.0f, 0.0f), ForceMode2D.Impulse);
            comSlot = 999;
            print("back step attack");
        }
        else if (comSlot == 3)
        {
            Player.GetComponent<Rigidbody2D>().AddForce(new Vector2(-10.0f, 0.0f), ForceMode2D.Impulse);
            comSlot = 999;
        }
        else if (comSlot == 4)
        {
            Player.GetComponent<Rigidbody2D>().AddForce(new Vector2(10.0f, 0.0f), ForceMode2D.Impulse);
            comSlot = 999;
        }
    }

    // Use this for initialization
    void Start()
    {
        upperAttack.Add(0);
        upperAttack.Add(4);
        upperAttack.Add(0);

        downAttack.Add(5);
        downAttack.Add(0);

        backStepAttack.Add(6);
        backStepAttack.Add(0);

        leftDash.Add(3);
        leftDash.Add(3);

        rightDash.Add(2);
        rightDash.Add(2);

        cList.Add(upperAttack);
        cList.Add(downAttack);
        cList.Add(backStepAttack);
        cList.Add(leftDash);
        cList.Add(rightDash);
    }

    // inputKeyList 초기화
    void InitList()
    {
        timer = 0.3f;
        inputKeyList.RemoveRange(0, inputKeyList.Count - 1);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown)
        {
            isKeyDown = true;
            InputKey();
            ComCheck();
        }

        // 키 입력중 타이머
        if (isKeyDown)
        {
            timer -= Time.deltaTime;
            if (timer <= 0.0f)
            {
                inputKeyList.Clear();
                isKeyDown = false;
            }
        }
    }

    // 키를 입력받는 함수
    void InputKey()
    {
        timer = 0.3f;
        if (Input.GetKeyDown(KeyCode.Space))
            inputKeyList.Add((int)keyCode.Space);

        if (Input.GetKeyDown(KeyCode.X))
            inputKeyList.Add((int)keyCode.X);

        if (Input.GetKeyDown(KeyCode.C))
            inputKeyList.Add((int)keyCode.C);

        if (Input.GetKeyDown(KeyCode.UpArrow))
            inputKeyList.Add((int)keyCode.UpArrow);

        if (Input.GetKeyDown(KeyCode.DownArrow))
            inputKeyList.Add((int)keyCode.DownArrow);

        if (Input.GetKeyDown(KeyCode.RightArrow))
            inputKeyList.Add((int)keyCode.RightArrow);

        if (Input.GetKeyDown(KeyCode.LeftArrow))
            inputKeyList.Add((int)keyCode.LeftArrow);

        // 리스트에 저장할 갯수를 한정해놓음
        if (inputKeyList.Count > 6)
            inputKeyList.Remove(0);
    }
}