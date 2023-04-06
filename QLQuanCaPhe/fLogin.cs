﻿using QLQuanCaPhe.DAO;
using QLQuanCaPhe.DTO;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace QLQuanCaPhe
{
    public partial class fLogin : Form
    {
        public fLogin()
        {
            InitializeComponent();
            loadForm();
        }
        //chỉnh sửa giao diện
        void loadForm()
        {
            this.BackgroundImage = Properties.Resources.LoginBackground;
            this.Icon = Properties.Resources.logo;
            panel1.BackColor = Color.Transparent;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txbUserName.Text;
            string password = txbPassword.Text;
            if (Login(username, password))
            {
                Account loginAccount = AccountDAO.Instance.GetAccountByUserName(username);

                fTableManager f = new fTableManager(loginAccount);
                this.Hide();
                f.ShowDialog();
                this.Show();
            }
            else
            {
                MessageBox.Show("Sai tên tài khoản hoặc mật khẩu!");
            }
        }
        //kiểm tra điều kiện đăng nhập
        bool Login(string username, string password)
        {
            return AccountDAO.Instance.Login(username, password);
        }


        private void fLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn thoát không?", "Thông báo", MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.OK)
            {
                e.Cancel = true;
            }
        }
    }
}
