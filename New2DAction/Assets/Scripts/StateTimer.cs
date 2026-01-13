using UnityEngine;

public class StateTimer 
{
    float coolTime;

    void Update()
    {
        coolTime -= Time.deltaTime;
    }
}
