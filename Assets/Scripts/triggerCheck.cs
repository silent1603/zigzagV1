using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerCheck : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            Invoke("Fall", 0.5f);

        }
    }
    private void Fall()
    {
        GetComponentInParent<Rigidbody>().isKinematic = false;
        GetComponentInParent<Rigidbody>().useGravity = true;
        Destroy(transform.parent.gameObject,2f);
    }
}
