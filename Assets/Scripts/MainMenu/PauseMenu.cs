using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    public GameObject AccueilPause;
    public GameObject Parameter;
    public GameObject Credits;

    //public bool pause = false;
    void Awake()
    {
        AccueilPause.SetActive(false);
        Parameter.SetActive(false);
        Credits.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Parameter.activeInHierarchy == false && Credits.activeInHierarchy == false)
            {
                AccueilPause.SetActive(!AccueilPause.activeSelf);
                MainGame.Instance.Pause = AccueilPause.activeSelf;
            }
        }

    }
    public void OnClickResume()
    {
        AccueilPause.SetActive(false);
        MainGame.Instance.Pause = false;
    }
    public void OnClickRestart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void OnClickParameter()
    {
        AccueilPause.SetActive(false);
        Parameter.SetActive(true);
    }
    public void OnClickCredits()
    {
        AccueilPause.SetActive(false);
        Credits.SetActive(true);
    }

    public void OnClickReturn()
    {

        AccueilPause.SetActive(true);
        Credits.SetActive(false);
        Parameter.SetActive(false);
    }
    public void OnClickLeave()
    {
#if UNITY_STANDALONE
        Application.Quit();
#endif

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
