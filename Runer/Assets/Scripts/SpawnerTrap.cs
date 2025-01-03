using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class SpawnerTrap : MonoBehaviour
{
   [SerializeField] private GameObject[] _traps;
   [SerializeField] private Transform[] _positionsTraps;
   [SerializeField] private float _spawnDelay;
    float nextSpawn;
   

   private void Update()
   {
      int _rand  = Random.Range(0 , _traps.Length);
      int _randPos = Random.Range(0 , _positionsTraps.Length);
      
      

      if (Time.time > nextSpawn)
      {
        nextSpawn = Time.time + _spawnDelay;
        GameObject traps = Instantiate(_traps[_rand] , _positionsTraps[_randPos].position , Quaternion.identity);
        Destroy(traps , 10);
      }
   }
}
