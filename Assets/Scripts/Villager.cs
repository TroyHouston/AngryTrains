using UnityEngine;
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
	
	// Update is called once per frame
	void Update () {
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

    public override void Die(Vector3 impulse)
    {
        throw new NotImplementedException();
    }
}
