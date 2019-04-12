using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flowerPlacer : MonoBehaviour {

    public GameObject flower;
    public GameObject[] instances;
    public GameObject sound;

    private float speed = 2.5f;
    private float amplitude = 4.5f;

    private int count = 10;
    private Mesh mesh;



	// Use this for initialization
    void Start () {
         mesh = GetComponent<MeshFilter>().sharedMesh;
        count = mesh.vertices.Length/20;
        instances = new GameObject[count];

        for (int i = 0; i < count; i ++)
        {
            Vector3 pos = mesh.vertices[i*20];
            instances[i] = Instantiate(flower);

            //float flowerRealtivePosition = flower.transform.position - transform.position;

            instances[i].transform.position = pos;
            instances[i].transform.rotation = GetDefaultRotation(i);
            float s = Random.Range(0.5f, 1.5f);
            instances[i].transform.localScale = new Vector3(s,s,s);
            Debug.Log(instances[i].transform.rotation);
        }


        sound.GetComponent<AudioSource>().Play();

	}
	
	// Update is called once per frame
	void Update () {

        //float[] spectrum = new float[256];

        //sound.GetSpectrumData(spectrum, 0, FFTWindow.Rectangular);

        for (int i = 0; i < instances.Length; i ++)
        {
            var rotation = GetDefaultRotation(i).eulerAngles;
            rotation.x += Mathf.Sin(Time.time * speed+i) * amplitude;
                                     
            instances[i].transform.eulerAngles = rotation;

        }       
	}

    private Quaternion GetDefaultRotation(int index) 
    {
        return Quaternion.LookRotation(mesh.normals[index]);
    }
}
