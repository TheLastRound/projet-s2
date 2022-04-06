using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


namespace UnityStandardAssets.Characters.ThirdPerson
{
    public class JumpScare : MonoBehaviour
    {
        public AudioSource Scream;
        public GameObject PlayerCam;
        public GameObject JumpCam;

        void OnCollisionEnter(Collision collision) // Presque finis
        {
            if (collision.gameObject.tag == "Monster")
            {
                Scream.Play();
                PlayerCam.SetActive(false);
                JumpCam.SetActive(true);
                StartCoroutine(EndJump());
            }
        }

        IEnumerator EndJump()
        {
            yield return new WaitForSeconds(5.0f);
            PlayerCam.SetActive(true);
            JumpCam.SetActive(false);
        }
    }
}
