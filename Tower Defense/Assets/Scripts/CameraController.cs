using System;
using Cinemachine;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public static CinemachineImpulseSource ImpulseSource;
    public float panSpeed = 30f;
    public float scrollSpeed = 5f;
    public float minY = 10f;
    public float maxY = 80f;

    public float panBorderThickness = 10f;

    public bool canMove;

    private void Start()
    {
        ImpulseSource = FindObjectOfType<CinemachineImpulseSource>();
        canMove = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.GameIsOver)
        {
            enabled = false;
            return;
        }
        
        if (!canMove)
        {
            return;
        }

        if (Input.GetKey(KeyCode.Z) ||Input.GetKey(KeyCode.W) || Input.mousePosition.y >= Screen.height - panBorderThickness)
        {
            transform.Translate(Vector3.forward * panSpeed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey(KeyCode.S) || Input.mousePosition.y <= panBorderThickness)
        {
            transform.Translate(Vector3.back * panSpeed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey(KeyCode.D) || Input.mousePosition.x >= Screen.width - panBorderThickness)
        {
            transform.Translate(Vector3.right * panSpeed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey(KeyCode.Q) || Input.GetKey(KeyCode.A) || Input.mousePosition.x <= panBorderThickness)
        {
            transform.Translate(Vector3.left * panSpeed * Time.deltaTime, Space.World);
        }

        float scroll = Input.GetAxis("Mouse ScrollWheel");

        Vector3 pos = transform.position;
        pos.y -= scroll * 1000 * scrollSpeed * Time.deltaTime;
        pos.y = Mathf.Clamp(pos.y, minY, maxY);

        transform.position = pos;
    }
}
