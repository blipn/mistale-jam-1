using UnityEngine;

public class Parallax : MonoBehaviour
{
    private float length, startpos;
    public GameObject cam;
    public float parallaxEffect;

    // Start is called before the first frame update
    private void Start()
    {
        startpos = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    // Update is called once per frame
    private void Update()
    {
        var position = cam.transform.position;
        float temp = (position.x * (1 - parallaxEffect));
        float dist = (position.x * parallaxEffect);

        var transform1 = transform;
        var position1 = transform1.position;
        position1 = new Vector3(startpos + dist, position1.y, position1.z);
        transform1.position = position1;

        if (temp > startpos + length * 0.8) startpos += length;
        else if (temp < startpos - length) startpos -= length;
    }
}
