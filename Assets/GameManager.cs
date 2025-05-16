using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public enum Action
{
    Idle,
    Victory,
    Death
}

public class Question
{
    public string questionText;
    public string option1Text;
    public string option2Text;
    public string option3Text;
    public string option4Text;
    public bool correct1 = false;
    public bool correct2 = false;
    public bool correct3 = false;
    public bool correct4 = false;

    public Question(string question, string option1, string option2, string option3, string option4, int correct)
    {
        this.questionText = question;
        this.option1Text = option1;
        this.option2Text = option2;
        this.option3Text = option3;
        this.option4Text = option4;

        switch (correct)
        {
            case 1:
                correct1 = true;
                break;
            case 2:
                correct2 = true;
                break;
            case 3:
                correct3 = true;
                break;
            case 4:
                correct4 = true;
                break;
        }
    }
}

public class GameManager : MonoBehaviour
{
    public static GameManager Instance = null;
    [SerializeField] Button button1;
    [SerializeField] Button button2;
    [SerializeField] Button button3;
    [SerializeField] Button button4;
    [SerializeField] TextMeshProUGUI questionText;
    [SerializeField] TextMeshProUGUI pointsText;
    [SerializeField] TextMeshProUGUI option1Text;
    [SerializeField] TextMeshProUGUI option2Text;
    [SerializeField] TextMeshProUGUI option3Text;
    [SerializeField] TextMeshProUGUI option4Text;
    [SerializeField] Animator animator = null;
    [SerializeField] AudioSource audioSource = null;
    [SerializeField] AudioClip yeah = null;
    [SerializeField] AudioClip nope = null;
    Question currentQuestion = null;
    List<Question> questionList = new();
    
    int points = 0;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        button1.onClick.AddListener(Button1Click);
        button2.onClick.AddListener(Button2Click);
        button3.onClick.AddListener(Button3Click);
        button4.onClick.AddListener(Button4Click);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        questionList.Add(new("Choose C", "A", "B", "C", "D", 3));
        questionList.Add(new("What's 9 + 10?", "21", "19", "-9", "yomama", 2));
        questionList.Add(new("Ligma", "balls", "bells", "carrots", "deez", 1));

        AssignQuestion(questionList[0]);
    }

    // Update is called once per frame
    void Update()
    {
        pointsText.text = $"Points: {points}";
    }

    void AssignQuestion(Question question)
    {
        currentQuestion = question;
        questionText.text = question.questionText;
        option1Text.text = question.option1Text;
        option2Text.text = question.option2Text;
        option3Text.text = question.option3Text;
        option4Text.text = question.option4Text;
    }

    void AnswerQuestion(bool value)
    {
        if (value)
        {
            ++points;
            animator.SetInteger("action", 1);
            audioSource.GetComponent<AudioSource>().clip = yeah;
        }
        else
        {
            --points;
            animator.SetInteger("action", 2);
            audioSource.GetComponent<AudioSource>().clip = nope;
        }
        audioSource.Play();
        questionList.RemoveAt(0);
        AssignQuestion(questionList[0]);
    }

    public void Button1Click()
    {
        if (currentQuestion.correct1)
        {
            AnswerQuestion(true);
        }
        else
        {
            AnswerQuestion(false);
        }
    }

    public void Button2Click()
    {
        if (currentQuestion.correct2)
        {
            AnswerQuestion(true);
        }
        else
        {
            AnswerQuestion(false);
        }
    }

    public void Button3Click()
    {
        if (currentQuestion.correct3)
        {
            AnswerQuestion(true);
        }
        else
        {
            AnswerQuestion(false);
        }
    }

    public void Button4Click()
    {
        if (currentQuestion.correct4)
        {
            AnswerQuestion(true);
        }
        else
        {
            AnswerQuestion(false);
        }
    }
}
