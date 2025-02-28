using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IT488_CheckMates_Checklist
{
    public partial class AddTask : Form
    {
        public AddTask()
        {
            InitializeComponent();
        }
        //pulls the list name from the homepage to allow it to be used as a variable 
        private void AddTask_Load(object sender, EventArgs e)
        {
            listBox.Text = HomePage.instance.listName.Text;
        }
    }
}
