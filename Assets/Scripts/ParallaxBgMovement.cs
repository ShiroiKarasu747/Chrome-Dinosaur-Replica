using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxBgMovement : MonoBehaviour
{
    private List<GameObject> bgPieces = new List<GameObject>();
    private GameObject firstPiece;
    private GameObject lastPiece;
    [SerializeField] List<GameObject> middlePiece;

    [SerializeField] float speed;


    // Start is called before the first frame update
    void Start()
    {
        int children = transform.childCount;
        for (int i = 0; i < children; ++i)
        {
            bgPieces.Add(transform.GetChild(i).gameObject);
            if (i != 0 && i != children - 1)
            {
                middlePiece.Add(bgPieces[i]);
            }
        }
        firstPiece = bgPieces[0];
        lastPiece = bgPieces[bgPieces.Count - 1];
    }

    // Update is called once per frame
    void Update()
    {
        if (middlePiece[middlePiece.Count - 1].transform.position.x < 0)
        {
            SwapHead2Tail();
        }
        foreach (GameObject piece in bgPieces)
        {
            piece.transform.Translate(Vector2.left * speed * Time.deltaTime);
        }
    }

    void SwapHead2Tail()
    {
        firstPiece.transform.position = lastPiece.transform.position
            + new Vector3(lastPiece.GetComponent<SpriteRenderer>().bounds.size.x, 0, 0);
        middlePiece.Add(lastPiece);
        lastPiece = firstPiece;
        firstPiece = middlePiece[0];
        middlePiece.RemoveAt(0);
    }
}
