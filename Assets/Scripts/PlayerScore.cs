using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScore : MonoBehaviour
{
    bool canGetScore;
    [SerializeField] Text scoreText;
    List<Joint> joints;

    float currentScore;

    [SerializeField] float minForceForScore;
    private void Start()
    {
        joints = new List<Joint>(GetComponentsInChildren<Joint>());
    }

    private void FixedUpdate()
    {
        if (canGetScore)
        {
            ForceToScore();
        }

    }

    void ForceToScore()
    {
            float forceBeingApplied = 0;
            foreach (Joint joint in joints)
            {
                forceBeingApplied += joint.currentForce.magnitude;
            }

            if (forceBeingApplied > minForceForScore)
            {
                currentScore += forceBeingApplied;
                scoreText.text = "Score: " + Mathf.RoundToInt(currentScore).ToString();
            }

    }

    public void EnableScore() => canGetScore = true;
    public void DisableScore() => canGetScore = false;

    public int GetScore() => (int)currentScore;

    public void HideScoreText()
    {
        scoreText.gameObject.SetActive(false);
    }
}
