using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Example : MonoBehaviour
{
    TextMeshProUGUI m_text;

    // Start is called before the first frame update
    void Start()
    {
        m_text = GetComponent<TextMeshProUGUI>();
        StartCoroutine(UpdateCo());
    }

#if false
    // Update is called once per frame
    void Update()
    {
        m_timer -= Time.deltaTime;
        if (m_timer <= 0.0f)
        {
            m_timer += 1.0f;
            if (State.COUNTDOWN == m_state)
            {
                --m_count;
                if (m_count == 0)
                {
                    m_state = State.COUNTUP;
                }
            }
            else
            {
                ++m_count;
                if (m_count == 3)
                {
                    m_state = State.COUNTDOWN;
                }
            }
            m_text.text = m_count.ToString();
        }
    }
#endif

    IEnumerator UpdateCo()
    {
        int count;
        while (true)
        {
            // count down
            count = 3;
            while (count >= 0)
            {
                m_text.text = count.ToString();
                yield return new WaitForSeconds(1.0f);
                --count;
            }

            // count up
            count = 1;
            while (count < 3)
            {
                m_text.text = count.ToString();
                yield return new WaitForSeconds(1.0f);
                ++count;
            }
        }
    }
}
