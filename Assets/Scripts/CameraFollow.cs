using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CameraFollow : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject ball;
    Vector3 offset;
    [SerializeField]
    [Range(0,10f)]
    float lerpSpeed;
     public bool gameOver;
    private void Awake()
    {
        gameOver = false;

    }
    void Start()
    {
        offset = transform.position - ball.transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        if(!gameOver)
        {
            Follow();
        }
    }
     void Follow()
    {
        Vector3 pos = transform.position;
        Vector3 target = ball.transform.position+offset;
        pos = Vector3.Lerp(pos,target,lerpSpeed*Time.deltaTime);
        transform.position = pos;

    }
}
