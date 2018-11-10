using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float orbitScaleSpeed;

    public enum CameraMode { Free, Target };
    [SerializeField] public CameraMode cameraMode;

    public void SetCameraMode(CameraMode mode)
    {
        cameraMode = mode;
    }
}
