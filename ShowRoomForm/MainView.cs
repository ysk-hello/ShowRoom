using ShowRoomForm.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShowRoomForm
{
    public partial class MainView : Form
    {
        private MainViewModel _viewModel = new MainViewModel();

        public MainView()
        {
            InitializeComponent();

            dataGridView1.DataBindings.Add("DataSource", _viewModel, nameof(_viewModel.Rooms));
        }

        private void showButton_Click(object sender, EventArgs e)
        {

        }
    }
}
