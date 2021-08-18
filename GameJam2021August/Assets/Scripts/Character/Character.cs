using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    private Room _currentRoom;
    [SerializeField] private Rigidbody2D _rigidbody2D;
    [SerializeField] private float _speed;
    private List<IArtefact> _artefacts = new List<IArtefact>();
    [SerializeField] private Transform _weaponPosition;

    public Room CurrentRoom { get => _currentRoom; set => _currentRoom = value; }
    private Camera _camera;
    private void Start() {
             _camera = Camera.main;
    }

    private void Update() 
    {
        Vector2 _movement = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        _rigidbody2D.velocity = _movement * _speed;
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.TryGetComponent<IArtefact>(out IArtefact artefact))
        {
            if(_artefacts.Count < 4)
            {
             _artefacts.Add(artefact);
             Destroy(other.gameObject);
            GameObject item =  Instantiate(other.gameObject, transform.position, Quaternion.identity);
            item.transform.SetParent(_weaponPosition, false);

            }
        }
        if (other.TryGetComponent<IEnemy>(out IEnemy ienemy))
      {
          Debug.LogError("Co");;
          ienemy.TakeDamge(10);
      }
    }
    public void SetRoom(Room room)
    {
         _camera.transform.position = new Vector3( room.transform.position.x, room.transform.position.y, -10);
    }
}

