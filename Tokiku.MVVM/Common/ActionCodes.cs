﻿namespace Tokiku.Entity
{
    public enum ActionCodes
    {
        Create = 1,
        Read = 0,
        Update = 2,
        Delete = 4,
        ConstructionOrderChange = 8,
        SystemLogin = 16,
        SystemLogout = 32,
        EventLog = 64,
        Others = 0xf
    }
}