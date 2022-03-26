using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FollowPlayer : MonoBehaviour
{
    public NavMeshAgent Monstre;
    public Transform Joueur;
    void Start()
    {
        Monstre = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        Monstre.SetDestination(Joueur.position);
    }
}
