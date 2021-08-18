using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EvilFruit : MonoBehaviour, IEnemy

{
    private Room _currentRoom;
    private bool _isCoolDown;
    [SerializeField] private float _range;
       [SerializeField] private float _health = 1;
    [SerializeField] private float _speed = 5f;
   [SerializeField] private UnityEvent _action;
   [SerializeField] private Fruit _fruit;
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
       Fruit fruit =  Instantiate(_fruit, transform.position, Quaternion.identity);
       fruit.SetPlayer(_character);
       fruit.Speed = _speed / 2;
       StartCoroutine(Cooldown());
    }

    public void OnDead()
    {
         Destroy(gameObject);
    }

    public void Move()
    {
        if (Vector2.Distance(transform.position, _character.transform.position) > _range)
        {
            transform.position = Vector2.MoveTowards(transform.position,_character.transform.position, Speed * Time.deltaTime);
        }
        else
        {
            if(!_isCoolDown)
            {
            Attack();
            }
        }
        
    }
    private IEnumerator Cooldown()
    {
        _isCoolDown = true;
        yield return new WaitForSeconds(2);
        _isCoolDown = false;
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
        _currentRoom = room;
        IsActive = true;
    }
    public void OnSetActiveEnemy()
    {
        _currentRoom.RemoveEnemy(gameObject);
    }
}
