using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    [SerializeField] private float rotateSpeed;

    private GameManager gameManager;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    private void Update()
    {
        transform.Rotate(Vector3.up * rotateSpeed * Time.deltaTime * gameManager.orbitScaleSpeed);
    }
}
