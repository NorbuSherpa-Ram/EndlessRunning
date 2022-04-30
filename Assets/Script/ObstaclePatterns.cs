
using UnityEngine;

public class ObstaclePatterns : MonoBehaviour
{
    [SerializeField] GameObject obstacle;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(obstacle, transform.position, Quaternion.identity);
    }

}
