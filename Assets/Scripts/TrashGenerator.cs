using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashGenerator : MonoBehaviour
{
    // Start is called before the first frame update
    public Vector2 TrashFieldSize= new Vector2(500,500);
    public GameObject AsteroidPrefab;

    private int trashAmount;
    private float maxTrashObjectSize=5;
    void Start()
    {
        Random.InitState(System.DateTime.Now.Millisecond);

        Vector2 TrashFieldStartPosition = -TrashFieldSize / 2;
        Vector2 TrashFieldFinishPosition = TrashFieldSize / 2;
        Debug.Log("field placed from " + TrashFieldStartPosition + "to " + TrashFieldFinishPosition);
        //split the field into cells
        float cellSize = maxTrashObjectSize * 2f;
        Debug.Log("cell size " + cellSize);

        int totalCells =  (int)( (TrashFieldSize.x / cellSize) * (TrashFieldSize.y / cellSize));
        
         
        //and get the position in the center of each cell
        List<Vector2> positions = new List<Vector2>();

        for (float i = TrashFieldStartPosition.x+cellSize / 2; i < TrashFieldFinishPosition.x; i+=cellSize)
            for (float j = TrashFieldStartPosition.y + cellSize / 2; j < TrashFieldFinishPosition.y; j+=cellSize)
            {
                Debug.Log("new point" + i +" "+ j);
                positions.Add(new Vector2(i, j));
            }


        Shuffle(positions);
        Debug.Log("positions found" + positions.Count);
        //spam a trash object in 1/3 positions
        int TrashAmount = positions.Count;// / 3; 
        for (int it=0; it < TrashAmount; it++)
        {
            float offsetX=Random.Range(-cellSize/2, cellSize / 2);
            float offsetY = Random.Range(-cellSize / 2, cellSize / 2);
            Vector3 position = new Vector3(positions[it].x+ offsetX, 10f, positions[it].y+ offsetY);

            Debug.Log("asteroid spawned in podition " + position);
            GameObject asteroid = Instantiate(AsteroidPrefab, position, new Quaternion(0, 0, 0, 0));
            float size = Random.Range(0.5f, maxTrashObjectSize);
            resize(asteroid, size);

            Health hp = asteroid.GetComponent<Health>();
            hp.setMaximum(50f * size);
            Rigidbody rb = asteroid.GetComponent<Rigidbody>();
            rb.mass = size * 1000;
           // rb.AddForce(transform.right * Random.Range(-1000f,1000f), ForceMode.Impulse);
           // rb.AddForce(transform.forward * Random.Range(-1000f, 1000f), ForceMode.Impulse);
        }
    }

    private void Shuffle<T>(IList<T> ts)
    {
        var count = ts.Count;
        var last = count - 1;
        for (var i = 0; i < last; ++i)
        {
            var r = UnityEngine.Random.Range(i, count);
            var tmp = ts[i];
            ts[i] = ts[r];
            ts[r] = tmp;
        }
    }
    private void resize(GameObject obj, float size)
    {
        var r = obj.GetComponent<Collider>();
        if (r == null)
        {
            Debug.Log("no collider");
            return;
        }
        var curSize = r.bounds.size;
        if (curSize.x > 1f || curSize.z > 1f)
        {
            float scale;
            if (curSize.x > curSize.z)
                scale = size / curSize.x;
            else
                scale = size / curSize.z;
            obj.transform.localScale *= scale;
        }
    }
}
