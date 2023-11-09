using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using Ink.Runtime;


public class dialogueVariable
{
    public void StarListening(Story story)
    {
        story.variablesState.variableChangedEvent += VariableChanged;
    }

    public void StopListening(Story story)
    {
        story.variablesState.variableChangedEvent -= VariableChanged;
    }


    private void VariableChanged(string name, Ink.Runtime.Object vaule)
    {
        Debug.Log("Variable changed: " +  name + " = " + vaule);
    }

}
