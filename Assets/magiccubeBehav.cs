using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class magiccubeBehav : MonoBehaviour
{
    public string[] texture_path;

    // Start is called before the first frame update
    void Start()
    {
        texture_path = Directory.GetFiles("./Assets/textures2/", "*.png");
    }

    // Update is called once per frame
    void Update()
    {

    if (Input.GetMouseButtonDown(0))
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
        //Select stage    
        if (hit.transform.name == "magiccube")
        {
            Debug.Log("You hit the cube!");
            Debug.Log(texture_path.Length);
            
            
            int num = Random.Range(0,18);

            // load and apply the texture as in the example code
            byte[] bytes = File.ReadAllBytes(texture_path[num]);

            Texture2D texture = new Texture2D(100, 100);

            texture.filterMode = FilterMode.Trilinear;

            texture.LoadImage(bytes);  

            MeshRenderer meshRenderer = GetComponent<MeshRenderer>();

            meshRenderer.material.SetTexture("_MainTex", texture);

        }
    }
}


    }

}
