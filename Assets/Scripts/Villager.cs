﻿using UnityEngine;
using System.Collections;
using System;

public class Villager : RitualGoer {

    public float moveDistance = 1.0f;    
    private float height;
    private float startTime;
    public float animSpeed = 1.0f;
    private float animLength;
    private bool animStarted = false;
    public Vector3 startPosition;
    public Vector3 endPosition;
    private bool up;
    private bool objectExplode = false;
    private float explosionRadius = 5.0f;    //The starting radius of the explosion
    private float explosionPower = 5.0f;    //The power of the explosion
    
	// Use this for initialization
	void Start () {
        height = this.transform.localScale.y;  

		if (startUp) {
			transform.Translate(0,moveDistance/2,0);
		}
		else {
            transform.Translate(0,-moveDistance/2,0);
		}
			
	}
    
    void Update () {
        if(Input.GetKey(KeyCode.Space)) {
            Die(null);
        }
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        if (animStarted && up) {                 
            //We want percentage = 0.0 when Time.time = _timeStartedLerping
            //and percentage = 1.0 when Time.time = _timeStartedLerping + timeTakenDuringLerp
            //In other words, we want to know what percentage of "timeTakenDuringLerp" the value
            //"Time.time - _timeStartedLerping" is.
            float timeSinceStarted = Time.time - startTime;
            float percentageComplete = timeSinceStarted / animSpeed;
 
            //Perform the actual lerping.  Notice that the first two parameters will always be the same
            //throughout a single lerp-processs (ie. they won't change until we hit the space-bar again
            //to start another lerp)
            transform.position = Vector3.Lerp (startPosition, endPosition, percentageComplete);
 
            //When we've completed the lerp, we set _isLerping to false
            if(percentageComplete >= 1.0f)
            {
                up = !up;
				startTime = Time.time;
            } 
        }
        else if (animStarted && !up) {                 
            //We want percentage = 0.0 when Time.time = _timeStartedLerping
            //and percentage = 1.0 when Time.time = _timeStartedLerping + timeTakenDuringLerp
            //In other words, we want to know what percentage of "timeTakenDuringLerp" the value
            //"Time.time - _timeStartedLerping" is.
            float timeSinceStarted = Time.time - startTime;
            float percentageComplete = timeSinceStarted / animSpeed;
 
            //Perform the actual lerping.  Notice that the first two parameters will always be the same
            //throughout a single lerp-processs (ie. they won't change until we hit the space-bar again
            //to start another lerp)
            transform.position = Vector3.Lerp (endPosition, startPosition, percentageComplete);
 
            //When we've completed the lerp, we set _isLerping to false
            if(percentageComplete >= 1.0f)
            {
                up = !up;
				startTime = Time.time;
            } 
        }
        
        if (objectExplode == true) {
     
            // Apply an explosion force to all nearby rigidbodies
            if (explosionRadius < 18) {
                explosionRadius += 0.5f;
                 
                var explosionPos = transform.position;
                Collider[] colliders = Physics.OverlapSphere (explosionPos, explosionRadius);
 
                foreach (Collider hit in colliders) {
                    if (!hit)
                        continue;
 
                    if (hit.GetComponent<Rigidbody>()) {
                        hit.GetComponent<Rigidbody>().AddExplosionForce(explosionPower, explosionPos, explosionRadius, 3.0f);
                    }
                }
            }
            Destroy(gameObject);
        } 
	}
    
    public override void StartAnimation (float rngStartTime) {
		startTime = Time.time;               
		startPosition = transform.position;

		if (startUp) {
			startPosition = transform.position + Vector3.up * moveDistance/2;
			endPosition = transform.position + Vector3.down * moveDistance/2;
		}
		else {
			startPosition = transform.position + Vector3.down * moveDistance/2;
			endPosition = transform.position + Vector3.up * moveDistance/2;
		}

		animLength = Vector3.Distance(startPosition, endPosition); 
		up  = true;
		animStarted = true;
    }

    public override void Die(Collision collision)
    {    
        var remains = Instantiate(Resources.Load("BrokenVillager"), transform.position, transform.rotation) as GameObject;
        objectExplode = true;        
    }   
}
