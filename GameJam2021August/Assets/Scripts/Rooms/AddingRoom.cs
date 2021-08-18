using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddingRoom : MonoBehaviour
{
    [SerializeField] private List< Room> _rooms;
    [SerializeField] private GameObject _bossRoom;
    private void Start() {
       StartCoroutine( Wait());
    }
    private IEnumerator Wait()
    {
        yield return new WaitForSeconds(5);
        
      Instantiate(_bossRoom, _rooms[_rooms.Count -1].transform.position, Quaternion.identity);
    }
    public void AddRoom(Room room)
    {
        _rooms.Add(room);
    }
}
