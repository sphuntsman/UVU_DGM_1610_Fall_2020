using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playfield : MonoBehaviour
{
    public static int gridWeight = 20;
	public static int gridHeight = 40;
	public static Transform[,] grid = new Transform[gridWeight, gridHeight];		
 
	public static Vector2 round(Vector2 v) {
		return new Vector2(Mathf.Round(v.x), Mathf.Round(v.y));
	}
	
	public static bool isInsideGrid(Vector2 pos) {
		return ((int)pos.x >= 0 && (int)pos.x < gridWeight && (int)pos.y >= 0);
	}
	
	public static void Delete(int y) {
		for (int x = 0; x < gridWeight; ++x) {
			Destroy(grid[x, y].gameObject);
			grid[x, y] = null;
		}
	}
 
	public static bool isFull(int y) {
		for (int x = 0; x < gridWeight; ++x)
			if (grid[x, y] == null)
				return false;
		return true;
	}
 
	public static void DeleteRow() {
		for (int y = 0; y < gridHeight; ++y) {
			if (isFull(y)) {
				Delete(y);
				RowDownAll(y+1);
				--y;
			}
		}
	}
	
	public static void RowDown(int y) {
		for (int x = 0; x < gridWeight; ++x) {
			if (grid[x, y] != null) {
				grid[x, y-1] = grid[x, y];
				grid[x, y] = null;
				grid[x, y-1].position += new Vector3(0, -1, 0);
			}
		}
	}
	
	public static void RowDownAll(int y) {
		for (int i = y; i < gridHeight; ++i) {
			RowDown(i);
        }
	}
}
