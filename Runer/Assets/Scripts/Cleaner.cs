using UnityEngine;

public class Cleaner : MonoBehaviour
{
    

    private void OnTriggerEnter(Collider  coll)
    {
        if (coll.gameObject.tag == "Road")
        {
            Debug.Log("-1");
            Destroy(coll.gameObject);
        }
    }
}
