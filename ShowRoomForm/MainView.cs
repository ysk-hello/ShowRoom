using ShowRoomForm.Entities;
using ShowRoomForm.Helper;
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

            startDateTimePicker.DataBindings.Add("Value", _viewModel, nameof(_viewModel.StartDate));
            startDateTimePicker.MaxDate = DateTime.Today;
            endDateTimePicker.DataBindings.Add("Value", _viewModel, nameof(_viewModel.EndDate));
            endDateTimePicker.MaxDate = DateTime.Today;

            roomGridView.DataBindings.Add("DataSource", _viewModel, nameof(_viewModel.Rooms));

            chart1.DataBindings.Add("DataSource", _viewModel, nameof(_viewModel.RoomsData));
            chart1.Series[0].XValueMember = nameof(RoomEntity.DataDateTime);
            chart1.Series[0].YValueMembers = nameof(RoomEntity.FollowerNum);
        }

        private void UpdateDataGridViewCellColor(DataGridView dataGridView)
        {
            foreach(DataGridViewRow row in dataGridView.Rows)
            {
                var room = row.DataBoundItem as Room;

                if(room.ChangeFromPreviousDay > 0)
                {
                    // 増加の場合
                    row.Cells["ChangeFromPreviousDay"].Style.BackColor = Color.LightPink;
                }
                else if(room.ChangeFromPreviousDay < 0)
                {
                    // 減少の場合
                    row.Cells["ChangeFromPreviousDay"].Style.BackColor = Color.LightBlue;
                }
            }
        }

        private void showButton_Click(object sender, EventArgs e)
        {
            try
            {
                // 日付のチェック
                startDateTimePicker.Value.Before(endDateTimePicker.Value);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            System.Diagnostics.Debug.WriteLine(memberComboBox.SelectedValue);

            // datagridview表示
            _viewModel.ShowRoomGridView(Convert.ToInt32(memberComboBox.SelectedValue));

            // datagridviewのセルの色を変える
            UpdateDataGridViewCellColor(roomGridView);

            // chart表示
            _viewModel.ShowChart(Convert.ToInt32(memberComboBox.SelectedValue));
            chart1.DataBind();
        }
    }
}
