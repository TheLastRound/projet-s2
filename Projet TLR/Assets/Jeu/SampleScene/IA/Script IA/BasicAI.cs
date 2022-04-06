using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityStandardAssets.Characters.ThirdPerson
{
    public class BasicAI : MonoBehaviour
    {
        public UnityEngine.AI.NavMeshAgent agent;
        public ThirdPersonCharacter character;

        public enum State
        {
            PATROL,
            CHASE,
            DEAD
        }

        public static State state;
        private int CompteurObject;  // Compteur d'objet à détruire avant que le monstrer meurt

        // Variables pour Patrollling
        public GameObject[] waypoints;
        private int waypointInd;
        public float patrolSpeed = 0.5f;

        // Variables pour Chasing
        public float chaseSpeed = 1f;
        public static GameObject target;

        // Variable Multiplayer
        public static List<GameObject> playerNearMonster;
        public static int taille;

        void Start()
        {
            agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
            character = GetComponent<ThirdPersonCharacter>();

            agent.updatePosition = true;
            agent.updateRotation = false;

            waypoints = GameObject.FindGameObjectsWithTag("WayPoint");
            waypointInd = Random.Range(0, waypoints.Length);

            playerNearMonster = new List<GameObject>();

            state = BasicAI.State.PATROL;

            CompteurObject = 0;

            StartCoroutine("FSM");        
        }

        IEnumerator FSM()
        {
            while (true)
            {
                switch (state)
                {
                    case State.PATROL:
                        Patrol();
                        break;
                    case State.CHASE:
                        Chase();
                        break;
                    case State.DEAD:
                        Dead();
                        break;
                }
                yield return null;

            }

        }

        void Patrol()
        {
            agent.speed = patrolSpeed;
            if (Vector3.Distance(this.transform.position, waypoints[waypointInd].transform.position) >= 2)
            {
                agent.SetDestination(waypoints[waypointInd].transform.position);
                character.Move(agent.desiredVelocity, false, false);
            }
            else if (Vector3.Distance (this.transform.position, waypoints[waypointInd].transform.position) <= 2)
            {
                waypointInd = Random.Range(0, waypoints.Length);
            }
            else
            {
                character.Move(Vector3.zero, false, false);
            }
        }
        void Chase()
        {
            agent.speed = chaseSpeed;
            agent.SetDestination(target.transform.position);
            character.Move(agent.desiredVelocity, false, false);
        }

        void Dead()
        {
            Victory.Win();
        }

        void OnTriggerEnter(Collider  coll) //Ici pour le multijoueur Lorsqu'un joueur entre dans la zone
        {
            
            if (coll.tag == "PlayerInGame" &&  Player.CanBechase)
            {
                playerNearMonster.Add(coll.gameObject);
                taille = playerNearMonster.Count;
                target = playerNearMonster[Random.Range(0, taille)];
                state = BasicAI.State.CHASE;
            }
            
        }

        void OnTriggerExit(Collider coll)
        {
            if (coll.tag == "PlayerInGame")
            {
                playerNearMonster.Remove(coll.gameObject);

                if (playerNearMonster.Count == 0)
                {
                    state = BasicAI.State.PATROL;
                }
                else
                {
                    taille = playerNearMonster.Count;

                    if (target != coll.gameObject)
                    {
                        target = playerNearMonster[Random.Range(0, taille)];
                    }
                }

            }
        }
        
    }
}
