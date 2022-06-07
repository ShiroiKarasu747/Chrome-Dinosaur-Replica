using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cactus : MonoBehaviour
{
    bool hasCollided = false;
    [SerializeField] float speed = 10;
    public int facingLeft = 1;
    private IEnumerator coroutine;

    public GameObject scoreControl;
    public GameObject player;
    public bool hasScored = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!this.hasCollided)
        {
            this.transform.Translate(Vector2.left * this.speed * Time.deltaTime * this.facingLeft);
        }

        if (this.hasScored == false && this.transform.position.x <= player.transform.position.x)
        {
            this.hasScored = true;
            scoreControl.GetComponent<ScoreControl>().IncreaseScore(1);
        }
    }

    public IEnumerator DeactiveDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        this.gameObject.SetActive(false);
    }

    public void GenerateSpike()
    {
        this.gameObject.SetActive(true);
        this.coroutine = DeactiveDelay(5f);
        this.hasScored = false;
        StartCoroutine(this.coroutine);
        this.hasCollided = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            this.hasCollided = true;
            StopCoroutine(this.coroutine);
        }
    }

    public void SetFacingLeft(int index)
    {
        this.facingLeft = index;
    }

    public void DeactiveBall()
    {
        this.gameObject.SetActive(false);
    }

    void Hit()
    {

    }
}
