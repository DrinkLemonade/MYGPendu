using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMover : MonoBehaviour
{
    private SpriteRenderer myRenderer;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        myRenderer = this.GetComponent<SpriteRenderer>() as SpriteRenderer;
        //Debug.Log(myRenderer.size.x);
        //TODO: See if I can make a background element disappear only when it's not visible, by tracking if x+sprite width is < camera left bound's x
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;
        if (transform.position.x < -20) transform.position = new Vector3(19,0,0);
    }
}
