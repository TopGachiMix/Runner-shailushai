using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
  
 

    private void OnCollisionEnter(Collision  coll)
    {
        if (coll.gameObject.layer == LayerMask.NameToLayer("Trap"))
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            Debug.Log("Ай больно");

    }
}
