using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour
{
    [SerializeField] private GameObject winScreen;
    public void OnTriggerEnter2D(Collider2D collision)
    {
        winScreen.SetActive(true);
    }
}
