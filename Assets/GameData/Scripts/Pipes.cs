using UnityEngine;

public class Pipes : MonoBehaviour
{

    private void FixedUpdate()
    {
        transform.position += new Vector3(-5f * Time.deltaTime,0,0);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("DestroyPipes"))
        {
            Destroy(gameObject);
        }
    }
}
