using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ILog
{
    public void Log<String>(string name, string msg);
}
