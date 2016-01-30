using UnityEngine;
using System.Collections;

// Container object for a Ritual group.
public class Ritual {
    
    public int ritualSize {get; set;}
    public Vector3 ritualCentre {get; set;}    
    public int ringCount {get; set;}
    public RitualGoer ritualGoerObject {get; set;}    
    
    public Ritual(int _ritualSize, Vector3 _ritualCentre, int _ringCount, RitualGoer _ritualGoerObject) {
        ritualSize = _ritualSize;
        ritualCentre = _ritualCentre;
        ringCount = _ringCount;
        ritualGoerObject = _ritualGoerObject;
        
        CreateRitualCircle();        
    }
    
        
    // TODO FUNCTION Create a circle of RitualGoers based on a central position & ritual size:   (TODO Ring Count) 
    void CreateRitualCircle() {
        for (var i = 0; i < ritualSize; i++) {

			// "i" now represents the progress around the circle from 0-1
			// we multiply by 1.0 to ensure we get a fraction as a result.
			var p = (i * 1.0f) / ritualSize;
			// get the angle for this step (in radians, not degrees)
			var angle = p * Mathf.PI * 2;
			// the X &amp; Y position for this angle are calculated using Sin &amp; Cos
			var x = Mathf.Sin(angle) * (1 + (0.1f * ritualSize));
			var y = Mathf.Cos(angle) * (1 + (0.1f * ritualSize));
			var pos = new Vector3(x, 0, y) + ritualCentre;

            var r = (RitualGoer)GameObject.Instantiate(ritualGoerObject, pos, Quaternion.identity);    
            
            if (i % 2 == 0)
                r.startUp = false;                                        
        }        
    }     
}
