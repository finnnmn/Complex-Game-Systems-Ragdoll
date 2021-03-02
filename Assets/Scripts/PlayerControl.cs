using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerScore))]
public class PlayerControl : MonoBehaviour
{
    [SerializeField] MenuControl menuControl;
    [SerializeField] float moveSpeed = 5;
    [SerializeField] float minX, maxX;
    PlayerScore score;
    bool dropped;

    List<Rigidbody> rigidbodies = new List<Rigidbody>();

    private void Start()
    {
        rigidbodies = new List<Rigidbody>(GetComponentsInChildren<Rigidbody>());
        SetRigidBodiesActive(false);

        score = GetComponent<PlayerScore>();
        score.DisableScore();

    }

    private void Update()
    {
        if (!dropped)
        {
            Movement();
            if (Input.GetKeyDown(KeyCode.Space))
            {
                DropRagdoll();
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
               FindObjectOfType<SceneHandler>().LoadScene(0);
            }
        }

    }

    void Movement()
    {
        float xMove = 0;
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            if (transform.localPosition.x > minX)
                xMove--;
        }

        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            if (transform.localPosition.x < maxX)
                xMove++;
        }

        transform.position += Vector3.right * moveSpeed * xMove * Time.deltaTime;
    }

    void DropRagdoll()
    {
        dropped = true;
        SetRigidBodiesActive(true);
        score.EnableScore();
    }



    void SetRigidBodiesActive(bool _active)
    {
        foreach(Rigidbody rb in rigidbodies)
        {
            rb.isKinematic = !_active;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Win"))
            WinGame();
    }

    void WinGame()
    {
        score.DisableScore();
        score.HideScoreText();
        menuControl.WinGame(score.GetScore());
    }
}
