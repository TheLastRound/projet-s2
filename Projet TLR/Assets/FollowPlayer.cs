using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject player;

    public Vector3 decalage;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("PlayerInGame");
        decalage = new Vector3(0, 1.5f, 0);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = player.transform.position + decalage;
    }
}
