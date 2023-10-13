using Dal;
using DevExpress.XtraBars.Docking2010.Views.WindowsUI;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Mask;
using System;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace VNS_Tutorial2023
{

    public partial class Form_Login : DevExpress.XtraEditors.XtraForm
    {       
        private int failedLogin = 0;//Khai báo biến kiểm tra số lần login thất bại
        private DateTime lockoutTime;

        private string ConectionString = Connection.ConectionString;
        SqlConnection conn = new SqlConnection();
        private MsgBox msgBox = new MsgBox();
        public Form_Login()
        {
            InitializeComponent();

            this.Load += Form1_Load;

            this.btnLogin.Click += BtnLogin_Click;

            this.btnCancel.Click += BtnCancel_Click;

            this.lnkRegister.Click += BtnLnkRegister;

            // Đặt khoảng thời gian giữa các tick là 1 giây
            this.realTimer.Interval = 1000;
            this.realTimer.Tick += RealTimer_Tick;
        }
        
        private void RealTimer_Tick(object sender, EventArgs e)
        {
            //cấu hình biến lockoutTime ở events login tăng 1 phút nếu login sai quá 5 lần 
            //Nếu thời gian lockoutTime lớn hơn thời gian hiện tại thì 
            //có nghĩa người dùng đang bị tạm khóa tài khoản
            if (lockoutTime > DateTime.Now)
            {
                //tính thời gian còn lại của người dùng bị khóa
                TimeSpan remainingTime = lockoutTime - DateTime.Now;
                timerLable.Text = remainingTime.ToString(@"mm\:ss");
                btnLogin.Enabled = false;
                lnkRegister.Enabled = false;
            }
            else
            {
                realTimer.Stop();
                btnLogin.Enabled = true;
                lnkRegister.Enabled = true;
                failedLogin = 0;
                timerLable.Text = "";
            }
        }

        private void BtnLnkRegister(object sender, System.EventArgs e)
        {
            Form_Register form_Register = new Form_Register();
            this.Hide();
            form_Register.Show();
        }

        private void BtnCancel_Click(object sender, System.EventArgs e)
        {
            if (msgBox.Oke_Cancel_ShowMessage_Question("Bạn có muốn thoát trang đăng nhập hay không") == true)
            {
                this.Dispose();
            }
            else
            {
                return;
            }
        }

        private void BtnLogin_Click(object sender, System.EventArgs e)
        {           
            if (UsernameTextEdit.Text != string.Empty && PasswordTextEdit.Text != string.Empty)
            {
                try
                {
                    //khởi tạo datacontext
                    userDal userDal = new userDal();
                    if (userDal.LoginUser(UsernameTextEdit.Text, PasswordTextEdit.Text))
                    {
                        msgBox.ShowInfo("Đăng nhập thành công");
                        failedLogin = 0;
                        Form_Main form_Main = new Form_Main();
                        this.Hide();
                        form_Main.ShowDialog();
                    }
                    else
                    {
                        failedLogin++;
                        if (failedLogin >= 5)
                        {
                            // Khóa tài khoản trong 1 phút
                            lockoutTime = DateTime.Now.AddMinutes(1);
                            msgBox.ShowError("đăng nhập sai quá 5 lần, Tài khoản đã bị khóa" +
                                " tạm thời. Vui lòng thử lại sau 60 giây");
                            realTimer.Start(); // Bắt đầu đếm ngược

                            //// Nếu muốn vô hiệu hóa toàn bộ button trong 1 form
                            //foreach(var button in this.Controls.OfType<Button>())
                            //{
                            //    button.Enabled = false;
                            //}
                        }
                        else
                        {
                            if (userDal.User(UsernameTextEdit.Text) && userDal.PassWord(PasswordTextEdit.Text))
                            {
                                msgBox.ShowWarning("Tài khoản hoặc mật khẩu không chính xác");
                                //msgBox.AlertControls("New message","ahihi","Tài khoản hoặc mật khẩu không chính xác");
                            }
                            else
                            {
                                //Nếu giá trị UsernameTextEdit.Text không bằng gia trị username trong database báo lỗi
                                if (userDal.User(UsernameTextEdit.Text))
                                {
                                    msgBox.ShowWarning("Tài khoản không tồn tại!");
                                    UsernameTextEdit.Text = string.Empty;
                                    UsernameTextEdit.Focus();
                                }
                                else //ngược lại giá trị PasswordTextEdit.Text không bằng gia trị password trong database báo lỗi
                                {
                                    msgBox.ShowWarning("Mật khẩu không chính xác");
                                    PasswordTextEdit.Text = string.Empty;
                                    PasswordTextEdit.Focus();
                                }
                            }
                        }                        
                    }
                }
                catch (System.Exception)
                {

                    msgBox.ShowWarning("Lỗi kết nối đến máy chủ");
                }
            }
            else
            {
                msgBox.ShowWarning("Vui lòng nhập thông tin username và password");
            }
            //if (UsernameTextEdit.Text != string.Empty && PasswordTextEdit.Text != string.Empty)
            //{
            //    try
            //    {
            //        string query = "select * from Table_user where username='" +UsernameTextEdit.Text +
            //            "' and password='" +PasswordTextEdit.Text + "'";

            //        SqlCommand cmd = new SqlCommand(query, conn);
            //        cmd.Parameters.AddWithValue("@username", UsernameTextEdit.Text);
            //        cmd.Parameters.AddWithValue("@password", PasswordTextEdit.Text);
            //        conn.Open();

            //        SqlDataReader sqlDataReader = cmd.ExecuteReader();
            //        conn.Close();
            //        if (sqlDataReader != null)
            //        {
            //            //msgBox.Notifications("Your license is activated. You can use DXperience");
            //            Form_Main  form_Main = new Form_Main();
            //            this.Hide();
            //            form_Main.ShowDialog();
            //            this.Dispose();
            //        }
            //        else
            //        {
            //            msgBox.ShowInfo("Tên người dùng hoặc mật khẩu không chính xác");
            //        }
            //    }
            //    catch (System.Exception)
            //    {

            //        msgBox.ShowInfo("Lỗi kết nối đến máy chủ");
            //    }
            //}
            //else
            //{
            //    msgBox.ShowInfo("Vui lòng nhập thông tin username và password");
            //}
        }

        private void Form1_Load(object sender, System.EventArgs e)
        {
            conn.ConnectionString = ConectionString;
        }
    }
}
