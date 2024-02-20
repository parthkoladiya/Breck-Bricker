using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [HideInInspector] public GameObject LeftSide, RightSide, UpSide, DownSide;
    [HideInInspector] public Vector2 CameraSet;
    [SerializeField] public GameObject Targate, Player, Paddle;
    [HideInInspector] Vector2 StartPoint, EndPoint;
    [SerializeField] public float Speed;
    [HideInInspector] public bool IsPaddle, IsJump;
    [SerializeField] GameObject[] BrickObj;
    [SerializeField] GameObject BrickParent;
    [SerializeField] public List<GameObject> BrickList;
    [HideInInspector] public Vector2 direction;



    private void Awake()
    {
        // Set Bordar By BoxCollider //

        instance = this;

        Vector2 SizeSet = new Vector2(Screen.width, Screen.height);
        CameraSet = Camera.main.ScreenToWorldPoint(SizeSet);

        LeftSide.GetComponent<BoxCollider2D>().size = new Vector2(1, CameraSet.y * 2);
        LeftSide.transform.position = new Vector2(-CameraSet.x - LeftSide.GetComponent<BoxCollider2D>().size.x / 2, 0);

        RightSide.GetComponent<BoxCollider2D>().size = new Vector2(1, CameraSet.y * 2);
        RightSide.transform.position = new Vector2(CameraSet.x + RightSide.GetComponent<BoxCollider2D>().size.x / 2, 0);

        UpSide.GetComponent<BoxCollider2D>().size = new Vector2(CameraSet.x * 2, 1);
        UpSide.transform.position = new Vector2(0, CameraSet.y + UpSide.GetComponent<BoxCollider2D>().size.y / 2);

        DownSide.GetComponent<BoxCollider2D>().size = new Vector2(CameraSet.x * 2, 1);
        DownSide.transform.position = new Vector2(0, -CameraSet.y - DownSide.GetComponent<BoxCollider2D>().size.y / 2);
    }

    // Ganrate Brick //

    private void Start()
    {
        //Instantiate(Player , new Vector2(Paddle.transform.position.x , Paddle.transform.position.y) , Quaternion.identity);

        for (int i = 0; i < 6; i++)
        {
            for (int j = 0; j < 6; j++)
            {
                GameObject brick = Instantiate(BrickObj[i], BrickParent.transform);
                brick.transform.localPosition = new Vector2(j * 0.8f, i * 0.5f);
            }
            BrickParent.transform.position = new Vector2(-2, 2f);
        }
    }

    // Set Targete That Move On Mouse Click //

    private void Update()
    {
        if (!IsPaddle)
        {
            if (Input.GetMouseButtonDown(0))
            {
                StartPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            }

            if (Input.GetMouseButton(0))
            {
                EndPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                direction = EndPoint - StartPoint;

                float SetX = Mathf.Clamp(direction.x, -40, 40);
                float SetY = Mathf.Abs(direction.y);

                Targate.transform.up = new Vector2(SetX, SetY);
            }

            if (Input.GetMouseButtonUp(0))
            {
                Targate.SetActive(false);
                IsPaddle = true;
                IsJump = true;
            }
        }
    }
    private void FixedUpdate()
    {
        if (IsJump)
        {
            direction.Normalize();
            Player.GetComponent<Rigidbody2D>().AddForce(direction * Speed);
            IsJump = false;
        }
    }
}