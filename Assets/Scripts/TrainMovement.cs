using UnityEngine;
using System.Collections;

public class TrainMovement : MonoBehaviour
{

    public float turnSpeed = 100.0f;  // Units per second
    public float moveSpeed = 100.0f;  // Units per second

    private const string xAxisName = "Horizontal";
    private const string yAxisName = "Vertical";

    public GameObject indicator;
    public Camera cam;
    public Score score;
    //public GameObject backConnector;
    private Rigidbody rigid;
    private bool hasGamepad = false;

    private bool testBool = false;

    // Use this for initialization
    void Start()
    {
        rigid = GetComponent<Rigidbody>();
        if (Input.GetJoystickNames().Length > 0) hasGamepad = true;
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag.Equals("RitualGoers"))
        {
            HitVillager(col);
        }
    }

    public void HitVillager(Collider col)
    {
        try {
            col.gameObject.GetComponent<RitualGoer>().Die(col);
        }catch(System.NotImplementedException)
        {

        }
        Destroy(col);

        score.villagerHit();
    }

    void Update()
    {
        Vector3 curPos = transform.position;
        curPos.y = 0.5f;
        transform.position = curPos;

        Vector3 gamePadPointing = new Vector3();
        if (hasGamepad)
        {
            float hz = Input.GetAxis(xAxisName);
            float vr = Input.GetAxis(yAxisName);
            gamePadPointing = new Vector3(hz * 5f, 0.0f, vr * 5f);
        }
        //Left click
        if (Input.GetMouseButton(0) || (hasGamepad && gamePadPointing.magnitude > 0))
        {
            Vector3 targetPos;
            if (Input.GetMouseButton(0)) { 
                //Find out what the mouse is pointing at
                //TODO make it so it only raycasts at the ground
                //TODO ignore 0,0,0 case if you click on the sky
                Ray ray = cam.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                Physics.Raycast(ray, out hit);
                targetPos = hit.point - transform.position;
                //Maybe don't make it try to go up or down as this will probably make the physics weird
            }
            else
            {
                targetPos = gamePadPointing;
            }
            targetPos = Vector3.ClampMagnitude(targetPos, 5);
            targetPos.y = 0.5f;
            Debug.Log(targetPos);
            rigid.AddForce(targetPos * moveSpeed * Time.deltaTime);

            indicator.SetActive(true);
            indicator.transform.position = targetPos + transform.position;

            if (rigid.velocity.magnitude > 0)
            {
                Vector3 pointing = Vector3.Lerp(rigid.rotation.eulerAngles, rigid.velocity.normalized, 2 * Time.deltaTime);
                pointing.y = 0;
                transform.forward = pointing;
            }
        }
        else
        {
            indicator.SetActive(false);
        }
    }
}
