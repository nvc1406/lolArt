using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using LanguageOfLegendArt.Core.LanguageOfLegendArt.Controller.LogException;
using LanguageOfLegendArt.Core.LanguageOfLegentArt.Constkey;
using LanguageOfLegendArt.Core.UnitOfWork;
namespace LanguageOfLegendArt.Core.LanguageOfLegendArt.Controller.User
{   
    public class UserController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserResponsitory _userResponsitory;
        private readonly LogExceptionController _logException;
        public UserController()
        {
            _unitOfWork = new UnitOfWork.UnitOfWork();
            _userResponsitory = new UserResponsitory(_unitOfWork);
            _logException = new LogExceptionController();
        }
        public  List<Model.User> GetAll()
        {
            var lstData = _userResponsitory.GetAll();
            return lstData.ToList();
        }
        /// <summary>
        /// Hàm lấy User theo Email.
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public  Model.User GetByEmail(string email)
        {
            var objData = _userResponsitory.GetMany(t => t.Email.Equals(email)).FirstOrDefault();
            return objData;
        }
        /// <summary>
        /// Hàm kiểm tra khi người dùng login
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public  bool DoLogin(string email, string password)
        {
            var passwordEcrypt = Md5Hash(password);
            var objData = _userResponsitory.GetMany(t => t.Email.Equals(email)&& t.Passwords.Equals(passwordEcrypt)).FirstOrDefault();
            return objData != null;
        }

        public Model.User GetById(int id)
        {
            var objData = _userResponsitory.GetMany(t => t.UserId == id).FirstOrDefault();
            return objData;
        }
        public  Model.User GetByNickName(string nickname)
        {
            var objData = _userResponsitory.GetMany(t => t.NickName.Equals(nickname)).FirstOrDefault();
            return objData;
        }
        /// <summary>
        /// Hàm dùng trong tìm kiếm - tìm các user theo nick name. (contains)
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public  List<Model.User> GetAllUserByNickName(string name)
        {
            var lstData = _userResponsitory.GetAll().Where(t => t.NickName.ToLower().Contains(name.ToLower())).ToList();
            return lstData;
        }
        public  List<Model.User> GetAllByEmail(string email)
        {
            var lstData = _userResponsitory.GetAll().Where(t => t.Email.Contains(email)).ToList();
            return lstData;
        }
        /// <summary>
        /// Hàm encrypt md5 password
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public  string Md5Hash(string text)
        {
            MD5 md5 = new MD5CryptoServiceProvider();

            //compute hash from the bytes of text
            md5.ComputeHash(Encoding.ASCII.GetBytes(text));

            //get hash result after compute it
            byte[] result = md5.Hash;

            StringBuilder strBuilder = new StringBuilder();
            foreach (byte t in result)
            {
                //change it into 2 hexadecimal digits
                //for each byte
                strBuilder.Append(t.ToString("x2"));
            }
            return strBuilder.ToString();
        }
        public int CreateUser(Model.User objUser)
        {
            int iNotifi = 0;
            try
            {
                if (objUser != null)
                {
                    if (!CheckEmailExist(objUser.Email) && !CheckNickNameExist(objUser.NickName))
                    {
                        _userResponsitory.Insert(objUser);
                        iNotifi = EnumKey.InsertSuccess;
                    }
                }
            }
            catch (Exception ex)
            {
                var mes = GetType() + ex.Message;
                _logException.InsertException(new Model.LogException { Exception = mes, Time = DateTime.Now });
                iNotifi = EnumKey.InsertSuccess;
            }
            return iNotifi;
        }
        public int UpdatePropertise(Model.User obUser)
        {
            int iNotifi = 0;
            try
            {
                if (obUser != null)
                {
                    _userResponsitory.Update(obUser);
                    iNotifi = EnumKey.UpdateSuccess;
                }
            }
            catch (Exception ex)
            {
                var mes = GetType() + ex.Message;
                _logException.InsertException(new Model.LogException { Exception = mes, Time = DateTime.Now });
                iNotifi = EnumKey.UpdateSuccess;
            }
            return iNotifi;
        }
        /// <summary>
        /// Check email tồn tại
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public  bool CheckEmailExist(string email)
        {
            var objUser = _userResponsitory.GetMany(t => t.Email.Equals(email)).FirstOrDefault();
            return objUser != null;
        }
        /// <summary>
        /// Check nick name tồn tại
        /// </summary>
        /// <param name="nickName"></param>
        /// <returns></returns>
        public  bool CheckNickNameExist(string nickName)
        {
            var objUser = _userResponsitory.GetMany(t => t.NickName.ToLower().Equals(nickName.ToLower())).FirstOrDefault();
            return objUser != null;
        }
    }
}
