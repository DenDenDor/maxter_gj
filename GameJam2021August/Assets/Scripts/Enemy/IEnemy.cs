using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEnemy 
{
bool IsActive{get;set;}
 void FindPlayer();
 float Health{get;set;}
 float Speed{get;set;}
 void Move();
 void Attack();
 void TakeDamge(int damage);
 void OnDead();
 void SpawnEnemy(Room room);
 void OnSetActiveEnemy();
}
