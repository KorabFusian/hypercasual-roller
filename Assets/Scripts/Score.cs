using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Transform player;
    public Text scoreText;
    void Update()
    {
        scoreText.text = Mathf.Floor(player.position.z).ToString();
    }
}
