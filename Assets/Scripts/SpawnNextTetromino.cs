using UnityEngine;
using UnityEditor;

public class SpawnNextTetromino : MonoBehaviour
{

    private SpawnTetromino st;
    public int lastTetrominoIndex;

    void Start()
    {
        st = FindObjectOfType<SpawnTetromino>();
        lastTetrominoIndex = st.nextTetrominoeIndex;

        FindObjectOfType<ManageSprites>().SetSpriteActiveByIndex(st.nextTetrominoeIndex, true);

    }

    void Update()
    {

        if(lastTetrominoIndex != st.nextTetrominoeIndex) {

            FindObjectOfType<ManageSprites>().SetSpriteActiveByIndex(lastTetrominoIndex, false);

            FindObjectOfType<ManageSprites>().SetSpriteActiveByIndex(st.nextTetrominoeIndex, true);

            lastTetrominoIndex = st.nextTetrominoeIndex;

        }

    }

}
