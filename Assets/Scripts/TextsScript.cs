using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class TextsScript : MonoBehaviour
{
    MeteoriteScript scMeteorite;
    Vector3 rotate;
    [SerializeField] float speed = 0.75f;

    public static TextsScript instance;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(this.gameObject);
    }
    void Start()
    {
        scMeteorite = FindObjectOfType<MeteoriteScript>();
        this.gameObject.transform.localScale = scMeteorite.transform.localScale;

        TextValues();

        rotate = new Vector3(0, 0, 1);
    }

     void FixedUpdate()
    {
        transform.Rotate(rotate * speed * Time.fixedDeltaTime);
    }
    //attaching values into textsphere object
    void TextValues()
    {
        string[] Values = new string[12];
        for (int i = 0; i < 3; i++)
        {    //for multiplication
            Values[i] = "* ";
            Values[i] += Random.Range(2, 10);
        }
        for (int i = 3; i < 6; i++)
        {    //for addition
            Values[i] = "+ ";
            Values[i] += Random.Range(1, 50);
        }
        for (int i = 6; i < 9; i++)
        {    //for division
            Values[i] = "% ";
            Values[i] += Random.Range(2, 10);
        }
        for (int i = 9; i < 12; i++)
        {    //for subtraction 
            Values[i] = "- ";
            Values[i] += Random.Range(1, 50);
        }

        //adding values into text gameobjects randomly
        for (int i = 0; i < 12; i++)
        {
            int randomNumber = Random.Range(0, 12);
            this.gameObject.transform.GetChild(i).GetComponent<TextMeshProUGUI>().text = Values[randomNumber].ToString();
            if (Values[randomNumber].StartsWith('%') || Values[randomNumber].StartsWith('-'))
            {
                this.gameObject.transform.GetChild(i).GetComponent<TextMeshProUGUI>().color = Color.red;
            }
            else
            {
                this.gameObject.transform.GetChild(i).GetComponent<TextMeshProUGUI>().color = Color.green;
            }
        }
    }
}
