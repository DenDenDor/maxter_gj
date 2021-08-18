using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour
{
    private Character _character;
    private float _speed;

    public float Speed { get => _speed; set => _speed = value; }

    private void Start() 
    {
        Destroy(gameObject, 3f);
    }
    private void Update() {
        transform.position = Vector2.MoveTowards(transform.position, _character.transform.position, Speed * Time.deltaTime);
    }
    public void SetPlayer(Character character) => _character = character;
}
