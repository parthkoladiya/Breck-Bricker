using UnityEngine;
using UnityEngine.SceneManagement;

public class Collide : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player") // 3
        {
            collision.gameObject.SetActive(false);
            Debug.Log("Player");
            SceneManager.LoadScene(0);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "DubbleBall")
        {
            Destroy(collision.gameObject);
            Debug.Log("DubbleBall");
        }
    }
}   