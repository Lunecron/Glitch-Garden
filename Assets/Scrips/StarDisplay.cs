using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StarDisplay : MonoBehaviour
{
    [SerializeField] int star = 100;
    TextMeshProUGUI starScore;
    // Start is called before the first frame update
    void Start()
    {
        starScore = GetComponent<TextMeshProUGUI>();
        UpdateDisplay();
    }

    // Update is called once per frame
    private void UpdateDisplay()
    {
        starScore.text = star.ToString();
    }

    public void AddStars(int amount)
    {
        star += amount;
        UpdateDisplay();
    }

    public void SpendStars(int amount)
    {
        if (star >= amount)
        {
            star -= amount;
            UpdateDisplay();
        }
        else
        {
            Debug.Log("Not enough stars");
        }
    }
}
