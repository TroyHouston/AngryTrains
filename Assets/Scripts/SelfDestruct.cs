using UnityEngine;
using System.Collections;

public class SelfDestruct : MonoBehaviour {

    public double waitTime = 4;

	// Use this for initialization
    void Start()
    {
        StartCoroutine(Destroy());        
    }
	
    IEnumerator Destroy() {
        yield return new WaitForSeconds(2);
        Destroy(gameObject);
    }
}
