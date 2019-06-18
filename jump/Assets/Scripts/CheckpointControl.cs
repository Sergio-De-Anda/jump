using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointControl : MonoBehaviour
{
    public Sprite yellowFlag;
    public Sprite greenFlag;
    public bool checkpointReached;

    private SpriteRenderer checkpointSR;

    private Player player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        checkpointSR = GetComponent<SpriteRenderer>();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            checkpointSR.sprite = greenFlag;
            checkpointReached = true;
            player.respawnPoint = col.transform.position;
        }
    }
}
