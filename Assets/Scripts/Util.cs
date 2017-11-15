using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.UI;

public class Util
{
    public static V RandomInDict<K, V>(Dictionary<K, V> dict)
    {
        var keys = dict.Keys;
        var ind = Random.Range(0, dict.Keys.Count);
        return dict[keys.ElementAt(ind)];
    }

}