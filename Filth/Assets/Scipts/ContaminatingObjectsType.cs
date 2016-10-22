public class ContaminatingObjectsType
{

    string name;
    float strength;
    float range;
    float decay;

    public ContaminatingObjectsType(string l_name, float l_strength, float l_range)
    {
        name = l_name;
        strength = l_strength;
        range = l_range;
    }

    public void setName(string l_name)
    {
        name = l_name;
    }

    public void setStrength(float l_str)
    {
        strength = l_str;
    }

    public void setRange(float l_rng)
    {
        range = l_rng;
    }

    public void setDecay(float l_decay)
    {
        decay = l_decay;
    }

    public float getRange()
    {
        return range;
    }

    public float getStrength()
    {
        return strength;
    }

    public string getName()
    {
        return name;
    }

    public float getDecay()
    {
        return decay;
    }
}
