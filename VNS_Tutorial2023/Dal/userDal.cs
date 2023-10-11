using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
    public class userDal
    {
        #region Create
        public bool Create(Table_user userDal)
        {
            //khởi  tạo datacontext
            using (var _context = new BasicTutorialDalDataContext())
            {
                //thực hiện việc thêm một bản ghi mới
                _context.Table_users.InsertOnSubmit(userDal);
                //Phương thức này sẽ thực hiện lưu tất cả các thay đổi đã đánh dấu trên cơ sở dữ liệu
                _context.SubmitChanges();
            }
            return false;
        }
        #endregion
        #region 2-Retrieve
        public List<Table_user> GetAll()
        {
            //khởi  tạo datacontext
            using ( var _context = new BasicTutorialDalDataContext())
            {
                //truy vấn tất cả các bản ghi từ bảng ghi và chuyển thành danh sách List
                return _context.Table_users.ToList();
            }
        }
        public Table_user GetByID(int id)
        {
            using( var _context = new BasicTutorialDalDataContext())
            {
                // tìm kiếm bản ghi đầu tiên trong bảng
                return _context.Table_users.FirstOrDefault(p => p.person_id == id);
            }
        }
        #endregion
        #region Update
        public bool Update(Table_user user)
        {
            //khởi  tạo datacontext
            using ( var _context = new BasicTutorialDalDataContext())
            {
                // tìm kiếm bản ghi đầu tiên trong bảng
                var resuls =  _context.Table_users.FirstOrDefault(u => u.person_id == user.person_id);
                if(resuls != null) //Đoạn mã này kiểm tra xem có tìm thấy bản ghi nào khớp với id hay không
                {
                    resuls.person_id = user.person_id;
                    resuls.username = user.username;
                    resuls.password = user.password;
                    //Phương thức này sẽ thực hiện lưu tất cả các thay đổi đã đánh dấu trên cơ sở dữ liệu
                    _context.SubmitChanges();
                    return true;
                }
                return false;
            }
        }
        #endregion
        #region Delete
        public bool Delete(int id)
        {
            //khởi  tạo datacontext
            using (var _context  = new BasicTutorialDalDataContext())
            {
                // tìm kiếm bản ghi đầu tiên trong bảng
                var resuls = _context.Table_users.FirstOrDefault(d => d.person_id == id);
                if(resuls != null)//kiểm tra xem có tìm thấy bản ghi nào khớp với id hay không
                {
                    //Nếu tìm thấy bản ghi, đoạn mã này sẽ đánh dấu bản ghi
                    //đó để xóa khi thực hiện phương thức
                    _context.Table_users.DeleteOnSubmit(resuls);
                    //Phương thức này sẽ thực hiện lưu tất cả các thay đổi đã đánh dấu trên cơ sở dữ liệu
                    _context.SubmitChanges() ;
                    return true;
                }
                return false;
            }
        }
        #endregion
        #region LoginUser
        public bool LoginUser(string userDal, string passDal)
        {
            using(var _context = new BasicTutorialDalDataContext())
            {
                //Hàm any cho phép chả vể true nếu có ít nhất 1 giá trị 
                return _context.Table_users.Any(login => login.username == userDal && login.password == passDal);
            }
        }
        #endregion
        #region User
        public bool User(string userName)
        {
            using (var _context = new BasicTutorialDalDataContext())
            {
                return _context.Table_users.Any(u => u.username != userName);
            }
        }
        #endregion
        #region Password
        public bool PassWord(string passWord)
        {
            using(var _context = new BasicTutorialDalDataContext())
            {
                return _context.Table_users.Any(p => p.password != passWord);
            }
        }
        #endregion
    }
}
