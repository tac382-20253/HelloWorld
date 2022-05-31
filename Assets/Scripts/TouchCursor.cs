using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TouchCursor : MonoBehaviour
{
    public Color m_touchColor;
    public Color m_releaseColor;

    Image m_image;

    // Start is called before the first frame update
    void Start()
    {
        m_image = GetComponent<Image>();    
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Vector3 pos = Input.mousePosition;
            m_image.transform.position = pos;
            m_image.color = m_touchColor;
        }
        else
        {
            m_image.color = m_releaseColor;
        }
    }
}
