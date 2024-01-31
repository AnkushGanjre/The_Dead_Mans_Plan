using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneControllerScript : MonoBehaviour
{
    public void OnExit()
    {
        SceneManager.LoadScene("App Interface");
    }
    public void OnScene1()
    {
        SceneManager.LoadScene("Scene 1");
    }
    public void OnScene2()
    {
        SceneManager.LoadScene("Scene 2");
    }
    public void OnScene3()
    {
        SceneManager.LoadScene("Scene 3");
    }
    public void OnScene4()
    {
        SceneManager.LoadScene("Scene 4");
    }
    public void OnScene5()
    {
        SceneManager.LoadScene("Scene 5");
    }
}
