using System.Collections.Generic;
using UnityEngine;

public class Selected : ICommand
{
    private CharactersSelect charSelect;
    private EditTeam editTeam;

    private Selected(CharactersSelect charSelect, EditTeam editTeam)
    {
        this.charSelect = charSelect;
        this.editTeam = editTeam;
    }

    public void Execute()
    {
        
    }

    public void Undo()
    {

    }
}
