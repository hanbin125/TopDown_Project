using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger2D : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other != null && other.CompareTag("Plane"))
        {
            SceneManager.LoadScene("PlaneScene");
        }
        else if (other != null && other.CompareTag("Stack"))
        {
            SceneManager.LoadScene("StackScene");
        }
    }
}
