using MarsRover.Infrastructure.Enumerations;
using MarsRover.Infrastructure.Managers.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover.Infrastructure.Managers.Abstract
{
    public interface ICommandManager
    {
        Mission GetMissionViaCommand(string commandText);
        Direction GetDirection(string command);
    }
}
