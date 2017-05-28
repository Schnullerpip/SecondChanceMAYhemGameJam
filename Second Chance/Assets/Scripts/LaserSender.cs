using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserSender : MonoBehaviour {

	private LineRenderer lineRenderer;
	private List<Vector3> vertices;

	public ParticleSystem particles;

	public float pulseSpeed = 20f;
	public float deltaPulse = 0.05f;

	private float startWidth;
	public bool isOn = true;

	void Start () 
	{
		lineRenderer = GetComponent<LineRenderer>();
		vertices = new List<Vector3>();
		startWidth = lineRenderer.widthMultiplier;
	}

	public void Activate(bool isOn)
	{
		this.isOn = isOn;

		lineRenderer.enabled = isOn;
		particles.gameObject.SetActive(isOn);
	}

	void Update () 
	{
		if(!isOn)
			return;
		
		RaycastHit hit;
		Vector3 direction = transform.forward;
		Vector3 position = transform.position;

		while(Physics.Raycast(position,direction,out hit, 1000, -1, QueryTriggerInteraction.Ignore))
		{
			vertices.Add(hit.point);

			//Mirrors and other grabable stuff
			if(hit.collider.CompareTag("Grabable"))
			{
				LaserMirror mirror = hit.collider.GetComponentInChildren<LaserMirror>(false);
				if(mirror == null || !mirror.isReflective)
				{
					PlaceParticles(direction,hit);
					break;
				}
			}

			//walls, player, laserreceiver and everything else
			else
			{
				PlaceParticles(direction,hit);

				if(hit.collider.CompareTag("LaserReceiver"))
				{
					hit.collider.GetComponent<Sender>().TriggerReceivers();
				}
				else if(hit.collider.CompareTag("Player"))
				{
					hit.collider.GetComponent<Character>().Die();
				}

				break;

			}

			position = hit.point;
			direction = Vector3.Reflect(direction, hit.normal);

			if(vertices.Count > 202)
			{
				break;
			}
		}

		lineRenderer.widthMultiplier = startWidth + Mathf.Sin(Time.time * pulseSpeed) * 0.5f * deltaPulse;

		if(vertices.Count == 0)
		{
			RaycastHit fakeHit = new RaycastHit();
			fakeHit.normal = -direction;
			fakeHit.point = position+direction*500;
			vertices.Add(fakeHit.point);
			PlaceParticles(direction, fakeHit);
		}

		vertices.Insert(0,transform.position);
		lineRenderer.enabled = true;

		lineRenderer.positionCount = vertices.Count;
		lineRenderer.SetPositions(vertices.ToArray());

		vertices.Clear();
	}

	void PlaceParticles(Vector3 direction, RaycastHit hit)
	{
		particles.transform.position = hit.point;
		particles.transform.rotation = Quaternion.LookRotation(Vector3.Reflect(direction, hit.normal));
	}
}
