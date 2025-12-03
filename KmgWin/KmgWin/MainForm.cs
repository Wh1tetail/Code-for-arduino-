using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KmgWin
{
    public partial class MainForm : Form
    {
        private readonly string _fullName;
        private readonly string _role;

        public MainForm(string fullName, string role)
        {
            InitializeComponent();
            _fullName = fullName;
            _role = role;

            Text = $"Главное окно – {_fullName} ({_role})";
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnEmployess_Click(object sender, EventArgs e)
        {
            var form = new Employess();
            form.ShowDialog();
        }
    }
}
