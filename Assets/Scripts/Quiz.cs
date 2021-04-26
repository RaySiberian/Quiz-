using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class Quiz : MonoBehaviour
{
    [SerializeField]
    private Text questionText; 
    [SerializeField]
    private Text answer1Text; 
    [SerializeField]
    private Text answer2Text;
    [SerializeField]
    private Text answer3Text; 
    [SerializeField]
    private Text answer4Text;

    [SerializeField]
    private Question quest1;
    [SerializeField]
    private Question quest2;
    [SerializeField]
    private Question quest3;
    [SerializeField]
    // Только у GO есть SetActive?
    private GameObject heart;
    
    private int lifeCount = 1;
    private Question _currentQuestion;
    private List<Question> _list= new List<Question>();
    
    private void Start()
    {
        FillList();
        ChangeQuest();
    }

    private void Update()
    {
        questionText.text = _currentQuestion.question;
        answer1Text.text = _currentQuestion.answer1;
        answer2Text.text = _currentQuestion.answer2;
        answer3Text.text = _currentQuestion.answer3;
        answer4Text.text = _currentQuestion.answer4;
    }

    public void OnButtonPressed(Text answerText)
    {
        if (answerText.text == _currentQuestion.correctAnswer)
        {
           ChangeQuest();
           
        }
        else
        {
            if (lifeCount == 0)
            {
                SceneManager.LoadScene(2);
            }
            heart.SetActive(false);
            lifeCount--;
        }
    }

    private void FillList()
    {
        _list.Add(quest1);
        _list.Add(quest2);
        _list.Add(quest3);
    }

    private void ChangeQuest()
    {
        int randNumber;
        if (_list.Count == 0)
        {
            SceneManager.LoadScene(2);
        }
        else
        {
            randNumber = Random.Range(0, _list.Count);
            _currentQuestion = _list[randNumber];
            _list.Remove(_list[randNumber]);
            ScoreStorage.score++;
        }
    }
}
