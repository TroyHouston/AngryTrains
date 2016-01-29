using UnityEngine;
using System.Collections;

public class FollowCam : MonoBehaviour {

    public Vector3 offset;
    public GameObject following;

    // Update is called once per frame
    void Update () {
        transform.position = following.transform.position + offset;
        transform.LookAt(following.transform.position);
	}
}
