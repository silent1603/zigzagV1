using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject platForm;
    public GameObject Diamomnd;
    [SerializeField]Vector3 lastPos;
    [SerializeField]float size;


    private void Awake()
    {

    }
    void Start()
    {

        size = platForm.transform.localScale.x;
        lastPos = platForm.transform.position;

    }
    public void StartSpawningPlatforms()
    {
        InvokeRepeating("SpawnPlatform", 0.2f,0.3f);
    }
    void SpawnPlatform()
    {
        int rand = Random.Range(0, 6);
        if(rand < 3)
        {
            SpawnX();
        }
        else
        {
            SpawnZ();
        }

    }
    // Update is called once per frame
    void Update()
    {

       if(GameManager.instance.gameOver)
        {
            CancelInvoke("SpawnPlatform");
        }
    }

    void SpawnX()
    {
        Vector3 pos = lastPos;
        pos.x += size;
        lastPos = pos;
        Instantiate(platForm, lastPos, Quaternion.identity);
        SpawnDiamond(pos);
    }

    void SpawnZ()
    {
        Vector3 pos = lastPos;
        pos.z += size;
        lastPos = pos;
        Instantiate(platForm, lastPos, Quaternion.identity);
        SpawnDiamond(pos);
    }
    void SpawnDiamond(Vector3 pos)
    {
        int ran = Random.Range(0, 4);
        if(ran == 1)
        {
            Instantiate(Diamomnd, new Vector3(pos.x,pos.y+1,pos.z), Quaternion.identity);
        }
    }
}
