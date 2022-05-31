using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public string m_sceneToLoad;

    public void OnButtonPress()
    {
        SceneManager.LoadScene(m_sceneToLoad);
    }
}
