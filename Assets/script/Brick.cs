using UnityEngine;

public class Brick : MonoBehaviour
{
    [SerializeField] Sprite brickSprite;
    [SerializeField] GameObject DubbleBall , PaddleBig;
    [SerializeField] GameObject ExplosionAnim;
    private bool IsChangeSprite;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (!IsChangeSprite)
            {
                GetComponent<SpriteRenderer>().sprite = brickSprite;
                IsChangeSprite = true;
            }
            else
            {
                Destroy(gameObject);

                GameObject Anim = Instantiate(ExplosionAnim, this.transform.position, Quaternion.identity);
                Destroy(Anim , 0.5f);

                GameManager.instance.BrickList.Add(gameObject);

                if(GameManager.instance.BrickList.Count == 36)
                {
                    Debug.Log("Game Winn");
                }
                if (GameManager.instance.BrickList.Count == 2)
                {
                    Vector3 collisionPoint = collision.contacts[0].point;
                    Instantiate(DubbleBall, collisionPoint, Quaternion.identity);

                    DubbleBall.GetComponent<Rigidbody2D>();
                }
                if(GameManager.instance.BrickList.Count == 4)
                {
                    Vector3 collisionPoint = collision.contacts[0].point;
                    Instantiate(PaddleBig, collisionPoint, Quaternion.identity);

                    DubbleBall.GetComponent<Rigidbody2D>();
                }
                if(GameManager.instance.BrickList.Count == 10)
                {
                    Vector3 collisionPoint = collision.contacts[0].point;
                    Instantiate(DubbleBall, collisionPoint, Quaternion.identity);

                    DubbleBall.GetComponent<Rigidbody2D>();
                }
                if (GameManager.instance.BrickList.Count == 15)
                {
                    Vector3 collisionPoint = collision.contacts[0].point;
                    Instantiate(PaddleBig, collisionPoint, Quaternion.identity);

                    DubbleBall.GetComponent<Rigidbody2D>();
                }
                if (GameManager.instance.BrickList.Count == 20)
                {
                    Vector3 collisionPoint = collision.contacts[0].point;
                    Instantiate(PaddleBig, collisionPoint, Quaternion.identity);

                    DubbleBall.GetComponent<Rigidbody2D>();
                }
                if (GameManager.instance.BrickList.Count == 25)
                {
                    Vector3 collisionPoint = collision.contacts[0].point;
                    Instantiate(DubbleBall, collisionPoint, Quaternion.identity);

                    DubbleBall.GetComponent<Rigidbody2D>();
                }
                if (GameManager.instance.BrickList.Count == 30)
                {
                    Vector3 collisionPoint = collision.contacts[0].point;
                    Instantiate(DubbleBall, collisionPoint, Quaternion.identity);

                    DubbleBall.GetComponent<Rigidbody2D>();
                }
            }
        }
    }
}