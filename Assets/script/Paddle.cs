using System.Collections;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    Vector3 PlayerPosition;
    [SerializeField] GameObject DubblBall;
    [SerializeField] Sprite Largepaddle, NormalPaddle;


    // Find Player Position continuously //

    private void Start()
    {
        PlayerPosition = GameManager.instance.Player.transform.position;
    }

    // Set Paddle As Mouse Movement And Set Fix By Clamp On X Axis //

    void Update()
    {
        // Accessing player position //

        PlayerPosition = GameManager.instance.Player.transform.position;

        if (GameManager.instance.IsPaddle)
        {
            if (Input.GetMouseButton(0))
            {
                Vector2 paddle = Camera.main.ScreenToWorldPoint(Input.mousePosition);

                float rightSide = GameManager.instance.CameraSet.x - (this.transform.GetComponent<BoxCollider2D>().size.x / 2);
                float leftSide = -GameManager.instance.CameraSet.x + (this.transform.GetComponent<BoxCollider2D>().size.x / 2);
                paddle.x = Mathf.Clamp(paddle.x, leftSide, rightSide);
                this.transform.position = new Vector2(paddle.x, this.transform.position.y);
            }
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Set A Dubble Ball When Ball Collision Paddle //

        if (collision.gameObject.CompareTag("DubbleBall"))
        {
            Destroy(collision.gameObject);

            GameObject newDubblBall = Instantiate(DubblBall, PlayerPosition, Quaternion.identity);
            Rigidbody2D newDubblBallRb = newDubblBall.GetComponent<Rigidbody2D>();

            if (newDubblBallRb != null)
            {
                newDubblBallRb.AddForce(GameManager.instance.direction * GameManager.instance.Speed);
            }

            // Start a coroutine to destroy the newDubblBall after 5 seconds
            StartCoroutine(DestroyAfterDelay(newDubblBall, 5f));
        }

        // BigPaddle Active //

        if (collision.gameObject.CompareTag("PaddleBig"))
        {
            Destroy(collision.gameObject);

            StartCoroutine(ChangeSpriteForDuration(Largepaddle, 5f));
        }
    }

    // Change Paddle Sprite When BigPaddle Collider //

    private IEnumerator ChangeSpriteForDuration(Sprite newSprite, float duration)
    {
        GetComponent<SpriteRenderer>().sprite = newSprite;

        yield return new WaitForSeconds(duration);

        GetComponent<SpriteRenderer>().sprite = NormalPaddle;
    }

    // Destroy the object after a specified delay //

    IEnumerator DestroyAfterDelay(GameObject obj, float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(obj);
    }
}
