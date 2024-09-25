using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(fileName = "GameData", menuName = "Game Data", order = 51)]
public class GameDataScript : ScriptableObject, IBonusProbabilities
{
    private readonly Dictionary<Type, float> _bonusProbabilities = new()
    {
        [typeof(SpeedBonus)] = 0.5f,
        [typeof(UpdateReserve)] = 0.1f,
        [typeof(UpdateReserveImmediately)] = 1f,
    };

    public int level = 1;
    public int balls = 6;
    public int points = 0;
    public bool resetOnStart;
    public bool music = true;
    public bool sound = true;
    public int pointsToBall = 0;
    public List<Tuple<string, int>> topResults = new();
    public string nickName = "";

    public IReadOnlyDictionary<Type, float> BonusProbabilities => _bonusProbabilities;

    public void Reset()
    {
        level = 1;
        balls = 6;
        points = 0;
        pointsToBall = 0;
    }

    public void SoftReset()
    {
        balls = 6;
    }

    public void Save()
    {
        PlayerPrefs.SetInt("level", level);
        PlayerPrefs.SetInt("balls", balls);
        PlayerPrefs.SetInt("points", points);
        PlayerPrefs.SetInt("pointsToBall", pointsToBall);
        PlayerPrefs.SetInt("music", music ? 1 : 0);
        PlayerPrefs.SetInt("sound", sound ? 1 : 0);
        PlayerPrefs.SetString("top",
            string.Join(',', topResults.Select(pair => pair.Item1 + '-' + pair.Item2).ToList()));
    }

    public void Load()
    {
        level = PlayerPrefs.GetInt("level", 1);
        balls = PlayerPrefs.GetInt("balls", 6);
        points = PlayerPrefs.GetInt("points", 0);
        pointsToBall = PlayerPrefs.GetInt("pointsToBall", 0);
        music = PlayerPrefs.GetInt("music", 1) == 1;
        sound = PlayerPrefs.GetInt("sound", 1) == 1;
        topResults = PlayerPrefs.GetString("top").Split(',').Where(s => s.Length > 0).Select(pair =>
        {
            var d = pair.Split('-');
            return new Tuple<string, int>(d[0], int.Parse(d[1]));
        }).ToList();
    }
}

public interface IBonusProbabilities
{
    public IReadOnlyDictionary<Type, float> BonusProbabilities { get; }
}