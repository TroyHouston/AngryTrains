using UnityEngine;
using System.Collections;

public class FollowCam : MonoBehaviour {

    public Vector3 offset;
    public GameObject following;
    public bool firstPersonMode;

    // Update is called once per frame
    void Update () {
        if (!firstPersonMode)
        {
            transform.position = following.transform.position + offset;
            transform.LookAt(following.transform.position);
        }
        else
        {
            transform.position = following.transform.position
                + following.transform.forward * 3f
                + following.transform.up * 0.5f;
            transform.rotation = following.transform.rotation;
        }
	}
}
