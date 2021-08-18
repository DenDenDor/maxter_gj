using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Flower : MonoBehaviour, IEnemy
{
private Room _currentRoom;
    [SerializeField] private float _health = 1;
    [SerializeField] private float _speed = 5f;
   [SerializeField] private UnityEvent _action;
    private Character _character;

    public float Health { get => _health; set => _health = value ;}
    public float Speed { get => _speed; set => _speed = value;}
    public bool IsActive {get; set;}

    private void Start() 
    {
        FindPlayer();
    }
    private void Update() 
    {
        if(IsActive)
        {
        Move();
        }
    }
    public void Attack()
    {
        
    }

    public void OnDead()
    {
         Destroy(gameObject);
    }

    public void Move()
    { 
        transform.position = Vector2.MoveTowards(transform.position,_character.transform.position, _speed * Time.deltaTime);
        
    }

    public void TakeDamge(int damage)
    {
        Health -= damage;
        if (Health <= 0)
        {
            _action?.Invoke();
        }
    }

    public void FindPlayer() =>  _character = FindObjectOfType<Character>();

       public void SpawnEnemy(Room room)
    {
         IsActive = true;
        _currentRoom = room;
    }
    public void OnSetActiveEnemy()
    {
        _currentRoom.RemoveEnemy(gameObject);
       
    }
}
