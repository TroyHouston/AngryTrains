using UnityEngine;
using System.Collections;

public class TrainMovement : MonoBehaviour
{

    public float turnSpeed = 100.0f;  // Units per second
    public float moveSpeed = 100.0f;  // Units per second

    public GameObject indicator;
    public Camera cam;
    //public GameObject backConnector;
    private Rigidbody rigid;

    private bool testBool = false;

    // Use this for initialization
    void Start()
    {
        rigid = GetComponent<Rigidbody>();
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag.Equals("RitualGoers"))
        {
            //col.gameObject.GetComponent<RitualGoer>().die(col.impulse);

        }
    }

    void Update()
    {
        //Left click
        if (Input.GetMouseButton(0))
        {
            Vector3 curPos = transform.position;
            curPos.y = 0.5f;
            transform.position = curPos;

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
            rigid.AddForce(targetPos * moveSpeed * Time.deltaTime);

            indicator.SetActive(true);
            indicator.transform.position = targetPos + transform.position;
         
            Vector3 pointing = rigid.velocity.normalized;
            pointing.y = 0;
            transform.forward = pointing;
        }
        else
        {
            indicator.SetActive(false);
        }

        if (Input.GetMouseButton(1)&&testBool==false)
        {
            //addCarriage();
            testBool = true;
        }
    }

    /*public void addCarriage()
    {
        GameObject carriage = Instantiate(Resources.Load("Carriage")) as GameObject;
        CarriageFollow cf = carriage.GetComponent<CarriageFollow>();
        carriage.transform.rotation = transform.rotation;
        carriage.transform.position = transform.position + carriage.transform.forward*-6 + Vector3.up;
        cf.carriageFront = gameObject;
        cf.connectorFront = backConnector;
    }*/
}
