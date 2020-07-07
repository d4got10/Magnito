using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISwitchable
{
    void TurnOn(ISwitchable parent);
    void TurnOff(ISwitchable parent);
}
