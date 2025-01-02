using UnityEngine;

public class PlayerController : MonoBehaviour
{
   [SerializeField] private float _speed;
   [SerializeField] private float _incriment;
   [SerializeField] private float _maxRight;
   [SerializeField] private float _maxLeft;
   [SerializeField] private float _jumpForce;
   [SerializeField] private Transform _feetPos;
   [SerializeField] private LayerMask _layer;
   [SerializeField] private float _checkRadius;

   private Rigidbody _rigidbody;
   private bool _isGrounded;
   private Vector2 _startTouchPosition;
   private Vector2 _endTouchPosition;


   private Vector3 _vector;


private void Start()
{
    _rigidbody = GetComponent<Rigidbody>();
}



private void FixedUpdate()
{   
   _isGrounded = Physics.OverlapSphere(_feetPos.position , _checkRadius , _layer).Length > 0;


    if (_isGrounded && Input.GetKeyDown(KeyCode.Space) || _isGrounded && Input.GetKeyDown(KeyCode.W) || _isGrounded && Input.GetKeyDown(KeyCode.UpArrow))
    {
        _rigidbody.velocity = Vector3.up * _jumpForce;
    }
    


    if (Input.GetKeyDown(KeyCode.A) && transform.position.x > _maxLeft || Input.GetKeyDown(KeyCode.LeftArrow) && transform.position.x > _maxLeft)
    {
        _vector = new Vector3(transform.position.x - _incriment , transform.position.y , transform.position.z);
        Debug.Log("Left");
        transform.position = _vector;
        
    }

    else if (Input.GetKeyDown(KeyCode.D) && transform.position.x < _maxRight || Input.GetKeyDown(KeyCode.RightArrow) && transform.position.x < _maxRight)
    {
        _vector = new Vector3(transform.position.x + _incriment , transform.position.y , transform.position.z);
        Debug.Log("Right");
        transform.position = _vector;

    }
    
    Touch();
}



private void Touch()
{
    if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
    {   
        
        _startTouchPosition = Input.GetTouch(0).position;

        
    }

    else if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
    {   

        _endTouchPosition = Input.GetTouch(0). position;

        if (_endTouchPosition.x < _startTouchPosition.x && transform.position.x > _maxLeft)
        {
            Left();
        }

        else if (_endTouchPosition.x > _startTouchPosition.x && transform.position.x < _maxRight)
        {
            Right();
        }

        else if (_isGrounded && _endTouchPosition.y > _startTouchPosition.y )
        {
            Up();
        }
    }

    
}

private void Left()
{
    _vector = new Vector3(transform.position.x - _incriment , transform.position.y , transform.position.z);
    transform.position = _vector;
    Debug.Log("Left");

}   

private void Right()
{
    _vector = new Vector3(transform.position.x + _incriment , transform.position.y , transform.position.z);
    transform.position = _vector;
    Debug.Log("Right");
    
}

private void Up()
{
    
    _rigidbody.velocity = Vector3.up * _jumpForce;
    Debug.Log("up");
    
}

private void Down()
{

}


}
