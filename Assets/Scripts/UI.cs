using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI : MonoBehaviour
{
    [SerializeField] private GameObject menu;

    public void Play()
    {
        menu.SetActive(false);
    }
}
