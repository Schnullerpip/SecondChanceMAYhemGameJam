using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class PrefabSpawner : MonoBehaviour
{

    [SerializeField] private List<GameObject> prefabs;

    [SerializeField] private float spawn_rythm_in_seconds;

    private List<List<GameObject>> instances = new List<List<GameObject>>();

    [SerializeField] private int instances_per_pool = 5;

    private float current_time = 0;
    private int current_pool_idx = 0;
    private int current_item_idx = 0;

    private AudioSource m_AudioSource;

	// Use this for initialization
	void Start ()
	{

	    m_AudioSource = GetComponent<AudioSource>();

        //initially deactivate all the objects in the list
	    for(int i = 0; i < prefabs.Count; ++i)
	    {
            instances.Add(new List<GameObject>());

	        for (int o = 0; o < instances_per_pool; ++o)
	        {
	            instances[i].Add(Instantiate(prefabs[i]));
	            instances[i][o].SetActive(false);
	        }
	    }
	}
	
	// Update is called once per frame
	void Update () {
	    current_time += Time.deltaTime;
	    if (instances.Count == 0) return;

	    if (current_time >= spawn_rythm_in_seconds)
	    {//spawn a box
            List<GameObject> pool = instances[current_pool_idx];
            //go.transform.Translate(transform.position);

	        pool[current_item_idx].transform.rotation = transform.rotation;
            pool[current_item_idx].transform.position = transform.position;
            pool[current_item_idx].GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
            pool[current_item_idx].SetActive(true);
            m_AudioSource.Play();

	        if (++current_item_idx >= pool.Count)
	        {//repeat from start
	            current_item_idx = 0;
	        }
            if (++current_pool_idx >= instances.Count)
            {
                current_pool_idx = 0;
            }
            current_time = 0;
	    }
	}
}
