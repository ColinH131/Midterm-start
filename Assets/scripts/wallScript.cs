using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wallScript : MonoBehaviour
{
   


    public AudioClip[] ToneClips;
	
    public float maxSpeed = 1.0f;

    private AudioSource _audioSource;

    void Start() {
        _audioSource = GetComponent<AudioSource>();
    }

    void OnCollisionEnter(Collision collision)
    {
        int toneIndex = GetCollisionStrength(collision);
		
        _audioSource.PlayOneShot(ToneClips[toneIndex]);

    }
	


    int GetCollisionStrength(Collision collision)
    {
        
        Vector3 normal = collision.contacts[0].normal;
        Vector3 bounceAmount = Vector3.Project(collision.relativeVelocity, normal);
        float speed = bounceAmount.magnitude;
		
        
        float clampedSpeed = Mathf.Clamp(speed / maxSpeed, 0.0f, 0.99f);

        
        return Mathf.FloorToInt(clampedSpeed * ToneClips.Length);
    }

	


}
