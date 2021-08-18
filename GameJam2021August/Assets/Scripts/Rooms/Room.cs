using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Room : MonoBehaviour
{
 [SerializeField] private List< Door> _doors;
 [SerializeField] private bool _isMainRoom;
    private List< Room> _rooms = new List<Room>();
     private AddingRoom _addingRoom;
     [SerializeField] private GameObject[]  _enemies;
     [SerializeField] private Transform[] _spawnPosition;
     private List<GameObject> _currentEnemies= new List<GameObject>();
     [SerializeField] private UnityEvent _event;

    public bool IsMainRoom { get => _isMainRoom; set => _isMainRoom = value; }

    private void Start()
   {
      _addingRoom =FindObjectOfType<AddingRoom>();  
      _addingRoom.AddRoom(this);
      foreach (Transform currentPosition in _spawnPosition)
      {
          int random = Random.Range(0, _enemies.Length);
          GameObject enemy = Instantiate(_enemies[random], currentPosition.position, Quaternion.identity);
          _currentEnemies.Add(enemy);

      }
      
  }
  private void OnTriggerEnter2D(Collider2D other) {
 
      if (other.GetComponent<Character>() && !IsMainRoom)
      {
       StartCoroutine(Create());
      }
  }
  private IEnumerator Create()
  {
      yield return new WaitForSeconds(1);
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
     foreach (Door door in _doors)
      {
         door.ChangeCondition();
     }
  }
}
