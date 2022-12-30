using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraMoving : MonoBehaviour
{
    public GameObject Player;

    [SerializeField]
    private float MinCamera = 2f;
    [SerializeField]
    private float MaxCamera = 30f;
    [SerializeField]
    private float CameraSpeed = 1f;
    // Start is called before the first frame update

    void OnGUI()
    {
        //GUI.Label(new Rect(0, 40, 1000, 100), Player.transform.position.ToString());
        //GUI.Label(new Rect(0, 50, 1000, 100), transform.position.ToString());
    }
   
    void Update()
    {
        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            Vector3 temp = new Vector3(0, CameraSpeed, 0);
            if (transform.position.y - CameraSpeed >= MinCamera)
                transform.position -= temp;
        }
        else if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            Vector3 temp = new Vector3(0, CameraSpeed, 0);
            if (transform.position.y + CameraSpeed <= MaxCamera)
                transform.position += temp;
        }
    }
    void LateUpdate()
    {
        if (Player != null)
        {
            float newXPosition = Player.transform.position.x;
            float newZPosition = Player.transform.position.z;

            transform.position = new Vector3(newXPosition, transform.position.y, newZPosition);
        }
    }
}




