using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyFirstScript : MonoBehaviour
{
    public float m_moveSpeed = 1.0f;    // units per second

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Start() " + name);
    }

    // Update is called once per frame
    void Update()
    {
        float move = 0.0f;
        if (Input.GetKey(KeyCode.A))
            move -= 1.0f;
        if (Input.GetKey(KeyCode.D))
            move += 1.0f;

        Vector3 pos = transform.position;
        pos.x += move * m_moveSpeed * Time.deltaTime;
        transform.position = pos;

        Debug.Log("Update()");
    }
}
