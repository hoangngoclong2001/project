using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Hud2 : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI scoreText1;
    [SerializeField] public AudioSource gamemover;
    [SerializeField]
    TextMeshProUGUI scoreText2;
    int score;
    const string ScorePrefix = "Score: ";
    // Start is called before the first frame update
    void Start()
    {
        gamemover.Play();
        scoreText1.text = scoreText2.text;
    }

    // Update is called once per frame
    void Update()
    {
        scoreText1.text = scoreText2.text;
    }
}
