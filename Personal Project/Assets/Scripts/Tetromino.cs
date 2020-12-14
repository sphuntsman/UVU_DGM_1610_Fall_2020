using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tetromino : MonoBehaviour
{
    float fall = 0;
 
	void Start () {
		if (!isValidPosition()) {
			Destroy(gameObject);
		}
	}
 
	void Update() {
		if (Input.GetKeyDown(KeyCode.RightArrow)) {
			transform.position += new Vector3(1, 0, 0);
			if (isValidPosition())
				GridUpdate();
			else
				transform.position += new Vector3(-1, 0, 0);
		}
 
		else if (Input.GetKeyDown(KeyCode.LeftArrow)) {
			transform.position += new Vector3(-1, 0, 0);
			if (isValidPosition())
					GridUpdate();
			else
				transform.position += new Vector3(1, 0, 0);
		}
 
		else if (Input.GetKeyDown(KeyCode.UpArrow)) {
			transform.Rotate(0, 0, -90);
			if (isValidPosition())
				GridUpdate();
			else
				transform.Rotate(0, 0, 90);
		
		}
 
		else if (Input.GetKeyDown(KeyCode.DownArrow) ||
		         Time.time - fall <= 1) {
			transform.position += new Vector3(0, -1, 0);
			if (isValidPosition()) {
				GridUpdate();
			} else {
				transform.position += new Vector3(0, 1, 0);
				Playfield.DeleteRow();
				FindObjectOfType<Spawner>().SpawnNewBox();
				enabled = false;
			}
			fall = Time.time;
		}
	}
	
	bool isValidPosition() {        
		foreach (Transform child in transform) {
			Vector2 v = Playfield.round(child.position);
			if (!Playfield.isInsideGrid(v))
				return false;
			if (Playfield.grid[(int)v.x, (int)v.y] != null &&
			    Playfield.grid[(int)v.x, (int)v.y].parent != transform)
				return false;
		}
		return true;
	}
 
	void GridUpdate() {
		for (int y = 0; y < Playfield.gridHeight; ++y)
			for (int x = 0; x < Playfield.gridWeight; ++x)
				if (Playfield.grid[x, y] != null)
					if (Playfield.grid[x, y].parent == transform)
						Playfield.grid[x, y] = null;
		foreach (Transform child in transform) {
			Vector2 v = Playfield.round(child.position);
			Playfield.grid[(int)v.x, (int)v.y] = child;
		}        
	}

}
