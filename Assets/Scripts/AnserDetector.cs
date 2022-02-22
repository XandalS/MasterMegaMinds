using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AnserDetector : MonoBehaviour
{
    public GameObject[] CurrentRow;
    public GameObject[] AnswerKey;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Evaluate();
        }   
    }

    private void Evaluate()
    {
        Material[] answerMats = new Material[AnswerKey.Length];
        for ( int i =0; i< AnswerKey.Length; i++)
        {
            Material temp = AnswerKey[i].GetComponent<MeshRenderer>().material;
            answerMats[i] = temp;
        }
        Material[] currentRowMats = new Material[CurrentRow.Length];
        for (int i = 0; i < CurrentRow.Length; i++)
        {
            Material temp = CurrentRow[i].GetComponent<MeshRenderer>().material;
            currentRowMats[i] = temp;
        }

        report(currentRowMats, answerMats);
    }

    void report(Material[] currentRowMats, Material[] answerMats)
    {
        int[] answers = new int[answerMats.Length];

        for (int i = 0; i < currentRowMats.Length; i++)
        {
            if (currentRowMats[i].color == answerMats[i].color)
            {
                answers[i] = 1;
                Debug.Log($"{currentRowMats[i]} is the same in both.");
            }
            else
            {

                Debug.Log($"{currentRowMats[i]} is different from {answerMats[i]}.");
                List<Material> compMats = answerMats.ToList();
                //if (compMats.Contains(currentRowMats[i]))
                if (Array.Find(answerMats, m => m.color == currentRowMats[i].color))
                {
                    answers[i] = 0;
                }
                else
                {
                    answers[i] = -1;
                }
            }
        }
        for (int i = 0; i < currentRowMats.Length; i++)
        {
            if (answers[i] == 1)
            {
                Debug.Log("Ding O ");
            }
            else if (answers[i] == 0)
            {
                Debug.Log("Boop ?");
            }
            else
            {
                Debug.Log("EEeh X ");
            }
            Debug.Log($"At index:{i}, nums is {currentRowMats[i]}, and nums 2 is {answerMats[i]}.");
        }
    }
}
