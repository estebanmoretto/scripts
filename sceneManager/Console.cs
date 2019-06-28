using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Console : MonoBehaviour {

    public delegate void ConsoleCommand();

    public InputField inpField;
    public Text backText;
    public Scrollbar verticalScrollbar;

    private Dictionary<string, ConsoleCommand> _myCommands;
    private Dictionary<string, string> _descriptions;

    private void OnEnable()
    {
        inpField.Select();
        inpField.text = "";
    }

    private void Awake()
    {
        _myCommands = new Dictionary<string, ConsoleCommand>();
        _descriptions = new Dictionary<string, string>();

       
    }

    void Start()
    {
       
        AddCommands("help", ShowHelp, "EL BOTON ROJO");
        AddCommands("clr", ClearConsole, "Clears past actions from log");
    }


    public void AddCommands(string cheat, ConsoleCommand com, string description)
    {
        _myCommands.Add(cheat, com);
        _descriptions.Add(cheat, description);
    }

    public void RemoveCommand(string cm)
    {
        _myCommands.Remove(cm);
        _descriptions.Remove(cm);
    }

    public void CheckInput()
    {
        if (_myCommands.ContainsKey(inpField.text))
            _myCommands[inpField.text]();
        else
            backText.text += "El comando " + inpField.text + " no existe\n";

        inpField.text = "";
    }

    private void ClearConsole()
    {
        backText.text = "";
    }

    private void ShowHelp()
    {
        string result = "";
        foreach (var elem in _descriptions)
            result += elem.Key + ": " + elem.Value + "\n";

        backText.text += result;
    }
}
