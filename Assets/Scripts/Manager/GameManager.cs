using System.Collections;
using System.Collections.Generic;
using Common;
using Component.Board;
using Data;
using Pattern;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Manager
{
    /// <summary>
    /// 턴오버 턴타임
    /// 
    /// </summary>
    public class GameManager : Singleton9<GameManager>
    {
        #region manager-active

        private Board _board;

        public Board Board
        {
            get
            {
                if (_board == null)
                    _board = FindObjectOfType<Board>(true);
                return _board;
            }
        }

        #endregion

        public GameLogic logic = new();

        public Content SelectedContent = Content.Back;

        public enum EPhase
        {
            None,
            HandSelect,
            BoardSelect,
            EndTurn,
        }

        public EPhase currentPhase = EPhase.None;


        protected override void OnSceneLoaded(Scene scene, LoadSceneMode mode)
        {
        }

        void Start()
        {
            logic.SetRandomTurn();
            currentPhase = EPhase.HandSelect;
        }

        public void SelectHandCard(HandCard selected)
        {
            Debug.Log(selected.content);
            if (currentPhase != EPhase.HandSelect) return;
            Debug.Log(selected.content);
            if (logic.currentTurn != selected.owner) return;
            Debug.Log(selected.content);
            
            
            currentPhase = EPhase.BoardSelect;
            SelectedContent = selected.content;
            ObjectPoolManager.Instance.ReturnHandCard(selected.gameObject);
            
        }

        public void SelectBoardUnit(BoardUnit selected)
        {
            if (currentPhase != EPhase.BoardSelect) return;
            if (selected.owner != Owner.None) return;
            
            currentPhase = EPhase.EndTurn;
            selected.SetSelectPlayer(logic.currentTurn);
            EndTurn();
            
            Debug.Log("타일 선택 완료");
        }

        public void EndTurn()
        {
            if (currentPhase != EPhase.EndTurn) return;
            logic.EndTurn();
            currentPhase = EPhase.HandSelect;
        }

        public void OnClickMainMenuStartButton()
        {
            Debug.Log("OnClickMainMenuStartButton : Main -> Game");
            SceneManager.LoadScene("Game");
        }

        void EndGame()
        {
        }
    }
}