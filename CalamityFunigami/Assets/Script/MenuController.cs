using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public void StartGame() => SceneManager.LoadScene(2);

    public void Continue()
    {
        Debug.Log("Continue");
        //todo
    }

    public void Credits()
    {
        Debug.Log("Credits");
        //todo
    }

    public void Options()
    {
        Debug.Log("Options");
        //todo
    }

    public void Exit() => Application.Quit();
}
