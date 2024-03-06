using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{
	[Header("Target")]
	Transform target;
	[Header("Controls")]
	public float speed = 5f;
	public float rotateSpeed = 200f;
	public float explosionForce;
	public float life;
	public float damage;
	public float replelStrength;
	public bool useDebug;
	[Header("Visuals")]
	public GameObject explosion;
	public GameObject particleParent;
	public GameObject propulsion;
	private Rigidbody2D rb;
	[HideInInspector]
	public Vector2 propPosition;
	private bool canTeleport;
	void Start()
	{
		rb = GetComponent<Rigidbody2D>();
		target = GameObject.FindGameObjectWithTag("Player").transform;
		if (target == null)
        {
			Destroy(gameObject);
        }
		GameObject prop = Instantiate(propulsion, transform);
		prop.transform.localPosition = propPosition;
	}
	public void SetPropPosition(Vector2 propPositionNew)
    {
		propPosition = propPositionNew;
    }
    void FixedUpdate()
	{
		float replusion = calculateAvgReplusion();
		float attraction = calculateTarget();
		float rotateAmount = attraction - replusion;
		if (Vector3.Distance(Vector3.zero, transform.position) > 100)
		{
			if (canTeleport)
            {
				transform.position = -transform.position;
				canTeleport = false;
			}
		}
        else
        {
			canTeleport = true;
        }
		rb.angularVelocity = -rotateAmount * rotateSpeed;
		rb.velocity = transform.up * speed;
		life -= Time.fixedDeltaTime;
		if (life <= 0)
		{
			GameObject explosionGO = Instantiate(explosion, particleParent.transform);
			explosionGO.transform.position = transform.position;
			DestroyImmediate(gameObject);
		}
	}
	void OnTriggerEnter2D(Collider2D collider)
	{
		if (!collider.CompareTag("Player"))
        {
			return;
        }
		GameObject explosionGO = Instantiate(explosion, particleParent.transform);
		explosionGO.transform.position = transform.position;
		target.GetComponent<Player>().TakeDamage(damage);
		Destroy(gameObject);
	}
	float calculateAvgReplusion()
    {
		GameObject[] ms = GameObject.FindGameObjectsWithTag("Missile");
		GameObject[] ms2 = GameObject.FindGameObjectsWithTag("Nuke");
		GameObject[] result = new GameObject[ms.Length + ms2.Length];
		for (int i = 0; i < ms.Length; i++)
		{
			result[i] = ms[i];
		}
		for (int i = 0; i < ms2.Length; i++)
		{
			result[ms.Length + i] = ms2[i];
		}
		float rotateAmount = 0;
		foreach (GameObject m in result)
		{
			Vector2 direction = (Vector2)m.transform.position - rb.position;
			direction.Normalize();
			float rotate = Vector3.Cross(direction, transform.up).z;
			rotateAmount += rotate;
		}
		rotateAmount /= result.Length;
		return rotateAmount * replelStrength;
	}
	float calculateTarget()
    {
		Vector2 direction = (Vector2)target.position - rb.position;
		direction.Normalize();
		float rotateAmount = Vector3.Cross(direction, transform.up).z;
		return rotateAmount;
	}
}
