using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerPoint : MonoBehaviour
{
    [SerializeField] private Room[] _rooms;
    private bool _isSpawned;
    private void Start()     
    {
        StartCoroutine(CreateRoom());
    }
    private IEnumerator CreateRoom()
    {
         int random = Random.Range(0,_rooms.Length);
        yield return new WaitForSeconds(0.3f);
       
        Instantiate(_rooms[random], transform.position, Quaternion.identity);
         _isSpawned = true;
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if ((other.TryGetComponent<SpawnerPoint>(out SpawnerPoint _spawnerPoint) && _spawnerPoint._isSpawned) || (other.TryGetComponent<Room>(out Room room) && room.IsMainRoom))
        {
            Destroy(gameObject);
        }
    }
}
