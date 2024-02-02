using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandInvoker
{
    private static Stack<ICommand> teamHistory = new Stack<ICommand>();
    private const int MaxTeam = 4;
    
    public static void ExecuteCommand(ICommand command)
    {
        command.Execute();
        teamHistory.Push(command);

        if (teamHistory.Count > MaxTeam)
        {
            teamHistory.Pop();
        }
    }

    public static void UndoCommand()
    {
        if (teamHistory.Count > 0)
        {
            ICommand lastCommand = teamHistory.Pop();
            lastCommand.Undo();
        }
    }
}
