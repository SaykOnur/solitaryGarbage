using UnityEngine;

public class CoinTrigger : MonoBehaviour
{
    public GameObject particleEffect;
    public int coinWorth;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "PlayerMesh")
        {
            Instantiate(particleEffect,transform.position,Quaternion.identity);
            other.GetComponent<PlayerCoinHandler>().AddCoin(coinWorth);
            Destroy(gameObject);
        }
    }
}
