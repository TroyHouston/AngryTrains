using UnityEngine;
using System.Collections;

// Container object for a Ritual group.
public class Ritual {
    
    public int ritualSize {get; set;}
    public Vector3 ritualCentre {get; set;}    
    public int ringCount {get; set;}
    public RitualGoer ritualGoerObject {get; set;}      
    public ArrayList currentRitualGoers {get; set;}      
    private float prevRingRadius {get; set;}
    
    public Ritual(int _ritualSize, Vector3 _ritualCentre, int _ringCount, RitualGoer _ritualGoerObject) {
        ritualSize = _ritualSize;
        ritualCentre = _ritualCentre;
        ringCount = _ringCount;
        ritualGoerObject = _ritualGoerObject;
        currentRitualGoers = new ArrayList();
        
        CreateRitualCircle();        
    }    
    
        
    // TODO FUNCTION Create a circle of RitualGoers based on a central position & ritual size:   (TODO Ring Count) 
    void CreateRitualCircle() {
        var unusedRitualGoerCount = ritualSize;
        for (var ri = 0; ri < ringCount; ri++) {
            var ringSize = unusedRitualGoerCount/3 * 2;
            if (ringSize >= 3) {
                // Another ring  . So break if it's not. ( and add rest to this ring.)
                CreateRing(ringSize, ri); 
                unusedRitualGoerCount -= ringSize;               
            }
            else {
                // Discard
                //CreateRing(unusedRitualGoerCount, 0);
                ritualSize -= unusedRitualGoerCount;
                ringCount = ri - 1;
                break;
            }           
        }                       
    }
    
    void CreateRing(int size, float currentRing) {
            var radius = (0.25f * size);
            if (currentRing > 0 && size > 10) {
                // get previous ring radius - some count
                radius = (radius + prevRingRadius) / 2;
            }
        
        for (var i = 0; i < size; i++) {

			// "i" now represents the progress around the circle from 0-1
			// we multiply by 1.0 to ensure we get a fraction as a result.
			var p = (i * 1.0f) / size;
			// get the angle for this step (in radians, not degrees)
			var angle = p * Mathf.PI * 2;
			// the X &amp; Y position for this angle are calculated using Sin &amp; Cos           
            
			var x = Mathf.Sin(angle) * (0.1f + radius); 
			var y = Mathf.Cos(angle) * (0.1f + radius);
			var pos = new Vector3(x, 0, y) + ritualCentre;

            var r = (RitualGoer)GameObject.Instantiate(ritualGoerObject, pos, Quaternion.identity);    
            
            if (i % 2 == 0)
                r.startUp = true;                                        
            
            currentRitualGoers.Add(r);  
            r.transform.LookAt(ritualCentre);  
            r.transform.Rotate(0,-90,0);
        }       
        prevRingRadius = radius;
    }     
}
