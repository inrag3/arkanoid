using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BlockScript : MonoBehaviour
{
    public GameObject textObject;
    TMP_Text textComponent; // TMP_Text textComponent;
    public int hitsToDestroy;
    public int points;

    void Start()
    {
        if (textObject != null)
        {
            textComponent = textObject.GetComponent<TMP_Text>();
            textComponent.text = hitsToDestroy.ToString();
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        {
            hitsToDestroy--;
            if (hitsToDestroy == 0)
                Destroy(gameObject);
            else if (textComponent != null)
                textComponent.text = hitsToDestroy.ToString();
        }
    }
}