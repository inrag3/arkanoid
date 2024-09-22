using TMPro;
using UnityEngine;


public class BlockScript : MonoBehaviour
{
    public GameObject textObject;
    TMP_Text textComponent; // TMP_Text textComponent;
    public int hitsToDestroy;
    public int points;
    PlayerScript playerScript;


    void Start()
    {
        if (textObject != null)
        {
            textComponent = textObject.GetComponent<TMP_Text>();
            textComponent.text = hitsToDestroy.ToString();
        }

        playerScript = GameObject.FindGameObjectWithTag("Player")
            .GetComponent<PlayerScript>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        hitsToDestroy--;
        if (hitsToDestroy == 0)
        {
            Destroy();
        }
        else if (textComponent != null)
            textComponent.text = hitsToDestroy.ToString();
    }

    protected virtual void Destroy()
    {
        Destroy(gameObject);
        playerScript.BlockDestroyed(points);
    }
}