using UnityEngine;
using UnityEngine.Timeline;

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
   private Vector2 _startTouchPosition;
   private Vector2 _endTouchPosition;
   private Vector3 _target;
   private bool _isGrounded;
   private Animator _anim;

   private bool _isMoved = false;


private void Awake()
{   
    _target = transform.position;
    _rigidbody = GetComponent<Rigidbody>();
    _anim = GetComponent<Animator>();
}



private void FixedUpdate()
{   


   _isGrounded = Physics.OverlapSphere(_feetPos.position , _checkRadius , _layer).Length > 0;


    if (_isGrounded && Input.GetKeyDown(KeyCode.Space) || _isGrounded && Input.GetKeyDown(KeyCode.W) || _isGrounded && Input.GetKeyDown(KeyCode.UpArrow))
    {
        _rigidbody.velocity = Vector3.up * _jumpForce;
    }


    
    if (!_isMoved)
    {

        HandleMovement();
        Touch();

    }
    
    else if (_isMoved)
    {
        transform.position = Vector3.MoveTowards(transform.position , _target , _speed * Time.fixedDeltaTime);

        if (Vector3.Distance(transform.position , _target) < 0.01f)
        {
            _isMoved = false;
        }
    }
}


private void HandleMovement()
{
    if (Input.GetKey(KeyCode.A) && transform.position.x > _maxLeft || Input.GetKey(KeyCode.LeftArrow) && transform.position.x > _maxLeft)
    {
        
        _target = new Vector3(transform.position.x - _incriment , transform.position.y ,  transform.position.z);
        Debug.Log("Left");
        _isMoved = true;
        
    }

    else if (Input.GetKey(KeyCode.D) && transform.position.x < _maxRight || Input.GetKey(KeyCode.RightArrow) && transform.position.x < _maxRight)
    {
        
        _target = new Vector3(transform.position.x + _incriment , transform.position.y , transform.position.z);
        Debug.Log("Right");
        _isMoved = true;

    }
    else if (Input.GetKeyDown(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
    {
        _anim.SetTrigger("sit");
        Debug.Log("Down");
    }

}



private void Touch()
{
    if (Input.touchCount > 0)
    {
        Touch touch = Input.GetTouch(0);

        if (touch.phase == TouchPhase.Began)
        {
            _startTouchPosition = touch.position;
        }
        else if (touch.phase == TouchPhase.Ended)
        {
            _endTouchPosition = touch.position;

            Vector2 swipeDelta = _endTouchPosition - _startTouchPosition;

            
            if (swipeDelta.magnitude < 50) return;

           
            float angle = Vector2.Angle(Vector2.up, swipeDelta.normalized);

            if (Mathf.Abs(swipeDelta.x) > Mathf.Abs(swipeDelta.y))
            {
          
                if (swipeDelta.x < 0 && transform.position.x > _maxLeft)
                {
                    Left();
                }
                else if (swipeDelta.x > 0 && transform.position.x < _maxRight)
                {
                    Right();
                }
            }
            else
            {
               
                if (_isGrounded && swipeDelta.y > 0)
                {
                    Up();
                }

                else if (swipeDelta.y < 0)
                {
                    Down();
                }
            }
        }
    }



    
}


private void Left()
{
    _target = new Vector3(transform.position.x - _incriment , transform.position.y , transform.position.z);
    Debug.Log("Left");
    _isMoved = true;

}   

private void Right()
{
    _target = new Vector3(transform.position.x + _incriment , transform.position.y , transform.position.z);
    Debug.Log("Right");
    _isMoved = true;
    
}

private void Up()
{
    
    _rigidbody.velocity = Vector3.up * _jumpForce;
    Debug.Log("up");
    
}

private void Down()
{
    Debug.Log("Down");
    _anim.SetTrigger("sit");
}

}
