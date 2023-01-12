using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject Menu;
    public GameObject Credits;
    public GameObject Settings;


    private void Start()
    {
        Menu.SetActive(true);
        Credits.SetActive(false);
        Settings.SetActive(false);
    }
    public void ClickPlay()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void ClickCredit()
    {
        Menu.SetActive(false);
        Credits.SetActive(true);
    }
    public void ClickParameter()
    {
        Menu.SetActive(false);
        Settings.SetActive(true);
    }
    public void ClickReturn()
    {
            Settings.SetActive(false);
            Menu.SetActive(true);
            Credits.SetActive(false);
    }
    public void Quit()
    {
        //If we are running in a standalone build of the game
#if UNITY_STANDALONE
        //Quit the application
        Application.Quit();
#endif

        //If we are running in the editor
#if UNITY_EDITOR
        //Stop playing the scene
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
