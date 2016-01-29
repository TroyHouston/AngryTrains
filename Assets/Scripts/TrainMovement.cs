using UnityEngine;
using System.Collections;

public class TrainMovement : MonoBehaviour
{

    public float turnSpeed = 100.0f;  // Units per second
    public float moveSpeed = 100.0f;  // Units per second
    public float moveDampening = 0.05f;
    public float minRot = -30;
    public float maxRot = 30;

    public Camera cam;
    private Rigidbody rigid;

    // Use this for initialization
    void Start()
    {
        rigid = GetComponent<Rigidbody>();
    }

    void Update()
    {
        //Left click
        if (Input.GetMouseButton(0))
        {
            //Find out what the mouse is pointing at
            //TODO make it so it only raycasts at the ground
            //TODO ignore 0,0,0 case if you click on the sky
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            Physics.Raycast(ray, out hit);
            Vector3 targetPos = hit.point - transform.position;
            //Maybe don't make it try to go up or down as this will probably make the physics weird
            targetPos.y = transform.position.y;
            targetPos = Vector3.ClampMagnitude(targetPos, 5);

            Vector3 targetVel = Vector3.Lerp(rigid.velocity, targetPos, 3);
            rigid.AddRelativeForce(targetVel * moveSpeed * Time.deltaTime);


            //rigid.AddTorque(targetPos * Time.deltaTime, ForceMode.VelocityChange);
        }

        //Should dampen movement even if you stop clicking
        rigid.velocity *= 1f - moveDampening * Time.deltaTime;

        Quaternion curAngle = rigid.rotation;
    }

    public float clampAngle(float f)
    {
        return Mathf.Clamp(f, minRot, maxRot);
    }
}
