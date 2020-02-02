using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class astr : MonoBehaviour
{
    [SerializeField]
    float minScale = .8f;
    [SerializeField]
    float maxScale = 1.2f;
    [SerializeField]
    float rotationOffset = 100f;
    public List<GameObject> astro = new List<GameObject>();
    public List<GameObject> explodes = new List<GameObject>();
    public GameObject astropoint;
    private GameObject astroid; 
    private GameObject explode;

    Transform myT;
    Vector3 randomRotation;
    void Awake()
    {
        myT = transform;
    }

    // Start is called before the first frame update
    void Start()
    {
        astroid = astro[0];
        explode = explodes[0];
        //randome size
        Vector3 scale = Vector3.one;
        scale.x = Random.Range(minScale, maxScale);
        scale.y = Random.Range(minScale, maxScale);
        scale.z = Random.Range(minScale, maxScale);

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
       // if (other.tag == "astroid")
        //{
            Debug.Log("astrohuththa");
            SpawnAstro();
            SpawnExplode();
            Destroy(gameObject);
        //}
        //speed = 0;
        //Destroy(gameObject);
        //Debug.Log("hukanoooooooooooooooooooooooooooooooooooooooooooooo");

    }
    public void SpawnAstro()
    {
        GameObject astro;

        astro = Instantiate(astroid, astropoint.transform.position, Quaternion.identity);
        




    }
    public void SpawnExplode()
    {
        GameObject explodes;
        explodes = Instantiate(explode, astropoint.transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
 
}
