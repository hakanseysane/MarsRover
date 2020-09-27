using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace MarsRover.Infrastructure.Enumerations
{
    public enum Direction
    {
        [Description("0,1")]
        North,
        [Description("1,0")]
        East,
        [Description("0,-1")]
        South,
        [Description("-1,0")]
        West,
        [Description("0,0")]
        None
    }
}
