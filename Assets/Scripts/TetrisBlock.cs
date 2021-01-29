using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TetrisBlock : MonoBehaviour
{
    public Vector3 rotationPoint;
    private float previousTime;
    public float fallTime = 0.8f;
    public static int height = 20;
    public static int width = 10;
    private static Transform[,] grid = new Transform[width, height];

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.LeftArrow)) {

            transform.position += new Vector3(-1, 0, 0);
            if (!ValidMove()) {
                transform.position += new Vector3(1, 0, 0);
            }

        } else if (Input.GetKeyDown(KeyCode.RightArrow)) {

            transform.position += new Vector3(1, 0, 0);
            if (!ValidMove()) {
                transform.position += new Vector3(-1, 0, 0);
            }
        } else if (Input.GetKeyDown(KeyCode.UpArrow)) {

            transform.RotateAround(transform.TransformPoint(rotationPoint) , new Vector3(0,0,1), 90);
            if (!ValidMove()) {
                 transform.RotateAround(transform.TransformPoint(rotationPoint), new Vector3(0,0,1), -90);
            }
        } else if (Input.GetKeyDown(KeyCode.Space)) {
            int z = 0;
            do {

                transform.position += new Vector3(0, -1, 0);

                if (!ValidMove()) {
                    transform.position += new Vector3(0, 1, 0);
                }

                z++;
            } while (z < height);

        }

        if(Time.time - previousTime > (Input.GetKeyDown(KeyCode.DownArrow) ? fallTime/100 : fallTime)) {

            transform.position += new Vector3(0, -1, 0);
            if (!ValidMove()) {
                transform.position += new Vector3(0, 1, 0);

                if (!IsGameOver()) {

                    AddToGrid();
                    CheckForLines();

                    this.enabled = false;

                    FindObjectOfType<SpawnTetromino>().SpawnTetrominoe();

                } else {
                    Debug.Log("Game over!");
                    Destroy(gameObject);
                }

            }

            previousTime = Time.time;
        }

    }

    bool ValidMove() {

        foreach (Transform child in transform) {

            int roundedX = Mathf.RoundToInt(child.transform.position.x);
            int roundedY = Mathf.RoundToInt(child.transform.position.y);

            if (roundedX < 0 || roundedX >= width || roundedY < 0 || roundedY >= height) {
                return false;
            }

            if(grid[roundedX, roundedY] != null) {
                return false;
            }

        }

         return true;

    }

    void AddToGrid() {

          foreach (Transform child in transform) {

            int roundedX = Mathf.RoundToInt(child.transform.position.x);
            int roundedY = Mathf.RoundToInt(child.transform.position.y);

            grid[roundedX, roundedY] = child;
        }

    }

    void CheckForLines() {

        for (int i = height-1; i >= 0; i--) {

            if (HasLine(i)) {

                Score score = FindObjectOfType<Score>();

                score.IncreaseScore();
                score.scoreDif += score.defaultLineValue;

                DeleteLine(i);
                RowDown(i + 1);
                i++;
            }

        }

    }

    bool HasLine(int i) {

        for (int j = 0; j < width; j++) {
            if(grid[j, i] == null) {
                return false;
            }
        }

        return true;

    }

     void DeleteLine(int i) {

        for (int j = 0; j < width; j++) {
            Destroy(grid[j, i].gameObject);
            grid[j, i] = null;
        }
    }

    void RowDown(int i) {

        for (int y = i; y < height; y++) {
            for (int j = 0; j < width; j++) {
                if(grid[j, y] != null) {
                    grid[j, y - 1] = grid[j, y];
                    grid[j, y] = null;
                    grid[j, y - 1].transform.position -= new Vector3(0, 1, 0);
                }
            }
        }

    }

    bool IsGameOver() {

        for (int x = 0; x < width; x++) {
            if (grid[x, height - 2] != null) {
                return true;
            }
        }

        return false;

    }

}
