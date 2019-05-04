using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DFAMinimization
{
    public partial class DFAMinimization : Form
    {
        string fileName = string.Empty;
        DFA openedDFA = new DFA("Opened DFA");
        DFA newDFA = new DFA();
        public DFAMinimization()
        {
            InitializeComponent();
        }

        private void btn_OpenDFAFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog OFDialog = new OpenFileDialog();
            OFDialog.InitialDirectory = "D:\\WinForm\\DFAMinimization";
            OFDialog.RestoreDirectory = true;
            OFDialog.Filter = "files *.txt|*.txt";

            if (OFDialog.ShowDialog() == DialogResult.OK)
                fileName = OFDialog.FileName;

            openedDFA = new DFA("Opened DFA");
            openedDFA.FillDFA(fileName);
            pnl_MinimizedDFA.Controls.Clear();

            printDFA(openedDFA, 0);           
        }


        private void btn_MinimizeOpenedDFA_Click(object sender, EventArgs e)
        {
            newDFA = openedDFA.ReduceDFA();
            newDFA.Name = "Minimized DFA";
            printDFA(newDFA, 450);
        }

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void printDFA(DFA DFA, int margin)
        {
            GroupBox grp_Name = new GroupBox();
            grp_Name.Width = 90;
            grp_Name.Height = 40;
            grp_Name.Location = new Point(margin + 30, 0);
            pnl_MinimizedDFA.Controls.Add(grp_Name);

            Label lbl_Name = new Label();
            lbl_Name.Width = 80;
            lbl_Name.Location = new Point(10, 10);
            lbl_Name.Text = DFA.Name;
            lbl_Name.Font = new Font(lbl_Name.Font, FontStyle.Bold);
            grp_Name.Controls.Add(lbl_Name);

            for (int i = 0; i < DFA.Letters.Count; i++)
            {
                GroupBox grp_Letter = new GroupBox();
                grp_Letter.Width = 90;
                grp_Letter.Height = 40;
                grp_Letter.Location = new Point(margin + 120 + 90 * i, 0);
                pnl_MinimizedDFA.Controls.Add(grp_Letter);

                Label lbl_Letter = new Label();
                lbl_Letter.Width = 80;
                lbl_Letter.Location = new Point(10, 10);
                lbl_Letter.Text = DFA.Letters[i];
                lbl_Letter.Font = new Font(lbl_Letter.Font, FontStyle.Bold);
                grp_Letter.Controls.Add(lbl_Letter);
            }

            for (int i = 0; i < DFA.States.Count; i++)
            {
                GroupBox grp_FirstState = new GroupBox();
                grp_FirstState.Width = 90;
                grp_FirstState.Height = 40;
                grp_FirstState.Location = new Point(margin + 30, 40 + 40 * i);
                pnl_MinimizedDFA.Controls.Add(grp_FirstState);

                Label lbl_FirstState = new Label();
                lbl_FirstState.Width = 80;
                lbl_FirstState.Location = new Point(10, 10);
                lbl_FirstState.Text = DFA.States[i];
                lbl_FirstState.Font = new Font(lbl_FirstState.Font, FontStyle.Bold);
                if (DFA.FinalStates.Contains(DFA.States[i]))
                    lbl_FirstState.ForeColor = Color.Red;
                grp_FirstState.Controls.Add(lbl_FirstState);

                for (int j = 0; j < DFA.Letters.Count; j++)
                {
                    GroupBox grp_SecondState = new GroupBox();
                    grp_SecondState.Width = 90;
                    grp_SecondState.Height = 40;
                    grp_SecondState.Location = new Point(margin + 120 + 90 * j, 40 + 40 * i);
                    pnl_MinimizedDFA.Controls.Add(grp_SecondState);

                    Label lbl_SecondState = new Label();
                    lbl_SecondState.Width = 80;
                    lbl_SecondState.Location = new Point(10, 10);
                    lbl_SecondState.Text = DFA.TransitionFunction[i, j];
                    lbl_SecondState.Font = new Font(lbl_SecondState.Font, FontStyle.Bold);
                    grp_SecondState.Controls.Add(lbl_SecondState);
                }
            }
        }
    }
}
