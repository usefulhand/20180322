using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    public int hp;

    private void Awake()
    {
        hp = 10;
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (hp <= 0)
            Die();
    }

    void Die()
    {
        Destroy(this.gameObject);
    }
}
