using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSpawner : MonoBehaviour
{

    Defender defender;
    private void OnMouseDown()
    {
        if (defender)
        {
            SpawnDefender(GetSquareClicked());
        }

    }

    public void SetSelectedDefender(Defender defenderToSelect)
    {
            defender = defenderToSelect;
    }

    private void SpawnDefender(Vector2 worldPos)
    {
        
        Defender newDefender = Instantiate(defender, worldPos, Quaternion.identity) as Defender;
    }

    private Vector2 SnapToGrid(Vector2 rawWorldPos)
    {
        float newX = Mathf.RoundToInt(rawWorldPos.x);
        float newY = Mathf.RoundToInt(rawWorldPos.y);
        return new Vector2(newX, newY);
    }

    private Vector2 GetSquareClicked()
    {
        Vector2 clickPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 worldPos = Camera.main.ScreenToWorldPoint(clickPos);
        Vector2 gridPos = SnapToGrid(worldPos);
        return gridPos;
    }
}
