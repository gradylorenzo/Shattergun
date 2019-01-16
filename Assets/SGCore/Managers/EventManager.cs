using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class EventManager
{
    public delegate void PlayerMovedUpEvent();
    public static PlayerMovedUpEvent AllPlayersMovedUp;
}
