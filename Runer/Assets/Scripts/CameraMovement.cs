using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    private Vector3 _posEnd, _posSmooth;
    

    private void Update()
    {
        _posEnd = new Vector3(_player.transform.position.x, transform.position.y, transform.position.z);        
        _posSmooth = Vector3.Lerp(transform.position, _posEnd, Time.deltaTime * 5f);
        transform.position = _posSmooth; 
    }

    


}
