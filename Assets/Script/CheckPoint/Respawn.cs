using System;
using UnityEngine;
using System.Collections;
public class Respawn : MonoBehaviour
{
   [SerializeField] private Transform player;
   [SerializeField] private Transform respawnPoint;
   

   private void OnTriggerEnter(Collider other)
   {
      if (other.tag == "Player")
      {
         player.position = respawnPoint.transform.position;
         Physics.SyncTransforms();
      }
   }
}
                  