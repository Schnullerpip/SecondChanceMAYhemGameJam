using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxSpawner : MonoBehaviour
{

    //list that holds the template objects to spawn
    [SerializeField]
    private List<GameObject> objects;

    //time step after that the BoxSpawner spawns a new box
    [SerializeField]
    private float spawn_rythm;

    private float current_time = 0;
    private int current_item_idx = 0;

	// Use this for initialization
	void Start () {
        //initially deactivate all the objects in the list
	    foreach (GameObject go in objects)
	    {
	        var rigidBody = go.GetComponent<Rigidbody>();
	        if (rigidBody == null)
	        {
	            go.AddComponent<Rigidbody>();
	        }
	        go.SetActive(false);
	    }
	}
	
	// Update is called once per frame
	void Update ()
	{
	    current_time += Time.deltaTime;

	    if (current_time >= spawn_rythm)
	    {//spawn a box
            GameObject go = objects[current_item_idx];
            //go.transform.Translate(transform.position);

	        if (go)
	        {
	            go.transform.position = transform.position;
                go.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
	            go.SetActive(true);
	        }

	        if (++current_item_idx >= objects.Count)
	        {//repeat from start
	            current_item_idx = 0;
	        }
            current_time = 0;
	    }
	}
}
