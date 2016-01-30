using UnityEngine;
using System.Collections;

public class RitualGenerator : MonoBehaviour {

    public int ritualCount = 2;
    public int mapSize = 60;
    public int borderSize = 5;
    public int maxPeopleSize = 12;
    public int maxRingCount = 1;
	public RitualGoer ritualGoerObject;
    private ArrayList currentRituals;  
    private int placableMapSize;

	// Use this for initialization
	void Start () {
       placableMapSize = mapSize - borderSize;
       currentRituals = new ArrayList();
	   GenerateRituals();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    
    // TODO Create function for generating set number of rituals
    void GenerateRituals() {
        for (var i = 0; i < ritualCount; i++) {
            // add to array
            currentRituals.Add(GenerateRitualWithRNGValues());
        }
    }

    // TODO FUNCTION Randomize ritual central position & size: (TODO Ring Count)
    // Centre not near edge.
    // Centre not same place as another centre.
    Ritual GenerateRitualWithRNGValues() {
		var size = Random.Range(1, maxPeopleSize);
		var ringCount = Random.Range(1, maxRingCount);
        
        bool goodPosition = false;
        Vector3 centre = new Vector3(0, 0, 0);
        
        while (!goodPosition) {
            centre = CreateRNGCentre();
            goodPosition = true;
            
            foreach(Ritual r in currentRituals) {
				var distance = Vector3.Distance(centre, r.ritualCentre);
                if (distance < 5) {
                    goodPosition = false;
                    break;
                }
            }           
        }        
               
		return new Ritual(size, centre, ringCount, ritualGoerObject);
    }    
    
    Vector3 CreateRNGCentre() {       
        var x = Random.Range(-placableMapSize/2, placableMapSize/2);
		var z = Random.Range(-placableMapSize/2, placableMapSize/2);
        return new Vector3(x, 0, z);
    } 
     

}
