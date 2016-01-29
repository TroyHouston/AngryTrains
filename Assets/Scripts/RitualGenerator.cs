using UnityEngine;
using System.Collections;

public class RitualGenerator : MonoBehaviour {

    public int ritualCount = 2;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    
    // TODO Create function for generating set number of rituals
    void GenerateRituals() {
        for (int i = 0; i < ritualCount; i++) {
            GenerateRitualValues();
            CreateRitualCircle();
        }
    }
    
    // TODO FUNCTION Create a circle of RitualGoers based on a central position & ritual size:    
    void CreateRitualCircle() {
        // TODO Move this method to the Ritual class.
        // return array of RitualGoer objects to store into the Ritual object
    } 
    
    // TODO FUNCTION Randomize ritual central position & size: 
    // Centre not near edge.
    // Centre not same place as another centre.
    void GenerateRitualValues() {
        // TODO actually move this to the constructor of the Ritual object.
    }     
     
}
