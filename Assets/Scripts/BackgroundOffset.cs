using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundOffset : MonoBehaviour
{
    private MeshRenderer mesh;
    private Material mat;
    private string textureName;
    // Start is called before the first frame update
    void Start()
    {
        mesh=this.GetComponent<MeshRenderer>();
        mat = mesh.material;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 offset = mat.mainTextureOffset;
        offset.x = transform.position.x/ transform.localScale.x;
        offset.y = transform.position.z / transform.localScale.y;
        mat.mainTextureOffset = offset;
 
        
    }
}
