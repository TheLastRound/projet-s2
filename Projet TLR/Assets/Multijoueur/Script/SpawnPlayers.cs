using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using Photon.Pun;
using Random = UnityEngine.Random;

namespace UnityStandardAssets.Characters.ThirdPerson
{
    public class SpawnPlayers : MonoBehaviour
    {
        public GameObject playerPrefab;

        public float minX;
        public float maxX;
        public float minY;
        public float maxY;
        public float minZ;
        public float maxZ;
        private void Start()
        {
            Vector3 randomPoisition = new Vector3(Random.Range(minX, maxX), Random.Range(minY, maxY), Random.Range(minZ, maxZ));
            GameObject MyPlayer = PhotonNetwork.Instantiate(playerPrefab.name, randomPoisition, Quaternion.identity);
            GameObject camera = GameObject.FindWithTag("MainCamera");
            if (camera != null)
            {
                CameraController followScript = camera.GetComponent("CameraController") as CameraController;
                if (followScript != null)
                {
                    followScript.target = MyPlayer;
                }
            }

        }
    }
}

