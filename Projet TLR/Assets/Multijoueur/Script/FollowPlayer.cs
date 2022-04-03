using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityStandardAssets.Characters.ThirdPerson
{
    public class FollowPlayer : MonoBehaviour
    {
        public GameObject player;
        public Vector3 decalage;

        // Start is called before the first frame update
        void Start()
        {
            player = Player.player[Player.player.Length - 1];
            Debug.Log(Player.player.Length);
            decalage = new Vector3(0, 1.5f, 0);
        }

        // Update is called once per frame
        void LateUpdate()
        {
            transform.position = player.transform.position + decalage;
        }
    }
}
