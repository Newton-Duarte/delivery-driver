using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuActions : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }

    public void TitleScreen()
    {
        SceneManager.LoadScene(0);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
