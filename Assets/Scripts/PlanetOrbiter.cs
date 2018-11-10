using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetOrbiter : MonoBehaviour
{
    [SerializeField] private Transform targetToRotateAround;
    [SerializeField] private float orbitSpeed;

    [SerializeField] private GameManager gameManager;

    ParticleSystem par;

    private float rand;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        rand = Random.Range(0f, 360f);
    }

    private void Update()
    {
        transform.RotateAround(targetToRotateAround.position, Vector3.up, orbitSpeed * gameManager.orbitScaleSpeed * Time.deltaTime);
    }
}
