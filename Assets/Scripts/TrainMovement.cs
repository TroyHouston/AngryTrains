using UnityEngine;
using System.Collections;

public class TrainMovement : MonoBehaviour
{

    public float turnSpeed = 100.0f;  // Units per second
    public float moveSpeed = 100.0f;  // Units per second

    public GameObject indicator;
    public Camera cam;
    public Score score;
    //public GameObject backConnector;
    private Rigidbody rigid;

    private bool testBool = false;

    // Use this for initialization
    void Start()
    {
        rigid = GetComponent<Rigidbody>();
    }

    void OnTriggerEnter(Collision col)
    {
        if (col.gameObject.tag.Equals("RitualGoers"))
        {
            CollideWithVillager(col);
        }
    }

    public void CollideWithVillager(Collision col)
    {
        try {
            col.gameObject.GetComponent<RitualGoer>().Die(col.impulse);
        }catch(System.NotImplementedException e)
        {

        }
        GameObject.Destroy(col.gameObject);

        score.villagerHit();
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
         
            Vector3 pointing = Vector3.Lerp(rigid.rotation.eulerAngles,rigid.velocity.normalized,2*Time.deltaTime);
            pointing.y = 0;
            transform.forward = pointing;
        }
        else
        {
            indicator.SetActive(false);
        }
    }
}
