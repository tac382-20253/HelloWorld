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
        ACC_Z
    }
    public Element m_element;

    TextMeshProUGUI m_text;

    // Start is called before the first frame update
    void Start()
    {
        m_text = GetComponent<TextMeshProUGUI>();        
    }

    // Update is called once per frame
    void Update()
    {
        switch (m_element)
        {
            case Element.ACC_X:
                m_text.text = Input.acceleration.x.ToString();
                break;
            case Element.ACC_Y:
                m_text.text = Input.acceleration.y.ToString();
                break;
            case Element.ACC_Z:
                m_text.text = Input.acceleration.z.ToString();
                break;
        }
    }
}
