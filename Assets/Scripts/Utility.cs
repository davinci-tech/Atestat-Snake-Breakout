using UnityEngine;

public class Utility
{
  // Source: https://discussions.unity.com/t/clampmagnitude-why-no-minimum/618306/5
  public static Vector3 ClampMagnitude(Vector3 v, float max, float min)
  {
    double sm = v.sqrMagnitude;
    if(sm > (double)max * (double)max) return v.normalized * max;
    else if(sm < (double)min * (double)min) return v.normalized * min;
    return v;
  }   
}
