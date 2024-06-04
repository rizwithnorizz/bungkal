using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class QuestionScript : MonoBehaviour
{
    public GameObject _questionPanel;
    public TMP_InputField _questionField;

    [System.Serializable]
    public class Compile{
        public List<Question> QnA = new List<Question>();
        public List<Button> choices = new List<Button>();
    }
    public Compile compiler = new Compile();
    void Start()
    {
        if (_questionPanel.activeSelf){
            _questionPanel.SetActive(false);
        } else {
            _questionPanel.SetActive(true);
        }
    }
    public void generateQuestion(){
        _questionPanel.SetActive(true);
        int randomIndex = Random.Range(0, compiler.QnA.Count);
        _questionField.text = compiler.QnA[randomIndex].question;

        compiler.choices[0].GetComponentInChildren<TMP_Text>().text = compiler.QnA[randomIndex].answers[0];
        compiler.choices[1].GetComponentInChildren<TMP_Text>().text = compiler.QnA[randomIndex].answers[1];
        compiler.choices[2].GetComponentInChildren<TMP_Text>().text = compiler.QnA[randomIndex].answers[2];
        compiler.choices[3].GetComponentInChildren<TMP_Text>().text = compiler.QnA[randomIndex].answers[3];

        for (int x = 0; x<4; x++){
            if (x == compiler.QnA[randomIndex].correctIndex){ 
                compiler.choices[x].onClick.AddListener(correctAnswer);
            }else{
                compiler.choices[x].onClick.AddListener(wrongAnswer);
            }

        }
    }

    public void correctAnswer(){
        _questionPanel.SetActive(false);
        Debug.Log("Correct Answer!");
    }

    public void wrongAnswer(){
        _questionPanel.SetActive(false);
        Debug.Log("Wrong answer!");
    }

    public void closeWindow(){
        _questionPanel.SetActive(false);
    }
}
