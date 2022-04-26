using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nematode : MonoBehaviour
{
    public int length = 5;
    public GameObject spherePrefab;
    NoiseWander noiseWanderVert;
    NoiseWander noiseWanderHoriz;
    public Gradient gradient;
    public Material material;

    void Awake()
    {        
        // Put your code here!
        length = Random.Range(2, 20);

        for(var i = 0; i < length; i++) {
            GameObject segment = Instantiate(spherePrefab, transform.position, transform.rotation, gameObject.transform);
            segment.transform.position = transform.position - (transform.forward * i);
            segment.GetComponent<Renderer>().material.SetColor("_Color", gradient.Evaluate((1.0f / length) * (i + 1.0f)));

            if(i <= length / 2) {
                float scale = (1.0f / (length / 2)) * ((float)i + 1.0f);
                segment.transform.localScale = new Vector3(scale, scale, segment.transform.localScale.z);
            }
            
            if(i > length / 2) {
                float scale = (1.0f / (length / 2)) * ((length + 1) - ((float)i + 1.0f));
                segment.transform.localScale = new Vector3(scale, scale, segment.transform.localScale.z);
            }
        }

        transform.GetChild(0).gameObject.AddComponent<Boid>();
        transform.GetChild(0).gameObject.AddComponent<Constrain>();
        transform.GetChild(0).gameObject.AddComponent<ObstacleAvoidance>();
        noiseWanderVert = transform.GetChild(0).gameObject.AddComponent<NoiseWander>();
        noiseWanderHoriz = transform.GetChild(0).gameObject.AddComponent<NoiseWander>();

        noiseWanderVert.axis = NoiseWander.Axis.Vertical;
        noiseWanderVert.weight = 5f;
        
        noiseWanderHoriz.axis = NoiseWander.Axis.Horizontal;
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
