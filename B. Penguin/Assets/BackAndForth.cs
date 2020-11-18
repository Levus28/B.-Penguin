using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackAndForth : MonoBehaviour
{
	public bool randomizeAmplitude;    
    public Vector3 amplitude = Vector3.zero;
	public Vector3 minAmplitude, _maxAmplitude;    
	public bool _randomizeFrequency;    
	public Vector3 frequency = Vector3.one;    
	public Vector3 minFrequency, _maxFrequency;

    public bool randomizeOffset;
    public float offsetX = 0f;
    public float offsetY = 0f;
    public float offsetZ = 0f;
	
	float localTime;
	Vector3 origin;
    
    void Start()
    {
		origin = transform.localPosition;

		if (randomizeOffset)
		{
			offsetX = Random.value;
			offsetY = Random.value;
			offsetZ = Random.value;
		}

		if (randomizeAmplitude)
		{
			amplitude = new Vector3(
				Random.Range(minAmplitude.x, _maxAmplitude.x),
				Random.Range(minAmplitude.y, _maxAmplitude.y),
				Random.Range(minAmplitude.z, _maxAmplitude.z));
		}

		if (_randomizeFrequency)
		{
			frequency = new Vector3(
				Random.Range(minFrequency.x, _maxFrequency.x),
				Random.Range(minFrequency.y, _maxFrequency.y),
				Random.Range(minFrequency.z, _maxFrequency.z));
		}
    }

    void Update()
    {
		localTime += Time.deltaTime;
		Translate(localTime);        
    }

	void Translate(float time)
	{
		var translation = Vector3.Scale(
			amplitude, 
			new Vector3(
				Mathf.Sin((frequency.x * time) + (offsetX * Mathf.PI * 2)),
				Mathf.Sin((frequency.y * time) + (offsetY * Mathf.PI * 2)),
				Mathf.Sin((frequency.z * time) + (offsetZ * Mathf.PI * 2))));

		transform.localPosition = origin + translation;
	}    
}
