using ShowRoomForm.Entities;
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

            memberComboBox.DataBindings.Add("DataSource", _viewModel, nameof(_viewModel.Members));
            memberComboBox.ValueMember = nameof(RoomEntity.Id);
            memberComboBox.DisplayMember = nameof(RoomEntity.Name);

            roomGridView.DataBindings.Add("DataSource", _viewModel, nameof(_viewModel.Rooms));

            chart1.DataBindings.Add("DataSource", _viewModel, nameof(_viewModel.RoomsData));
            chart1.Series[0].XValueMember = nameof(RoomEntity.DataDateTime);
            chart1.Series[0].YValueMembers = nameof(RoomEntity.FollowerNum);
        }

        private void showButton_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine(memberComboBox.SelectedValue);

            // datagridview表示
            _viewModel.ShowRoomGridView(Convert.ToInt32(memberComboBox.SelectedValue));

            // chart表示
            _viewModel.ShowChart(Convert.ToInt32(memberComboBox.SelectedValue));
            chart1.DataBind();
        }
    }
}
