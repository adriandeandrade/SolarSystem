using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI : MonoBehaviour
{
    private GameManager gameManager;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    public void SetTargetCam()
    {
        gameManager.SetCameraMode(GameManager.CameraMode.Target);
    }

    public void SetFreeCam()
    {
        gameManager.SetCameraMode(GameManager.CameraMode.Free);
    }
}
