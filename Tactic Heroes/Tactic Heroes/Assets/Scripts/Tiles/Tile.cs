using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Tile : MonoBehaviour
{
    [SerializeField] protected SpriteRenderer _spriteRenderer;
    [SerializeField] private GameObject _highlight;
    [SerializeField] private bool _isWalkable;

    public BaseUnit OccupiedUnit;
    public bool IsWalkable => _isWalkable && OccupiedUnit == null;
    public virtual void Init(int x, int y)
    {
      
    }

    private void OnMouseEnter()
    {
        _highlight.SetActive(true);
    }

    private void OnMouseExit()
    {
        _highlight.SetActive(false);
    }

    void OnMouseDown()
    {
        //if (Gamemanager.Instance.GameState != GameState.ChooseActions) return;

        if(OccupiedUnit != null)
        {
            if (OccupiedUnit.IsPlayable)
            {
                UnitManager.Instance.SetSelectedUnit(OccupiedUnit);        
            }
            else
            {
                UnitManager.Instance.SetSelectedUnit(null);
            }
        }
        else
        {
            UnitManager.Instance.SetSelectedUnit(null);
        }


    }
}

