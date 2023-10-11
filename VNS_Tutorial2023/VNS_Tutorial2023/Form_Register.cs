using Dal;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VNS_Tutorial2023
{
    public partial class Form_Register : DevExpress.XtraEditors.XtraForm
    {
        private MsgBox msgBox = new MsgBox();
        public Form_Register()
        {
            InitializeComponent();
            this.Load += Form_Load;

            this.btnRegister.Click += BtnRegister_Click;

            this.btnCancel.Click += BtnCancel_Click;
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            if(msgBox.Oke_Cancel_ShowMessage_Question("Bạn có muốn quay lại trang đăng nhập hay không") == true)
            {
                Form_Login form_Login = new Form_Login();
                this.Hide();
                form_Login.ShowDialog();
            }
            else
            {
                return;
            }
        }

        private void BtnRegister_Click(object sender, EventArgs e)
        {
            //MsgBox msgBox = new MsgBox();
            if (usernameTextEdit.Text != string.Empty && passwordTextEdit.Text != string.Empty)
            {
                if (btnCheckButton.Checked)
                {
                    try
                    {
                        //khai bao DAL
                        var userDal = new userDal();

                        // Kiểm tra xem người dùng đã tồn tại trong cơ sở dữ liệu hay chưa
                        if (userDal.LoginUser(usernameTextEdit.Text, passwordTextEdit.Text))
                        {
                            msgBox.ShowWarning("Người dùng đã tồn tại. Vui lòng chọn tên người dùng khác.");
                        }
                        else
                        {
                            if (passwordTextEdit.Text == confirmPasswordTextEdit.Text)
                            {
                                userDal.Create(new Table_user()
                                {
                                    username = usernameTextEdit.Text,
                                    password = passwordTextEdit.Text,
                                });
                                msgBox.ShowInfo("Đăng ký thành công");

                                usernameTextEdit.Text = string.Empty;
                                passwordTextEdit.Text = string.Empty;
                                confirmPasswordTextEdit.Text = string.Empty;
                                usernameTextEdit.Focus();
                            }
                            else
                            {
                                msgBox.ShowInfo("mật khẩu của bạn không trùng khớp");
                                passwordTextEdit.Text = string.Empty;
                                confirmPasswordTextEdit.Text = string.Empty;
                                usernameTextEdit.Focus();
                            }
                        }
                    }
                    catch (Exception)
                    {
                        msgBox.ShowWarning("Lỗi kết nối database");
                    }
                }
                else
                {
                    msgBox.ShowInfo("I agree to the terms of service");
                }
            }
            else
            {
                msgBox.ShowWarning("Vui lòng nhập đầy đủ thông tin thông tin user name và pasword");
            }
        }

        private void Form_Load(object sender, EventArgs e)
        {
        }
    }
}