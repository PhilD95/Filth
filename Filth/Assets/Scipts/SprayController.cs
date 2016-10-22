using UnityEngine;
using System.Collections;

public class SprayController : MonoBehaviour
{

    float power; // 0.0 - 1.0 amount of resistance from  spray (1.0 = no contamination while the spray is in effect)
    float capacity; // max amount of spray

    float dose_amount; // amount of spray used when fired
    float charge_rate; // capacity units recharged pr frame
    int last_fired_framecount; // when was it last fired
    int effect_duration; // how many frames does one effect last

    private bool fired; // whether the spray has been fired and is currently in effect
    private bool overheated; // if the level as gone below 0.0 the spray overheats and cant be used till full capacity again
    private float level; // current amount of spray

    void setDebugValues()
    {
        capacity = 100.0f;
        level = capacity;
        dose_amount = 60.0f;
        charge_rate = 2.0f;

        effect_duration = 200;
    }
    // Use this for initialization
    void Start()
    {
        Debug.Log("In spray init");
        last_fired_framecount = 0;
        power = 1.0f;
        fired = false;
        overheated = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!overheated)
        {

            if (fired && effect_duration < Time.frameCount - last_fired_framecount)
            {
                fired = false;
            }
        }


        if (level < capacity)
        {
            level += charge_rate;
            if (level > capacity)
            {
                level = capacity;
                overheated = false;
            }
        }
    }

    public bool fire()
    {
        // if we used the spray too much, or too little time since last we fired it
        if (overheated || fired && (effect_duration > Time.frameCount - last_fired_framecount))
        {
            System.Console.WriteLine("nope");
            return false;
        }

        level -= dose_amount;
        if (level <= 0.0)
        {
            level = 0.0f;
            overheated = true;
        }

        fired = true;
        return true;
    }

    public bool isFired()
    {
        return fired;
    }

    public bool isOverheated()
    {
        return overheated;
    }

    // returns percentage of charge level
    public float getChargeLevel()
    {
        return level / capacity;
    }

    // returns the spray effect as a factor to be multiplied by the current contamination
    public float getContaminationFactor()
    {
        if (isFired())
        {
            return 1.0f - power;
        }
        return 1.0f;
    }
}