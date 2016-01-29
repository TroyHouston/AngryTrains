using UnityEngine;
using System.Collections;

public class RitualGoer : MonoBehaviour {
    
    public bool startUp = true;
    public float moveDistance = 1.0f;    
    private float height;
    
	// Use this for initialization
	void Start () {
        height = this.transform.localScale.y;
        if(!startUp)
            moveDistance = -moveDistance;
        
        if (startUp)
            this.transform.Translate(0, moveDistance, 0);   
        
	   InvokeRepeating("AnimateRitual", 0, 0.5f);
	}
	
	// Update is called once per frame
	void Update () {

	}
    
    void AnimateRitual () {
        moveDistance = -moveDistance;
                   
        this.transform.Translate(0,moveDistance,0);
    }
}
