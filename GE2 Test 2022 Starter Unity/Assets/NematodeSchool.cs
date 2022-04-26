using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NematodeSchool : MonoBehaviour
{
    public GameObject prefab;

    [Range (1, 5000)]
    public int radius = 50;
    
    public int count = 10;
    public GameObject healthPrefab;
    public GameObject ammoPrefab;
    public int ammoLength = 50;
    public int healthLength = 50;

    IEnumerator CreateAmmo() {
        yield return new WaitForSeconds(1);

        while(ammoLength < 50) {
            
        }
    }

    IEnumerator CreateHealth() {
        yield return new WaitForSeconds(1);

        while(healthLength < 50) {
            // Instantiate(spherePrefab, transform.position, transform.rotation, gameObject.transform);
        }
    }

    // Start is called before the first frame update
    void Awake()
    {
        // Put your code here
        for(var i = 0; i < count; i++) {
            int x = Random.Range(-radius, radius);
            int y = Random.Range(-radius, radius);
            int z = Random.Range(-radius, radius);
            float rotationY = Random.Range(0, 1) == 0 ? -(Random.value) : Random.value;

            Instantiate(prefab, new Vector3(x, y, z), new Quaternion(transform.rotation.x, rotationY, transform.rotation.z, 1));
        }
    }

    void OnEnable() {
        StartCoroutine(CreateAmmo());
        StartCoroutine(CreateHealth());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
