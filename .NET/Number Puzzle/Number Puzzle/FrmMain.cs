using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Number_Puzzle
{
    public partial class FrmMain : Form
    {
        private Button btnNumber;
        private readonly List<int> randomList = new List<int>();
        private readonly Random random = new Random();
        public FrmMain()
        {
            InitializeComponent();
            InitForm();
        }

        private void InitForm()
        {
            AddCloseButton();
            int iCount = 1;

            for (int iCol = 0; iCol < 4; iCol++)
            {
                for (int iRow = 0; iRow < 4; iRow++)
                {
                    btnNumber = new Button()
                    {
                        Name = $"btn{iCount}",
                        Text = $"{iCount}",
                        Dock = DockStyle.Fill,
                    };
                    if (btnNumber.Name != "btn16")
                        tblControls.Controls.Add(btnNumber, iRow, iCol);

                    iCount++;
                }
            }
        }

        private void ShuffleNumbers()
        {
            int iRand = GetRandomNumber();
            Button tmpButtonControl = (Button)tblControls.Controls[iRand];
            int iCol = tblControls.GetColumn(tmpButtonControl);
            int iRow = tblControls.GetRow(tmpButtonControl);
            tblControls.Controls.Add(tmpButtonControl, 3, 3);

            for (int iCount = 0; iCount < 12; iCount++)
            {
                iRand = GetRandomNumber();
                tmpButtonControl = (Button)tblControls.Controls[iRand];
                int iCol1 = tblControls.GetColumn(tmpButtonControl);
                int iRow1 = tblControls.GetRow(tmpButtonControl);
                tblControls.Controls.Remove(tmpButtonControl);
                tblControls.Controls.Add(tmpButtonControl, iCol, iRow);
                iCol = iCol1;
                iRow = iRow1;
            }
        }

        private int GetRandomNumber()
        {
            int iRandom = random.Next(0, 15);
            while (randomList.Contains(iRandom))
            {
                iRandom = random.Next(0, 15);
            }
            randomList.Add(iRandom);
            return iRandom;
        }

        private void AddCloseButton()
        {
            Button btnClose = new Button();
            btnClose.Click += (o, i) => Close();
            Controls.Add(btnClose);
            CancelButton = btnClose;
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            ShuffleNumbers();
        }
    }
}
