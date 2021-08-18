using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomPoint : MonoBehaviour
{
  [SerializeField] private Vector3 _additionalPosition;
   private Camera _camera;
   private void Start() {
       _camera = Camera.main;
   }
  private void OnTriggerEnter2D(Collider2D other)
   {
      if (other.GetComponent<Character>())
      {
          _camera.transform.position = _additionalPosition + _camera.transform.position;
          other.transform.position = _additionalPosition / 2 + other.transform.position ;
           
      }
  }
}
