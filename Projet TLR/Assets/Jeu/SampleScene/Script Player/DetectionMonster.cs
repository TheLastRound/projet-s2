using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectionMonster : MonoBehaviour
{
    public GameObject DesacLight;
    public AudioClip UwU;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Monster")
        {

            StartCoroutine(Wait());

        }

    }
    private IEnumerator Wait()
    {

        for (int i = 0; i < 2; i++)
        {

            DesacLight.GetComponent<Light>().enabled = !(DesacLight.GetComponent<Light>().enabled);
            
            yield return new WaitForSeconds(0.3f);

        }

    }
}
