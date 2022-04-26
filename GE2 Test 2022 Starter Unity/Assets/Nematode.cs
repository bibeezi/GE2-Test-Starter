using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nematode : MonoBehaviour
{
    public int length = 5;
    public GameObject spherePrefab;
    // public float distance = 1;

    public Material material;

    void Awake()
    {        
        // Put your code here!
        length = Random.Range(2, 20);

        for(var i = 0; i < length; i++) {
            GameObject segment = Instantiate(spherePrefab, transform.position, transform.rotation, gameObject.transform);
            segment.transform.position = transform.position - (transform.forward * i);
        }


    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
