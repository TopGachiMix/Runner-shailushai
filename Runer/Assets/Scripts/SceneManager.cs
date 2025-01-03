using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneManagers : MonoBehaviour
{
    


    public void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
