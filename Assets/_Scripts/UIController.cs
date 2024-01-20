using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIController : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreTxt;
    [SerializeField] private GameObject player;
    [SerializeField] private int currentScore;
    // Start is called before the first frame update
    void Start()
    {

    }
    private void OnEnable()
    {
        Platform.OnScoreChanged += UpdateScore;
    }
    private void OnDisable()
    {
        Platform.OnScoreChanged -= UpdateScore;
    }
    void UpdateScore()
    {
        int score = Mathf.RoundToInt(player.transform.position.y);
        if (currentScore <= player.transform.position.y)
        {
            currentScore = score;
        }
        else
        {
            currentScore = Mathf.RoundToInt(player.transform.position.y);
        }
        scoreTxt.text = currentScore.ToString();
    }
}
