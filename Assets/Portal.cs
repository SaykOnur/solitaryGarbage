using UnityEngine;

public class Portal : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "PlayerMesh") { Debug.Log("You are ready to pass the level"); }
    }

}
