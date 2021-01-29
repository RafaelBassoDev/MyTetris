using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManageSprites : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < transform.childCount; i++) {
            transform.GetChild(i).gameObject.SetActive(false);
        }

    }

    public void SetSpriteActiveByIndex(int index, bool state) {

        transform.GetChild(index).gameObject.SetActive(state);

    }

}
