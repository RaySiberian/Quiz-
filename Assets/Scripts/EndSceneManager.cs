using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndSceneManager : MonoBehaviour
{
    [SerializeField] private Text score;

    void Start()
    {
        score.text = $"Колькасць вашых ачкоў {ScoreStorage.score}";
    }

}
