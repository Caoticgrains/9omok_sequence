using System.Collections;
using System.Collections.Generic;
using Common;
using Component.Board;
using Component.Player;
using Cysharp.Threading.Tasks.Triggers;
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
        public CardDeck cardDeck = new();

        public Content SelectedContent = Content.Back;

        public PlayerHand p1Hand;
        public PlayerHand p2Hand;

        public PlayerHand CurrentHand
        {
            get
            {
                if (logic.currentTurn == Owner.P1)
                    return p1Hand;
                if (logic.currentTurn == Owner.P2)
                    return p2Hand;

                return null;
            }
        }

        public enum EPhase
        {
            None,
            HandSelect,
            BoardSelect,
            EndTurn,
            EndGame,
        }

        public EPhase currentPhase = EPhase.None;


        protected override void OnSceneLoaded(Scene scene, LoadSceneMode mode)
        {
        }

        void Start()
        {
            
            logic.SetRandomTurn();
            CurrentHand.DrawNewCard();
            currentPhase = EPhase.HandSelect;
        }

        public void SelectHandCard(HandCard selected)
        {
            if (currentPhase != EPhase.HandSelect) return;
            if (logic.currentTurn != selected.owner) return;

            currentPhase = EPhase.BoardSelect;
            SelectedContent = selected.content;
            CurrentHand.Discard(selected);
        }

        public void SelectBoardUnit(BoardUnit selected)
        {
            if (currentPhase != EPhase.BoardSelect) return;
            if (SelectedContent != selected.cardData.content) return;
            if (selected.owner != Owner.None) return;

            currentPhase = EPhase.EndTurn;
            selected.SetSelectPlayer(logic.currentTurn);
            EndTurn();

            Debug.Log("타일 선택 완료");
        }

        public void EndTurn()
        {
            if (currentPhase != EPhase.EndTurn) return;

            if (logic.CheckVictory(Board.boardUnits))
            {
                EndGame();
                return;
            }

            logic.EndTurn();
            CurrentHand.DrawNewCard();
            currentPhase = EPhase.HandSelect;
        }

        public void OnClickMainMenuStartButton()
        {
            Debug.Log("OnClickMainMenuStartButton : Main -> Game");
            SceneManager.LoadScene("Game");
        }

        void EndGame()
        {
            currentPhase = EPhase.EndGame;
            Debug.Log($"게임 종료! 승자는 {currentPhase}");
        }
    }
}