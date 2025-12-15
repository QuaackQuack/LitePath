using UnityEngine.SceneManagement;
using UnityEngine;

public class WinCondition : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            SceneManager.LoadScene("winCondition");
            Debug.Log("You Win!");
        }
    }
}
