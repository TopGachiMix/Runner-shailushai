using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Road : MonoBehaviour
{
  [SerializeField] private float _speed;

  private void FixedUpdate()
  {
    transform.Translate(Vector3.back * _speed * Time.fixedDeltaTime);
  }

}
