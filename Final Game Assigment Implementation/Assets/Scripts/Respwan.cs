using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respwan : MonoBehaviour
{
    // public GameObject player;

    // public Transform respawnPoint;

    // // void FixedUpdate() {
    // //     transform.position= new Vector3();
    // // }

    // void OnCollisionEnter(Collision col) {
    //     if(col.gameObject.CompareTag("Player"))
    //     {
    //         Scene currentScene= SceneManager.GetActiveScene();
    //         SceneManager.LoadScene(currentScene.name);

    //         player.transform.position =respawnPoint.transform.position;
    //     }   
    // }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag =="Player"){
            other.gameObject.GetComponent<CharacterMovement>().RespawnPlayer();
        }
    }
}
