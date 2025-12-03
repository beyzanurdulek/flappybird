using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartButtonScript : MonoBehaviour
{
    public void RestartGame()
    {
        Debug.Log("RestartGame ÇAĞRILDI!");   // Konsolda göreceğiz

        Time.timeScale = 1f; // oyunu tekrar akıt
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.buildIndex);
    }
}
