using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class dpi : MonoBehaviour
{
    public enum Type
    {
        DPI,
        DPI_X,
        DPI_Y,
        SCREEN_W,
        SCREEN_H
    }
    public Type m_type = Type.DPI;
    TextMeshProUGUI m_text;

    // Start is called before the first frame update
    void Start()
    {
        m_text = GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        Vector2 dpi = GetDPI();

        switch (m_type)
        {
            case Type.DPI:
                m_text.text = Screen.dpi.ToString();
                break;
            case Type.DPI_X:
                m_text.text = dpi.x.ToString();
                break;
            case Type.DPI_Y:
                m_text.text = dpi.y.ToString();
                break;
            case Type.SCREEN_W:
                m_text.text = Screen.width.ToString();
                break;
            case Type.SCREEN_H:
                m_text.text = Screen.height.ToString();
                break;
        }
    }

    Vector2 GetDPI()
    {
        if (Application.platform != RuntimePlatform.Android)
            return Vector2.zero;

        AndroidJavaClass activityClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        AndroidJavaObject activity = activityClass.GetStatic<AndroidJavaObject>("currentActivity");

        AndroidJavaObject metrics = new AndroidJavaObject("android.util.DisplayMetrics");
        activity.Call<AndroidJavaObject>("getWindowManager").Call<AndroidJavaObject>("getDefaultDisplay").Call("getMetrics", metrics);

        return new Vector2(metrics.Get<float>("xdpi"), metrics.Get<float>("ydpi"));
    }
}
