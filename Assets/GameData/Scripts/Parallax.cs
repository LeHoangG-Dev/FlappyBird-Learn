using UnityEngine;

public class Parallax : MonoBehaviour
{
    public float groundSpeed = 1f;
    private MeshRenderer meshRenderer;


    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }
    private void Update()
    {
        meshRenderer.material.mainTextureOffset += new Vector2(groundSpeed*Time.deltaTime,0);
    }
    


}
