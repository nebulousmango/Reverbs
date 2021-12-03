using UnityEngine.SceneManagement;
using UnityEngine;

public class Fail : MonoBehaviour
{
    /*
    Scene gameScene;

    private void Start()
    {
        gameScene = SceneManager.GetActiveScene();
    }
    */

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<PlayerController>() == true)
        {
            //SceneManager.LoadScene(gameScene.buildIndex);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}