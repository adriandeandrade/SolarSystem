﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private enum CameraMode { Free, Target };
    [SerializeField] private CameraMode cameraMode;

    [SerializeField] private Transform target;
    [SerializeField] private Vector3 offset;

    [Header("Free Fly Camera Variables")]
    [SerializeField] private float flySpeed;
    [SerializeField] private float rotateSpeed;

    private float xRot;
    private float yRot;

    private bool trailRenderersOn = true;

    private TrailRenderer[] lrs = new TrailRenderer[8];

    private void Start()
    {
        lrs = FindObjectsOfType<TrailRenderer>();
    }

    private void Update()
    {
        if (cameraMode == CameraMode.Free)
        {
            FreeCamera();
        }

        if (cameraMode == CameraMode.Target)
        {
            TargetCamera();
        }

        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit = new RaycastHit();
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit))
            {
                //target = hit.collider.gameObject.transform;
                SetTarget(hit);
            }
        }
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
            //transform.parent =

            if (Input.GetMouseButton(1))
            {
                transform.LookAt(target);
                transform.RotateAround(target.position, Vector3.up, Input.GetAxis("Mouse X") * rotateSpeed * Time.deltaTime);
                transform.RotateAround(target.position, Vector3.forward, Input.GetAxis("Mouse Y") * rotateSpeed * Time.deltaTime);
            }
        }
    }

    private void SetTarget(RaycastHit hitInfo)
    {
        target = hitInfo.collider.gameObject.transform;
        transform.parent = target;

        transform.LookAt(target);
        transform.localPosition = Vector3.zero + offset;
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
