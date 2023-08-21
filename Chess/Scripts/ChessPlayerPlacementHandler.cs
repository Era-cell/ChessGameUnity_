using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChessPlayerPlacementHandler : MonoBehaviour
{
    //Some functions will need reference to the controller
    public GameObject controller;

    //The Chesspiece that was tapped to create this MovePlate
    GameObject reference = null;

    //Location on the board
    int matrixX;
    int matrixY;

    //false: movement, true: attacking
    public bool attack = false;

    public void Start()
    {
        if (attack)
        {
            //Set to red
            gameObject.GetComponent<SpriteRenderer>().color = new Color(1.0f, 0.0f, 0.0f, 1.0f);
        }
    }

    public void OnMouseUp()
    {
        controller = GameObject.FindGameObjectWithTag("GameController");

        //Destroy the victim Chesspiece
        if (attack)
        {
            GameObject cp = controller.GetComponent<ChessBoardPlacementHandler>().GetPosition(matrixX, matrixY);

            //if (cp.name == "white_king") controller.GetComponent<ChessBoardPlacementHandler>().Winner("black");
            //if (cp.name == "black_king") controller.GetComponent<ChessBoardPlacementHandler>().Winner("white");

            Destroy(cp);
        }

        //Set the Chesspiece's original location to be empty
        controller.GetComponent<ChessBoardPlacementHandler>().SetPositionEmpty(reference.GetComponent<ChessMain>().GetXBoard(),
            reference.GetComponent<ChessMain>().GetYBoard());

        //Move reference chess piece to this position
        reference.GetComponent<ChessMain>().SetXBoard(matrixX);
        reference.GetComponent<ChessMain>().SetYBoard(matrixY);
        reference.GetComponent<ChessMain>().SetCoords();

        //Update the matrix
        controller.GetComponent<ChessBoardPlacementHandler>().SetPosition(reference);


        //Destroy the move plates including self
        reference.GetComponent<ChessMain>().DestroyMovePlates();
    }

    public void SetCoords(int x, int y)
    {
        matrixX = x;
        matrixY = y;
    }

    public void SetReference(GameObject obj)
    {
        reference = obj;
    }

    public GameObject GetReference()
    {
        return reference;
    }
}