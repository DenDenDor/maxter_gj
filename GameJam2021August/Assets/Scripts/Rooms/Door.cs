using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private Transform _rayPoint;
    [SerializeField] private Transform _startPoint;
 [SerializeField] private RoomPoint _roomPoint;
 [SerializeField] private BoxCollider2D _boxCollider2D;
   private bool _isOpen = true;
  [SerializeField] private SpriteRenderer _spriteRenderer;
   private Color[] _colors = {Color.black, Color.blue};

    public bool IsOpen { get => _isOpen; set => _isOpen = value; }
    private void Start() 
    {
        SetChanges();
    }


    public void ChangeCondition()
 {
     IsOpen =! IsOpen;
     int _action = IsOpen ? 1 : 0;
     _spriteRenderer.color = _colors[_action];

     SetChanges();
 }
 private void SetChanges()
 {
     _boxCollider2D.isTrigger = IsOpen;
     _roomPoint.enabled = IsOpen;
 }

}
