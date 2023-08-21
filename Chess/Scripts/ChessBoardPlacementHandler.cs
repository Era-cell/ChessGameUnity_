using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Dynamic;
using UnityEngine;

public class ChessBoardPlacementHandler : MonoBehaviour
{
 
    public GameObject chesspiece;

    private GameObject[,] positions = new GameObject[8, 8];
    private GameObject[] playerBlack = new GameObject[16];
    private GameObject[] playerWhite = new GameObject[16];

    private string currentPlayer = "white";

    //private bool gameOver = false;
    void Start()
    {
        playerWhite = new GameObject[] { Create("white_rook", -4, 3), Create("white_knight", -3, 3),
            Create("white_bishop", -2, 3), Create("white_queen", -1, 3), Create("white_king",  0, 3),
            Create("white_bishop", 1, 3), Create("white_knight", 2, 3), Create("white_rook", 3, 3),
            Create("white_pawn", -4, 2), Create("white_pawn", -3, 2), Create("white_pawn", -2, 2),
            Create("white_pawn", -1,2), Create("white_pawn", 0, 2), Create("white_pawn", 1, 2),
            Create("white_pawn", 2, 2), Create("white_pawn", 3, 2) };
        playerBlack = new GameObject[] { Create("black_rook", -4, -4), Create("black_knight",-3,-4),
            Create("black_bishop",-2,-4), Create("black_queen",-1,-4), Create("black_king",0,-4),
            Create("black_bishop",1,-4), Create("black_knight",2,-4), Create("black_rook",3,-4),
            Create("black_pawn", -4, -3), Create("black_pawn", -3, -3), Create("black_pawn", -2, -3),
            Create("black_pawn", -1, -3), Create("black_pawn", 0, -3), Create("black_pawn", 1, -3),
            Create("black_pawn", 2, -3), Create("black_pawn", 3, -3) };

        for (int i = 0; i < playerBlack.Length; i++)
        {
            SetPosition(playerBlack[i]);
            SetPosition(playerWhite[i]);
        }
    }

    public GameObject Create(string name, int x, int y)
    {
        GameObject obj = Instantiate(chesspiece, new Vector3(0, 0, 1), Quaternion.identity);
        ChessMain cm = obj.GetComponent<ChessMain>();
        cm.name = name; 
        cm.SetXBoard(x);
        cm.SetYBoard(y);
        cm.Activate();
        return obj;
    }

    public void SetPosition(GameObject obj)
    {
        
        ChessMain cm = obj.GetComponent<ChessMain>();
        UnityEngine.Debug.Log($"setting positions:{cm.GetXBoard()+4}{cm.GetYBoard()+4}");
        positions[(int)(cm.GetXBoard()+4), (int)(cm.GetYBoard()+4)] = obj;
    }

    public void SetPositionEmpty(int x, int y)
    {
        positions[x + 4, y + 4] = null;
    }

    public GameObject GetPosition(int x, int y)
    {
        UnityEngine.Debug.Log($"positions Req:{x+4}{y+4}");
        return positions[x+4, y+4];
    }

    public bool PositionOnBoard(int x, int y)
    {
        if (x < -4 || y < -4 || x > 3 || y > 3) return false;
        return true;
    }

}
