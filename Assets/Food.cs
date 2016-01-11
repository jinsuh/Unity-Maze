using UnityEngine;
using System.Collections;

public class Food : MonoBehaviour {

    private MazeCell currentCell;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void SetLocation(MazeCell cell)
    {
        currentCell = cell;
        transform.localPosition = cell.transform.localPosition;
    }

    public MazeCell GetLocation()
    {
        return currentCell;
    }
}
