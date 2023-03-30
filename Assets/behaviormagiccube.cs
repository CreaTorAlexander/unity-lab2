using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class behaviormagiccube : MonoBehaviour
{
    private GameObject[] randomObjects = new GameObject[10];
    private string[] gameObjectNames = new string[10];
    private string comparisonWord;
    private GameObject toReplace;
    private int num;

    // Start is called before the first frame update
    void Start()
    {
        
    randomObjects[0] = GameObject.Find("alaptop");
    randomObjects[1] = GameObject.Find("Sphere");
    randomObjects[2] = GameObject.Find("alaptop");
    randomObjects[3] = GameObject.Find("alaptop");
    randomObjects[4] = GameObject.Find("Capsule");
    randomObjects[5] = GameObject.Find("Quad");
    randomObjects[6] = GameObject.Find("Cylinder");
    randomObjects[7] = GameObject.Find("alaptop");
    randomObjects[8] = GameObject.Find("alaptop");
    randomObjects[9] = GameObject.Find("projector");
    
    
    for(int i = 0; i < gameObjectNames.Length; i++)
    {
        gameObjectNames[i] = randomObjects[i].name;
    }
    
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
        int characterIndex = hit.transform.name.IndexOf('(');
        if (characterIndex >= 0)
        {
             comparisonWord = hit.transform.name.Substring(0, characterIndex);
        }
        
        Debug.Log(comparisonWord);
        // for(int i = 0; i < gameObjectNames.Length; i++)
        // {
        //     Debug.Log(gameObjectNames[i]);
        // }
        int index = Array.IndexOf(gameObjectNames, GameObject.Find(comparisonWord.Trim()));

        Debug.Log(index);

        if (index != -1 || hit.transform.name == "magiccube")
        {
            toReplace = GameObject.Find(hit.transform.name);
            num = UnityEngine.Random.Range(0,10);
            Debug.Log(num);
            Debug.Log(hit);
            
            Vector3 position = hit.transform.position;
            Quaternion rotation = hit.transform.rotation;

            Instantiate(randomObjects[num], position, rotation);
            Destroy(toReplace);
        }
        }
    }
}
}
