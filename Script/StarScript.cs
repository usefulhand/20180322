using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarScript : MonoBehaviour
{

    Vector3 velocity = Vector3.zero;
    Transform playerPosition;

    private void Awake()
    {
        playerPosition = GameObject.FindWithTag("Player").transform;
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 force = playerPosition.position - this.gameObject.transform.position;
        float r = force.magnitude;

        force.Normalize();
        force *= 100;
        force /= r * r;

        Vector3 acceleration = force / 3;

        velocity += acceleration * Time.deltaTime;
        transform.position += velocity * Time.deltaTime;
    }
}
