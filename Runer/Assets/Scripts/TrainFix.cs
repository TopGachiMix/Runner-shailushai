using UnityEngine;

public class TrainFix : MonoBehaviour
{
   




   private void OnTriggerEnter(Collider coll)
   {
     if (coll.gameObject.tag == "ladder")
     {
        Destroy(coll.gameObject);
        Debug.Log("TRAINFIXED");
     }
   }
}
