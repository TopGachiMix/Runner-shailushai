using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
   [SerializeField] private float _speed;




   private void FixedUpdate()
   {
      transform.Translate(Vector3.back * _speed * Time.fixedDeltaTime);

      Destroy(gameObject  , 8f);
   }
}
