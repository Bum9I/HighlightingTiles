using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Raycast : MonoBehaviour
{
    [SerializeField] private LayerMask _layer;
    private GameObject _lastTile;
    
    private void Update()
    {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        GameObject hitObject = null;

        if (Physics.Raycast(ray, out var hitInfo, 50f, _layer))
        {
            hitObject = hitInfo.collider.gameObject;
            hitObject.GetComponent<Renderer>().material.color = Color.magenta;
        }

        if (hitObject != null && hitObject != _lastTile && _lastTile != null)
        {
            _lastTile.GetComponent<Renderer>().material.color = Color.white;
            _lastTile = hitObject;
        }
        else if (hitObject != null && _lastTile == null)
        {
            _lastTile = hitObject;
        }
        else if (hitObject == null && _lastTile != null)
        {
            _lastTile.GetComponent<Renderer>().material.color = Color.white;
        }
    }
}
