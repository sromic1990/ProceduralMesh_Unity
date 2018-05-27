using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace Sourav.Utilities.EditorUtils
{
    public class SwitchOnOffMacro : Editor 
    {
        public static void MacroOnOff(BuildTargetGroup group , string macro, MacroAction action)
        {
            //Debug.Log("group = "+group.ToString());

            string Defines = PlayerSettings.GetScriptingDefineSymbolsForGroup(group);
            string[] symbols = Defines.Split(';');
            bool macroFound = false;
            string resultantMacros = "";

            for (int i = 0; i < symbols.Length; i++)
            {
                if (symbols[i].Equals(macro))
                {
                    macroFound = true;
                    if(action.Equals(MacroAction.Off))
                    {
                        symbols[i] += "_OFF";
                    }
                }
                else if(symbols[i].Equals(macro + "_OFF"))
                {
                    macroFound = true;
                    if(action.Equals(MacroAction.On))
                    {
                        symbols[i] = macro;
                    }
                }
                resultantMacros += symbols[i] + ";";
            }

            if(!macroFound)
            {
                Debug.Log("Macro not found");
                if(action.Equals(MacroAction.On))
                {
                    resultantMacros += macro + ";";
                }
            }

            //Debug.Log("resultantMacros = "+resultantMacros);

            PlayerSettings.SetScriptingDefineSymbolsForGroup(group, resultantMacros);

        }
    }
}

public enum MacroAction
{
    On,
    Off
}
