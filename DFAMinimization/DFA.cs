using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DFAMinimization
{
    class DFA
    {
        public List<string> Letters = new List<string>();
        public List<string> States = new List<string>();
        public List<string> FinalStates = new List<string>();
        public string[,] TransitionFunction = new string[0, 0];
        public string Name;

        public DFA() { }
        public DFA(string name)
        {
            Name = name;
        }

        private List<string> FileReader(string path)
        {
            string[] strFile = File.ReadAllLines(path, Encoding.Default);
            Array.Sort(strFile);
            return strFile.ToList();
        }

        // Get all info of input DFA
        public void FillDFA(string path)
        {
            List<string> FileLines = FileReader(path);
            Letters = FileLines[0].Split(' ').ToList();
            Letters.RemoveAt(0);
            TransitionFunction = new string[FileLines.Count - 1, Letters.Count];

            foreach (string line in FileLines)
            {
                if (line == FileLines[0]) continue;
                
                List<string> strState = line.Split(' ').ToList();
                States.Add(strState[0]);
                
                for (int i = 1; i <= Letters.Count; i++)
                {                    
                    TransitionFunction[FileLines.IndexOf(line) - 1, i - 1] = strState[i];
                }

                if (strState.Count > Letters.Count + 1) 
                    FinalStates.Add(line[0].ToString());
            }
        }

        // Check if input word can be accept by this DFA
        //public bool CheckWord(string word)
        //{
        //    int state = States[0];

        //    foreach (char c in word)
        //    {
        //        foreach (string letter in Letters)
        //        {
        //            if (c.ToString() == letter)
        //                state = TransitionFunction[state, Letters.IndexOf(letter)];
        //        }
        //    }

        //    foreach (int stt in States)
        //    {
        //        if (States[States.IndexOf(stt)] == state)
        //            return FinalStates[States.IndexOf(stt)];
        //    }
        //    return false;
        //}

        public DFA ReduceDFA()
        {
            List<string> newStates = new List<string>();
            List<string> newFinalStates = new List<string>();
            string[,] newTF;
            string[,] table = new string[States.Count, States.Count];

            DFA newDFA = new DFA();
            newDFA.Letters = Letters;

            // Handl the equivalence of two states in input DFA
            for (int i = 0; i < States.Count; i++)
            {
                for (int j = 0; j < States.Count; j++)
                {
                    if (i == j) table[i, j] = "=";
                    else if (i > j) table[i, j] = "#";
                    else table[i, j] = "+"; // i < j
                }
            }

            // Distinguish the final states and the non-final states
            foreach (string state1 in States)
            {
                if (FinalStates.Contains(state1))
                {
                    foreach (string state2 in States)
                    {
                        if (!FinalStates.Contains(state2) && States.IndexOf(state2) < States.IndexOf(state1))
                            table[States.IndexOf(state2), States.IndexOf(state1)] = "*";
                        else if (!FinalStates.Contains(state2) && States.IndexOf(state2) > States.IndexOf(state1))
                            table[States.IndexOf(state1), States.IndexOf(state2)] = "*";
                    }
                }
            }

            int count = 0;
            do
            {
                int[] SecondStates = new int[4];
                count = 0;
                for (int i = 0; i < States.Count; i++)
                {
                    for (int j = 0; j < States.Count; j++)
                    {
                        if (table[i, j] == "+")
                        {
                            foreach (string state in States)
                            {
                                if (TransitionFunction[i, 0] == state)
                                    SecondStates[0] = States.IndexOf(state);
                                if (TransitionFunction[j, 0] == state)
                                    SecondStates[1] = States.IndexOf(state);
                                if (TransitionFunction[i, 1] == state)
                                    SecondStates[2] = States.IndexOf(state);
                                if (TransitionFunction[j, 1] == state)
                                    SecondStates[3] = States.IndexOf(state);
                            }

                            if ((table[SecondStates[0], SecondStates[1]] == "=" && table[SecondStates[2], SecondStates[3]] == "=")
                                || (table[SecondStates[0], SecondStates[1]] == "=" && table[SecondStates[3], SecondStates[2]] == "=")
                                || (table[SecondStates[1], SecondStates[0]] == "=" && table[SecondStates[2], SecondStates[3]] == "=")
                                || (table[SecondStates[1], SecondStates[0]] == "=" && table[SecondStates[3], SecondStates[2]] == "="))
                            {
                                table[i, j] = "=";
                                count++;
                            }
                            if (table[SecondStates[0], SecondStates[1]] == "*"
                                || table[SecondStates[1], SecondStates[0]] == "*"
                                || table[SecondStates[2], SecondStates[3]] == "*"
                                || table[SecondStates[3], SecondStates[2]] == "*")
                            {
                                table[i, j] = "*";
                                count++;
                            }
                        }
                    }
                }

            }
            while (count != 0);

            for (int i = 0; i < States.Count; i++)
            {
                string temp = string.Empty;
                for (int j = 0; j < States.Count; j++)
                {
                    if (table[i, j] == "=")
                    {
                        temp += States[j] + " ";
                    }
                }
                newStates.Add(temp);
            }

            string[] tempStates = newStates.ToArray();
            for (int i = 0; i < newStates.Count; i++)
            {
                for (int j = 0; j < newStates.Count; j++)
                {
                    if (i != j)
                    {
                        for (int k = 0; k < newStates[j].Length; k++)
                        {
                            if (newStates[i].Contains(tempStates[j][k]) && tempStates[j][k] != ' ')
                            {
                                //newStates[i] += tempStates[j];
                                newStates[j] = string.Empty;
                            }
                        }
                    }
                }
            }

            newStates = newStates.Where(s => s != string.Empty).ToList();
            // Handl new Final States
            foreach (string state in newStates)
            {
                foreach (string FS in FinalStates)
                {
                    if (state.Contains(FS))
                        newFinalStates.Add(state);
                }
            }

            newTF = new string[newStates.Count, newDFA.Letters.Count];
            for (int i = 0; i < newStates.Count; i++)
            {
                for (int j = 0; j < Letters.Count; j++)
                {
                    foreach (string state in newStates)
                    {
                        if (state.Contains(TransitionFunction[i, j]))
                            newTF[i, j] = state;
                    }
                }
            }

            newDFA.States = newStates;
            newDFA.TransitionFunction = newTF;
            newDFA.FinalStates = newFinalStates;            
            
            return newDFA;
        }
    }
}
