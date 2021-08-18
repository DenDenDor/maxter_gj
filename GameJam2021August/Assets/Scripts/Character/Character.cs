using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody2D;
    [SerializeField] private float _speed;
    private List<IArtefact> _artefacts = new List<IArtefact>();
    [SerializeField] private Transform _weaponPosition;

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
             other.gameObject.transform.SetParent(_weaponPosition, false);

            }
        }
        if (other.TryGetComponent<IEnemy>(out IEnemy ienemy))
      {
          Debug.LogError("Co");;
          ienemy.TakeDamge(10);
      }
    }
}
