using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class astroid : MonoBehaviour
{
    [SerializeField]float minScale = .8f;
    [SerializeField]float maxScale = 1.2f;
    [SerializeField]float rotationOffset = 100f;

    Transform myT;
    Vector3 randomRotation;
    void Awake()
    {
        myT = transform;
    }

    // Start is called before the first frame update
    void Start()
    {
        //randome size
        Vector3 scale = Vector3.one;
        scale.x = Random.Range(minScale, maxScale);
        scale.y = scale.x;
        scale.z = scale.y;

        myT.localScale = scale;

        //randome rotation

        randomRotation.y = Random.Range(-rotationOffset, maxScale);
       randomRotation.z = Random.Range(minScale, maxScale);
        randomRotation.x = Random.Range(minScale, maxScale);

        
    }

    // Update is called once per frame
    void Update()
    {
        myT.Rotate(randomRotation * Time.deltaTime);
    }
    private void OnTriggerEnter(Collider other)
    {

        //speed = 0;
        //Destroy(gameObject);
       // Debug.Log("hukanoooooooooooooooooo");

    }
 
}
