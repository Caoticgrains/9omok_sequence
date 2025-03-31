using System.Collections;
using System.Collections.Generic;
using Common;
using Component.Board;
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
        
        protected override void OnSceneLoaded(Scene scene, LoadSceneMode mode)
        {
        }

        public enum GameType
        {
            Intro,
            MainMenu,
            Build,
            Play,
            Outro
        }

        public GameType eGameType = GameType.Intro;
        
        void Start()
        {
            logic.SetRandomTurn();
            Debug.Log($"{logic.currentTurn}");
        }

        // SceneManager.LoadScene("Main");
        
        
        private void OnApplicationQuit()
        {
            
        }

        public void AllClear()
        {
            
        }
 
        // var lastRow = _visibleCells.Last();
        //     if (!IsVisibleIndex(lastRow.index))
        // {
        //     var stageCellButtons = lastRow.stageCellButtons;
        //     foreach (var stageCellButton in stageCellButtons)
        //     {
        //         ObjectPool.Instance.ReturnObj(stageCellButton.gameObject);
        //     }
        //     _visibleCells.RemoveAt(_visibleCells.Count - 1);
        // }
        
        void Update()
        {
            switch (eGameType)
            {
                case GameType.Intro:
                    break;
                case GameType.MainMenu:
                    break;
                case GameType.Build:
                    break;
                case GameType.Play:
                    break;
                case GameType.Outro:
                    break;
                default:
                    break;
            }
        }

        public void OnClickMainMenuStartButton()
        {
            Debug.Log("OnClickMainMenuStartButton : Main -> Game");
            SceneManager.LoadScene("Game");
        }
        
        public void OnChangeType(GameType Type)
        {
            if (eGameType != Type)
                eGameType = Type;
        }
        
        void EndGame()
        {

        }
    }
}
