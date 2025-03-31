using System.Collections.Generic;
using Component.Board;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace System
{
    
public class BoardRayCaster : MonoBehaviour
{
    public static BoardRayCaster Instance;

    private GraphicRaycaster _uiRaycaster;
    private EventSystem _eventSystem;

    private void Awake()
    {
        if (Instance == null) Instance = this;

        _uiRaycaster = FindObjectOfType<GraphicRaycaster>();
        _eventSystem = FindObjectOfType<EventSystem>();

        if (_uiRaycaster == null) Debug.LogError("GraphicRaycaster가 씬에 없습니다.");
        if (_eventSystem == null) Debug.LogError("EventSystem이 씬에 없습니다.");
    }

    private void Update()
    {
        if (IsMouseOverUI(out GameObject hitObject))
        {
            Debug.Log($"현재 {hitObject.name} 위에 마우스가 있습니다.");

            // BoardUnit 감지
            BoardUnit boardUnit = hitObject.GetComponent<BoardUnit>();
            
            if (boardUnit != null)
            {
                Debug.Log($"BoardUnit 감지됨: {boardUnit.name}");
                OnBoardUnit(boardUnit);
            }
        }
    }

    /// <summary>
    /// UI 요소 위에 있는지 체크 + 감지된 오브젝트 반환
    /// </summary>
    public bool IsMouseOverUI(out GameObject hitObject)
    {
        hitObject = null;
        if (_uiRaycaster == null || _eventSystem == null) return false;

        PointerEventData eventData = new PointerEventData(_eventSystem);
        eventData.position = Input.mousePosition;

        List<RaycastResult> results = new List<RaycastResult>();
        _uiRaycaster.Raycast(eventData, results);

        if (results.Count > 0)
        {
            hitObject = results[0].gameObject;
            return true;
        }

        return false;
    }

    /// <summary>
    /// BoardUnit 감지 시 실행할 함수
    /// </summary>
    private void OnBoardUnit(BoardUnit boardUnit)
    {
        boardUnit.OnSelect();
        Debug.Log($"BoardUnit {boardUnit.name}에 마우스가 올라갔습니다.");
    }
    
}
}
