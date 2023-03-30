using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;


public class Scenery : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        byte[] bytes = File.ReadAllBytes("./Assets/textures/00.jpeg");
        
        Texture2D texture = new Texture2D(100, 100);

        texture.filterMode = FilterMode.Trilinear;

        texture.LoadImage(bytes);  

        MeshRenderer meshRenderer = GetComponent<MeshRenderer>();
        meshRenderer.material.SetTexture("_MainTex", texture);


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
                if (hit.transform.name == "Cube")
                {
                    Debug.Log("You hit the cube!");
                }
            }
        }
    }
}
