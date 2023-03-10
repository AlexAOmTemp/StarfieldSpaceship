using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody ship_rigidbody;
    //public GameObject ChasedCamera;
    private Quaternion lookRotation;
    private Vector3 direction;
    private Vector3 mouse;
    private Ray castPoint;
    private Vector3 worldPosition;
    //private float timeCount = 0.0f;

    private Vector3 force;
    [SerializeField]
    private float ForwardPower = 100f;
    [SerializeField]
    private float RightPower = 100f;
    //[SerializeField]
    //private float RotatePower = 0.1f;
   
    private Camera cam;
    public GameObject FlameMoveForward;
    public GameObject FlameMoveBack1;
    public GameObject FlameMoveBack2;
    public GameObject FlameMoveLeft;
    public GameObject FlameMoveRight;


    //Quaternion m_MyQuaternion;
    //float m_Speed = 1.0f;
    Vector3 m_MousePosition;

    void Start()
    {
        cam = Camera.main;
        ship_rigidbody = GetComponent<Rigidbody>();
        //m_MyQuaternion = new Quaternion();
    }
    void OnGUI()
    {
        //GUI.Label(new Rect(0, 0, 1000, 100), "position: " + transform.position.ToString());
        GUI.Label(new Rect(0, 40, 1000, 100), "worldPosition " + worldPosition.ToString());
        GUI.Label(new Rect(0, 50, 1000, 100), "Look rotation: " + lookRotation.eulerAngles.ToString());
        GUI.Label(new Rect(0, 60, 1000, 100), "transform.rotation: " + transform.rotation.eulerAngles.ToString());
        GUI.Label(new Rect(0, 70, 1000, 100), "force vector: " + force.ToString());
        
        //
    }
    private void Update()
    {
        if (Input.GetAxis("Vertical") > 0)
            FlameMoveForward.SetActive(true);
        else
            FlameMoveForward.SetActive(false);
        if (Input.GetAxis("Vertical") < 0)
        {
            FlameMoveBack1.SetActive(true);
            FlameMoveBack2.SetActive(true);
        }
        else
        {
            FlameMoveBack1.SetActive(false);
            FlameMoveBack2.SetActive(false);
        }
        if (Input.GetAxis("Horizontal") < 0)
            FlameMoveLeft.SetActive(true);
        else
            FlameMoveLeft.SetActive(false);
        if (Input.GetAxis("Horizontal") > 0)
            FlameMoveRight.SetActive(true);
        else
            FlameMoveRight.SetActive(false);

    }
    private void FixedUpdate()
    {
        //ship_rigidbody.AddForce(transform.right* Input.GetAxis("Horizontal") * RightPower * Time.fixedDeltaTime);
        //ship_rigidbody.AddForce(transform.forward * Input.GetAxis("Vertical") * ForwardPower * Time.fixedDeltaTime);
        force = (transform.right * Input.GetAxis("Horizontal") * RightPower + transform.forward * Input.GetAxis("Vertical") * ForwardPower) * Time.fixedDeltaTime;
        ship_rigidbody.AddForce(force);
        //
        //mouse = Input.mousePosition;
        //castPoint = cam.ScreenPointToRay(mouse);
        //worldPosition = cam.ScreenToWorldPoint(new Vector3(mouse.x, mouse.y, cam.nearClipPlane));

        // direction = (worldPosition - transform.position).normalized;
        // direction.y = 0f;

        // lookRotation = Quaternion.LookRotation(direction);

        //transform.rotation = Quaternion.Slerp(transform.localRotation, lookRotation, Time.fixedDeltaTime*1);
        //timeCount += Time.fixedDeltaTime;
        //transform.rotation = lookRotation;
        //
        // Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        // transform.rotation = Quaternion.LookRotation(Vector3.forward, mousePos - transform.position);

        mouse = Input.mousePosition;
        //castPoint = cam.ScreenPointToRay(mouse);
        worldPosition = cam.ScreenToWorldPoint(new Vector3(mouse.x, mouse.y, cam.nearClipPlane));
        
        worldPosition.y = transform.position.y;

        direction = (worldPosition - transform.position).normalized;

        lookRotation = Quaternion.LookRotation(direction);

        //transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, 0.001f);
        //timeCount += Time.fixedDeltaTime;
        transform.rotation = lookRotation;


        //m_MousePosition = Input.mousePosition;
        //m_MousePosition.z = 10.0f;
        //m_MousePosition = Camera.main.ScreenToWorldPoint(m_MousePosition);
        //m_MyQuaternion.SetFromToRotation(transform.position, m_MousePosition);
        //transform.position = Vector3.Lerp(transform.position, m_MousePosition, m_Speed * Time.deltaTime);
        //transform.rotation = m_MyQuaternion * transform.rotation;
    }
}


//In this example your GameObject rotates towards the position of the mouse
