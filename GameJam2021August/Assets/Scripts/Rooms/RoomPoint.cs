using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomPoint : MonoBehaviour
{
  [SerializeField] private Vector3 _additionalPosition;
   private void Start() {
  
   }
  private void OnTriggerEnter2D(Collider2D other)
   {
      if (other.TryGetComponent<Character>(out Character _character))
      {
          other.transform.position = _additionalPosition /2f + other.transform.position ;
         
           
      }
  }
}
