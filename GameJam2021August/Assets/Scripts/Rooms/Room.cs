using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Room : MonoBehaviour
{
    private bool _isOpened;
    private AddingRoom _addingRoom;
    [SerializeField] private bool _isEmptyRoom;
 [SerializeField] private bool _isMainRoom;
     [SerializeField] private GameObject[]  _enemies;
     [SerializeField] private Transform[] _spawnPosition;
     private List<GameObject> _currentEnemies= new List<GameObject>();
     [SerializeField] private UnityEvent _event;
     private Transform[] _points;
     [SerializeField] private Transform _point;
    public bool IsMainRoom { get => _isMainRoom; set => _isMainRoom = value; }

    private void Start()
   {
       _addingRoom = FindObjectOfType<AddingRoom>();
        _addingRoom.AddRoom(this);
    if (_isEmptyRoom)
    {
        ChangeDoors();
    }
      else
      {
        
          
      foreach (Transform currentPosition in _spawnPosition)
      {
          int random = Random.Range(0, _enemies.Length);
          GameObject enemy = Instantiate(_enemies[random], currentPosition.position, Quaternion.identity);
          _currentEnemies.Add(enemy);

      }
      }
      
  }
  private void OnTriggerEnter2D(Collider2D other) {
 
      if (other.TryGetComponent<Character>(out Character _character))
      {
        _character.SetRoom(this);
        if(!_isOpened)
        {
         Create();
         ChangeDoors();
        }
        
      }
    if (other.GetComponent<Room>())
    {
        Destroy(gameObject);
    }


  }
  
  private void Create()
  {
      foreach (GameObject enemy in _currentEnemies)
         {
           enemy.GetComponent<IEnemy>().SpawnEnemy(this);
           
         }
  }
  public void RemoveEnemy(GameObject _enemy)
  {
      _currentEnemies.Remove(_enemy);
      if (_currentEnemies.Count <= 0)
      {
          Debug.LogError("YEES");
          _event?.Invoke();
      }
  }
  public void ChangeDoors()
  {
      if(!_isEmptyRoom)
      {
          _points = _point.GetComponentsInChildren<Transform>();
      Collider2D[] _colliders = Physics2D.OverlapAreaAll(  _points[1].position,_points[2].position);
   foreach (var collider in _colliders)
   {
        
        if (collider.TryGetComponent<Door>(out Door _door))
     {
       _door.ChangeCondition();
        }
     _isOpened = true;
    }
   }
  }
}
