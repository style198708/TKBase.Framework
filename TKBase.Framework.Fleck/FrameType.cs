using System;

namespace TKBase.Framework.Fleck
{
    public enum FrameType : byte
    {
        Continuation,
        Text,
        Binary,
        Close = 8,
        Ping = 9,
        Pong = 10,
    }
}

