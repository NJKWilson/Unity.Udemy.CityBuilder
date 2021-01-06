using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class InputManager : MonoBehaviour
{
    public LayerMask mouseInputMask;
    private Action<Vector3> _onPointerDownHandler;
    
    // Update is called once per frame
    void Update()
    {
        GetInput();
    }

    public void GetInput()
    {
        // Check Camera is not null
        if (Camera.main is null)
        {
            Debug.Log("Camera id Null :(");
            return;
        }
        
        // If there is no left click or if left click is on th UI do nothing
        if (!Input.GetMouseButtonDown(0) || EventSystem.current.IsPointerOverGameObject()) return;
        
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray.origin,ray.direction, out var hit, Mathf.Infinity, mouseInputMask))
        {
            Vector3 position = hit.point - transform.position;
            _onPointerDownHandler?.Invoke(position);
        }
    }

    public void AddListenerOnPointerDownEvent(Action<Vector3> listener)
    {
        _onPointerDownHandler += listener;
    }
    
    public void RemoveListenerOnPointerDownEvent(Action<Vector3> listener)
    {
        _onPointerDownHandler -= listener;
    }
}
