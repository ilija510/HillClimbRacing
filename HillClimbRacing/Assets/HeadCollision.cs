using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadCollision : MonoBehaviour
{
    [SerializeField] private GameObject gameOverScreen;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        gameOverScreen.SetActive(true);
    }
}
