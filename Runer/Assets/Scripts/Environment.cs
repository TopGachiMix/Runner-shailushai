using UnityEngine;

public class Enviroment : MonoBehaviour
{
   [SerializeField] private GameObject[] _decoration;
   [SerializeField] private float _spawnDelay;
   private float _speed;

   float nextTime;
           


   private void Update()
   {
        int _rand = Random.Range(0 , _decoration.Length);
        
        
        if (Time.time > nextTime)
        {   
            nextTime = Time.time + _spawnDelay;
            Instantiate(_decoration[_rand] , transform.position , Quaternion.identity);   
        }
   }
}
