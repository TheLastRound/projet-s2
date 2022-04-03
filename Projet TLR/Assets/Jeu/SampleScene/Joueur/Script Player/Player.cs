using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;

namespace UnityStandardAssets.Characters.ThirdPerson
{
    public class Player : MonoBehaviour
    {
        // Deplacement du joueurs
        Rigidbody rb;
        private float horizontal;
        private float vertical;
        private bool isGrounded;
        private bool inputJump;
        public float walk = 2.5f;
        public float run = 3.5f;
        // Le joueur peut être soit vivant soit mort
        public enum State
        {
            ALIVE,
            DEAD
        }
        public State state2;

        // Variables ALIVE and DEAD
        public static bool CanBechase;
        public static bool CanBeHeal;
        public static bool CanTake;

        // Liste des joueurs dans la game (possibilité de la récupérer et de calculer sa longueur pour définir une parti finis)
        public List<GameObject> players;
        public static GameObject[] player;

        // Multijoueur Inventaire de soin
        public GameObject[] Heal;
        private int heal;
        private PhotonView view;
        
        //Rotation player
        private float x;
        private float y;
        private Vector3 rotateValue;
        
        void Start()
        {
            rb = GetComponent<Rigidbody>();

            state2 = Player.State.ALIVE;

            view = GetComponent<PhotonView>();

            StartCoroutine("FSM");

        }

        IEnumerator FSM() // Etat Joueur
        {
            while (true)
            {
                switch (state2)
                {
                    case State.ALIVE:
                        CanBechase = true;
                        CanBeHeal = false;
                        CanTake = true;
                        break;
                    case State.DEAD:
                        CanBechase = false;
                        CanBeHeal = true;
                        CanTake = false;
                        break;
                }
                yield return null;

            }
        }
        void Update()
        {
            player = GameObject.FindGameObjectsWithTag("PlayerInGame");
            players = new List<GameObject>();
            for (int i = 0; i < player.Length; i++)
            {
                players.Add(player[i]);
            }
            y = Input.GetAxis("Mouse X");
            rotateValue = new Vector3(0, -y, 0);
            transform.eulerAngles = transform.eulerAngles - rotateValue;
            
            if (player.Length == 1 || view.IsMine)
            {
                Move();
            }
        }

        private void Move()
        {
            horizontal = Input.GetAxis("Horizontal");
            vertical = Input.GetAxis("Vertical");
            transform.Translate(Vector3.forward * walk * vertical * Time.deltaTime);
            transform.Translate(Vector3.right * walk * horizontal * Time.deltaTime);
            if (Input.GetKey(KeyCode.LeftShift))
            {
                transform.Translate(Vector3.forward * run * vertical * Time.deltaTime);
                transform.Translate(Vector3.right * run * horizontal * Time.deltaTime);
            }

            if (!inputJump && isGrounded)
            {
                inputJump = Input.GetKey(KeyCode.Space);
            }
        }
        void FixedUpdate()
        
        {
            if (player.Length == 1)
            {
                if (inputJump && isGrounded)
                {
                    rb.AddForce(Vector3.up * 3.5f, ForceMode.Impulse);
                    inputJump = false;
                    isGrounded = false;
                }
            }
            else if (view.IsMine)  
            {
                if (inputJump && isGrounded)
                {
                    rb.AddForce(Vector3.up * 3.5f, ForceMode.Impulse);
                    inputJump = false;
                    isGrounded = false;
                }
            }
        }
        void OnCollisionEnter(Collision collision) // Presque finis
        {
            isGrounded = true;
            
            if(collision.gameObject.tag == "Monster" && state2 != Player.State.DEAD)
            {
                state2 = Player.State.DEAD;
                BasicAI.state = BasicAI.State.PATROL;
            }
        }
        void OnCollisionExit(Collision collision)
        {
            isGrounded = false;
        }
        
    }
}
