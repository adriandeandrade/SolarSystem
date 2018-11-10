using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [Header("Target Camera Variables")]
    [SerializeField] private LayerMask planetLayer;
    [SerializeField] private Transform target;
    [SerializeField] private float zoomSensitivity;
    [SerializeField] private float minFov = 15;
    [SerializeField] private float maxFov = 90f;

    [Header("Free Fly Camera Variables")]
    [SerializeField] private float flySpeed;
    [SerializeField] private float rotateSpeed;

    private bool trailRenderersOn = true;

    private TrailRenderer[] lrs = new TrailRenderer[8];
    private GameManager gameManager;

    private void Start()
    {
        lrs = FindObjectsOfType<TrailRenderer>();
        gameManager = FindObjectOfType<GameManager>();
    }

    private void Update()
    {
        if (gameManager.cameraMode == GameManager.CameraMode.Free)
        {
            FreeCamera();
        }

        if (gameManager.cameraMode == GameManager.CameraMode.Target)
        {
            TargetCamera();

            if (Input.GetMouseButtonDown(0))
            {
                RaycastHit hit = new RaycastHit();
                if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, planetLayer))
                {
                    target = hit.collider.gameObject.transform;
                    transform.parent = target;
                    Vector3 offset = target.GetComponent<Planet>().camDistance;
                    SetPosition(offset);
                }
            }
        }
    }

    private void SetPosition(Vector3 camOffset)
    {
        transform.localPosition = camOffset;
    }
    
    private void FreeCamera()
    {
        TurnOnTRS();

        if (Input.GetKey(KeyCode.W))
            transform.Translate(Vector3.forward * flySpeed * Time.deltaTime);

        if (Input.GetKey(KeyCode.S))
            transform.Translate(Vector3.back * flySpeed * Time.deltaTime);

        if (Input.GetKey(KeyCode.A))
            transform.Translate(Vector3.left * flySpeed * Time.deltaTime);

        if (Input.GetKey(KeyCode.D))
            transform.Translate(Vector3.right * flySpeed * Time.deltaTime);

        if (Input.GetKey(KeyCode.Q))
            transform.Translate(Vector3.up * flySpeed * Time.deltaTime);

        if (Input.GetKey(KeyCode.Z))
            transform.Translate(Vector3.down * flySpeed * Time.deltaTime);
    }

    private void TargetCamera()
    {
        TurnOffTRS();
        if (target != null)
        {
            if (Input.GetMouseButton(1))
            {
                transform.RotateAround(target.position, Vector3.up, Input.GetAxis("Mouse X") * rotateSpeed * Time.deltaTime);
                transform.RotateAround(target.position, Vector3.forward, Input.GetAxis("Mouse Y") * rotateSpeed * Time.deltaTime);
            }

            float fov = Camera.main.fieldOfView;
            fov += Input.GetAxis("Mouse ScrollWheel") * zoomSensitivity * Time.deltaTime;
            fov = Mathf.Clamp(fov, minFov, maxFov);
            Camera.main.fieldOfView = fov;

            transform.LookAt(target);
        }
    }

    private void TurnOffTRS()
    {
        if (trailRenderersOn)
        {
            foreach (TrailRenderer lr in lrs)
            {
                lr.enabled = false;
            }
            trailRenderersOn = false;
        }
    }

    private void TurnOnTRS()
    {
        if (!trailRenderersOn)
        {
            foreach (TrailRenderer lr in lrs)
            {
                lr.enabled = true;
            }
            trailRenderersOn = true;
        }
    }
}
