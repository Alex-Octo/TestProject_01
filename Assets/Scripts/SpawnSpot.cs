using UnityEngine;

public class SpawnSpot : MonoBehaviour
{
    public bool busy = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        busy = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        busy = false;
    }

}
