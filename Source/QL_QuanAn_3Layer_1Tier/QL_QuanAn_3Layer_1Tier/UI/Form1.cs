using QL_QuanAn_3Layer_1Tier.BUS;
using QL_QuanAn_3Layer_1Tier.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QL_QuanAn_3Layer_1Tier
{
    public partial class Form1 : Form
    {

        #region Properties
        /// <summary>
        /// Đối tượng lưu trữ các nghiệp vụ của quán ăn
        /// </summary>
        QuanAnBUS quanAnBUS = new QuanAnBUS();

        /// <summary>
        ///Biến lưu trữ giá trị ID quán ăn hiện tại
        /// </summary>
        int currIDQuanAn = -1;
        #endregion

        #region Constructor
        /// <summary>
        /// Hàm dựng mặc định
        /// </summary>
        public Form1()
        {
            //Phương thức khởi tại mặc định
            InitializeComponent();
        }
        #endregion

        #region Events
        /// <summary>
        /// Tải dữ liệu vào grid khi Form được load lên
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            this.dgvMonAn.DataSource = quanAnBUS.LoadData().Tables[0].DefaultView;
            this.dgvMonAn.Columns[0].Visible = false;
        }
        /// <summary>
        /// Xử lý thêm quán ăn
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            bool IsOpen = this.rbOpen.Checked;
            QuanAn quanAn = new QuanAn() {
                Name = this.txtName.Text,
                Owner = this.txtOwner.Text,
                Address = this.txtAddress.Text,
                Phone = this.txtPhone.Text,
                IsOpen = IsOpen
            };
            if (quanAnBUS.Insert(quanAn))
            {
                MessageBox.Show("Thêm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.dgvMonAn.DataSource = quanAnBUS.LoadData().Tables[0].DefaultView;
                clearAllTextbox();
            }
            else
            {
                MessageBox.Show("Thêm thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        /// <summary>
        /// Xử lý cập nhật quán ăn
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                bool IsOpen = this.rbOpen.Checked;
                QuanAn quanAn = new QuanAn()
                {
                    Id = this.currIDQuanAn,
                    Name = this.txtName.Text,
                    Owner = this.txtOwner.Text,
                    Address = this.txtAddress.Text,
                    Phone = this.txtPhone.Text,
                    IsOpen = IsOpen
                };
                if (quanAnBUS.Update(quanAn))
                {
                    MessageBox.Show("Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.dgvMonAn.DataSource = quanAnBUS.LoadData().Tables[0].DefaultView;
                    clearAllTextbox();
                }
                else
                {
                    MessageBox.Show("Cập nhật thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        /// <summary>
        /// Xử lý xóa quán ăn
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                bool IsOpen = this.rbOpen.Checked;
                QuanAn quanAn = new QuanAn()
                {
                    Id = this.currIDQuanAn,
                    Name = this.txtName.Text,
                    Owner = this.txtOwner.Text,
                    Address = this.txtAddress.Text,
                    Phone = this.txtPhone.Text,
                    IsOpen = IsOpen
                };
                if (quanAnBUS.Delete(quanAn))
                {
                    MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.dgvMonAn.DataSource = quanAnBUS.LoadData().Tables[0].DefaultView;
                    clearAllTextbox();
                }
                else
                {
                    MessageBox.Show("Xóa thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        /// <summary>
        /// Xử lý binding thông tin lên các field
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvMonAn_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            this.currIDQuanAn = (int)this.dgvMonAn.Rows[e.RowIndex].Cells["Id"].Value;
            this.txtName.Text = this.dgvMonAn.Rows[e.RowIndex].Cells["Name"].Value.ToString();
            this.txtOwner.Text = this.dgvMonAn.Rows[e.RowIndex].Cells["Owner"].Value.ToString();
            this.txtAddress.Text = this.dgvMonAn.Rows[e.RowIndex].Cells["Address"].Value.ToString();
            this.txtPhone.Text = this.dgvMonAn.Rows[e.RowIndex].Cells["Phone"].Value.ToString();
            bool check = (bool)this.dgvMonAn.Rows[e.RowIndex].Cells["IsOpen"].Value;
            if (check == true)
            {
                this.rbOpen.Checked = true;
            }
            else
            {
                this.rbClose.Checked = true;
            };
        }
        #endregion

        #region Methods

        /// <summary>
        /// Xử lý xóa trắng các textbox
        /// </summary>
        private void clearAllTextbox()
        {
            this.txtAddress.Clear();
            this.txtName.Clear();
            this.txtOwner.Clear();
            this.txtPhone.Clear();
            this.rbOpen.Checked = false;
            this.rbClose.Checked = false;
        }
        #endregion


    }
}
