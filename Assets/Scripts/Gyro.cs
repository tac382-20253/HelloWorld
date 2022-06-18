using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gyro : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        Debug.Log(Input.gyro.enabled);
        transform.rotation = Input.gyro.attitude;        
    }
}
