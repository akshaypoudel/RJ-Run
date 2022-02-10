using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundTile2 : MonoBehaviour
{
    GroundSpawner2 groundSpawner2;
    // public GameObject SpawnPoint;

    private void Start () {
        groundSpawner2 = GameObject.FindObjectOfType<GroundSpawner2>();
	}

    private void OnTriggerExit (Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            groundSpawner2.SpawnTile();
            Destroy(gameObject, 5);
        }
    }
}
