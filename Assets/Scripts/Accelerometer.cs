using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Accelerometer : MonoBehaviour
{
    public enum Element
    { 
        ACC_X,
        ACC_Y,
        ACC_Z,
        RAW,
        CROSS_FORWARD,
        CROSS_RIGHT
    }
    public Element m_element;

    TextMeshProUGUI m_text;
    static Vector3 s_zeroAxis;
    static float s_deadZone = 0.0f;
    static float s_maximum = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        m_text = GetComponent<TextMeshProUGUI>();
        Calibrate();
    }

    public void Calibrate()
    {
        s_zeroAxis = Input.acceleration.normalized;
    }

    public void SetDeadZone(float value)
    {
        s_deadZone = value;
    }

    public void SetMaximum(float value)
    {
        s_maximum = value;
    }

    // Update is called once per frame
    void Update()
    {
        switch (m_element)
        {
            case Element.ACC_X:
                if (m_text)
                    m_text.text = Input.acceleration.x.ToString();
                break;
            case Element.ACC_Y:
                if (m_text)
                    m_text.text = Input.acceleration.y.ToString();
                break;
            case Element.ACC_Z:
                if (m_text)
                    m_text.text = Input.acceleration.z.ToString();
                break;
            case Element.RAW:
                {
                    Vector3 pos = transform.position;
                    transform.LookAt(pos + Input.acceleration, Vector3.up);
                }
                break;
            case Element.CROSS_FORWARD:
                if (m_text)
                {
                    Vector3 acc = Input.acceleration;
                    acc.Normalize();
                    Vector3 cross = Vector3.Cross(s_zeroAxis, acc);
                    // forward/back is always the phone X axis
                    m_text.text = ApplyPowerAndDeadZone(cross.x).ToString();
                }
                break;
            case Element.CROSS_RIGHT:
                if (m_text)
                {
                    Vector3 acc = Input.acceleration;
                    acc.Normalize();
                    Vector3 cross = Vector3.Cross(s_zeroAxis, acc);
                    // left/right is an axis parallel to the ground and perpendicular to the X axis
                    Vector3 axis = Vector3.Cross(s_zeroAxis, Vector3.right).normalized;
                    float answer = Vector3.Dot(cross, axis);
                    m_text.text = ApplyPowerAndDeadZone(answer).ToString();
                }
                break;
        }
    }

    static float ApplyPowerAndDeadZone(float input)
    {
        if (Mathf.Abs(input) <= s_deadZone)
            return 0.0f;
        float sign = Mathf.Sign(input);
        float output = sign * input;
        output = (output - s_deadZone) / (s_maximum - s_deadZone);
        output = Mathf.Clamp01(output);
        output = sign * output;
        return output;
    }
}
