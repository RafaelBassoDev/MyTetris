using UnityEngine;

public class SpawnTetromino : MonoBehaviour
{

    public int nextTetrominoeIndex;

    public GameObject[] Tetrominoes;

    // Start is called before the first frame update
    void Start()
    {
        nextTetrominoeIndex = Random.Range(0, Tetrominoes.Length);
        SpawnTetrominoe();
    }

    public void SpawnTetrominoe() {
        Instantiate(Tetrominoes[nextTetrominoeIndex], transform.position, Quaternion.identity);
        nextTetrominoeIndex = Random.Range(0, Tetrominoes.Length);
    }

}
