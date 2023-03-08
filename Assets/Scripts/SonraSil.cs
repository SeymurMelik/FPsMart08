using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SonraSil : MonoBehaviour
{
    public GameObject Explosion;

    public GameObject Cube;


    // Start is called before the first frame update
    void Start()
    {

        Explosion.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            transform.position = Vector3.Lerp(transform.position, Cube.transform.position, Time.deltaTime * 2);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Cube")
        {
            Explosion.SetActive(true);
            Destroy(gameObject);
        }
    }
}
