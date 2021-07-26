using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowBehavior : MonoBehaviour
{
    public GameObject followThis;

    // Update is called once per frame
    void Update()
    {
        transform.rotation = followThis.transform.rotation;
        transform.position = followThis.transform.position;
        GetComponent<Camera>().fieldOfView = followThis.GetComponent<Camera>().fieldOfView;
    }
}
