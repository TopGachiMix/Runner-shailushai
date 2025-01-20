using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
  [SerializeField] private int _mushroomsCount;
  [SerializeField] private Text _textCount;
  [SerializeField] private GameObject _camera;
  [SerializeField] private  float _privateZ;
 
  private PlayerController _player;
  private bool _isTrain = false;

     void Start()
     {
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.FreezePositionZ;
        _player = GetComponent<PlayerController>();
     }


    private void Update()
    {   
        FreezeRotation();
        _textCount.text = $"{_mushroomsCount}";



        if (transform.position.y > 1.97575f && _isTrain == true)
        {   
            float _speedCamera = 3f;
            Vector3 targetPosition = new Vector3(_camera.transform.position.x, 9f, _camera.transform.position.z);
            _camera.transform.position = Vector3.MoveTowards(_camera.transform.position, targetPosition, _speedCamera * Time.deltaTime);
        }
    
        else if (transform.position.y <= 0.6370883f)
        {
            float _speedCamera = 4f;
            Vector3 targetPosition =  new Vector3(_camera.transform.position.x , 7f , _camera.transform.position.z);
            _camera.transform.position = Vector3.MoveTowards(_camera.transform.position , targetPosition , _speedCamera * Time.deltaTime);
        }

    }

    private void FreezeRotation()
    {
        Vector3 position = transform.position;
        position.z = _privateZ;
        transform.position = position;
    }

    private void OnCollisionEnter(Collision  coll)
    {
        if (coll.gameObject.layer == LayerMask.NameToLayer("Trap"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            Debug.Log("Ай больно");
        }
        
        else if (coll.gameObject.layer == LayerMask.NameToLayer("Road"))
        {
            _isTrain = false;
        }
    }

    private void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.tag == "Mushroom")
        {
            _mushroomsCount++;
            Destroy(coll.gameObject);
            Debug.Log("MUSHROOMS!!!!");
        }

        else if (coll.gameObject.tag == "train")
        {
            _isTrain = true;
            Debug.Log("TRAIN");
        }
    }

}
