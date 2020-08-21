using UnityEngine;

public class Destroyer : MonoBehaviour
{
    [SerializeField]float destroyDelay = 1f;
    private void Awake()
    {
        Destroy(gameObject,destroyDelay);
    }
}
