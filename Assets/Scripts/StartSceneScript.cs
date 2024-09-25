using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartSceneScript : MonoBehaviour
{
    [SerializeField] private TMP_InputField input;
    [SerializeField] private GameDataScript data;
    [SerializeField] private List<TMP_Text> places;

    // Start is called before the first frame update
    void Start()
    {
        int i = 0;
        foreach (var k in data.topResults)
        {
            places[i].text = $"{k.Key} : {k.Value}";
            i++;
        }
    }

    public void ExitGame()
    {
        Application.Quit();
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }

    public void StartGame()
    {
        var nick = input.text;
        if (nick == "")
        {
            nick = "noname";
        }
        data.name = nick;

        SceneManager.LoadScene(1);
    }
}