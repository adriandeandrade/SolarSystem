using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetOrbiter : MonoBehaviour
{
    [SerializeField] private Transform targetToRotateAround;
    [SerializeField] private float orbitSpeed;

    [SerializeField] private GameManager gameManager;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    private void Update()
    {
        transform.RotateAround(targetToRotateAround.position, Vector3.up, orbitSpeed * gameManager.orbitScaleSpeed * Time.deltaTime);
    }
}
