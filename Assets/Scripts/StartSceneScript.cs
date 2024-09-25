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
        data.Load();
        for (int i = 0; i < data.topResults.Count; i++)
        {
            places[i].text = $"{data.topResults[i].Item1} : {data.topResults[i].Item2}";
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

        data.nickName = nick;

        SceneManager.LoadScene("MainScene");
    }
}