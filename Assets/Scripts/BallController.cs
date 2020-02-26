using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] float speed;
    bool start;
    bool gameOver;
    public GameObject Partical;
    // Start is called before the first frame update
    private void Awake()
    {
        start = false;
        gameOver = false;
    }
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(transform.position, Vector3.down,Color.red);
        if(!Physics.Raycast(transform.position,Vector3.down,1f))
        {
            gameOver = true;
            rb.velocity = new Vector3(0, -25f, 0);
            Camera.main.GetComponent<CameraFollow>().gameOver = true;
            GameManager.instance.GameOver();
        }
        if(!start)
        {
            if(Input.GetMouseButtonDown(0))
            {
                rb.velocity = new Vector3(speed, 0, 0)*Time.deltaTime;
                start = !start;
                GameManager.instance.GameStart();
            }
        }
        else
        {
            if (Input.GetMouseButtonDown(0)&& !gameOver)
            {
                SwitchDirection();
            }
        }
    }
    private void SwitchDirection()
    {
        if(rb.velocity.z > 0)
        {
            rb.velocity = new Vector3(speed, 0, 0)*Time.deltaTime;
        }else if(rb.velocity.x > 0)
        {
            rb.velocity = new Vector3(0, 0, speed)*Time.deltaTime;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "diamond")
        {
            GameObject part = Instantiate(Partical, other.gameObject.transform.position, Quaternion.identity) as GameObject;
            Destroy(other.gameObject);
            Destroy(part, 1f);
        }
    }
}
