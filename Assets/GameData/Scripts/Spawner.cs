using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject spawnLocation;
    private void OnEnable()
    {
        InvokeRepeating(nameof(Spawn),1.5f,1.5f);
    }

    private void Spawn()
    {
        float randomValue = Random.Range(-2f,2f);
        Vector3 randomY = new Vector3(transform.position.x,randomValue,transform.position.z);
        Instantiate(spawnLocation,randomY,Quaternion.identity);
    }
    private void OnDisable()
    {
        CancelInvoke(nameof(Spawn));
    }
}
