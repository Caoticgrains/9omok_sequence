using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    
    protected override void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        //throw new System.NotImplementedException();
    }
    
    public enum GameType { Intro, MainMenu, Build, Play, Outro }
    public GameType eGameType = GameType.Intro;

    void Start()
    {
        //Board.CreateBoard();
    }

    void Update()
    {
        switch (eGameType)
        {
            case GameType.Intro:
                // 
                break;
            case GameType.MainMenu:
                // 
                break;
            case GameType.Build:
                // Board.RayToBoard();
                break;
            case GameType.Play:
                // 
                break;
            case GameType.Outro:
                
                break;
            default:
                break;
        }
    }

    public void OnChangeType(GameType Type)
    {
        if(eGameType != Type)
            eGameType = Type;
    }

    

    void EndGame()
    {
        
    }
    
}
