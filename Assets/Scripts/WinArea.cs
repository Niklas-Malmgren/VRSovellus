using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinArea : MonoBehaviour
{
    public Text youWon;

    private void OnTriggerEnter(Collider other)
    {
        youWon.text = "You Won!";
    }
}
