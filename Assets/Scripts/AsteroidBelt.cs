using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidBelt : MonoBehaviour
{
    [SerializeField] private ParticleSystem ps;

    [SerializeField] private float baseSpeed;

    private GameManager gameManager;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        ps = GetComponent<ParticleSystem>();
    }

    private void Update()
    {
        ParticleSystem.VelocityOverLifetimeModule orbitVel = ps.velocityOverLifetime;
        orbitVel.orbitalZ = baseSpeed * gameManager.orbitScaleSpeed;
    }
}
