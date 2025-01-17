using UnityEngine;

public class Mushroom : MonoBehaviour
{
    [SerializeField] private float _rotationSpeed;
    

    private void FixedUpdate()
    {
        transform.Rotate(Vector3.up  * _rotationSpeed * Time.fixedDeltaTime);
    }

}
