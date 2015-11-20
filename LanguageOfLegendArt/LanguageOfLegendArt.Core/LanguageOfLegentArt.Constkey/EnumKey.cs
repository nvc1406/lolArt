namespace LanguageOfLegendArt.Core.LanguageOfLegentArt.Constkey
{
    public class EnumKey
    {
        /// <summary>
        /// Lưu ý code thêm các enum - nếu chưa có nhóm cần thêm enum thì tạo thêm 1 region nữa để chú thích và viết các enum tập trung vào 1 nhóm + viết đúng format loại bỏ các báo lỗi - warning của reshaper.
        /// </summary>
        #region Các enum nhóm dành cho update/delete/insert
        public const int InsertSuccess = 1; // thêm mơi thành công
        public const int InsertFail = 2;// thêm mới thất bại
        public const int UpdateSuccess = 3;//update thành công
        public const int UpdateFail = 4;//update thất bại
        public const int RemoveSuccess = 5;//xóa thành công
        public const int RemoveFail = 6;//xóa thất bại
        #endregion
        #region Các enum nhóm dành cho check trạng thái của user ...
        public const int Running = 1000;//trạng thái đang chạy
        public const int Waiting = 1001;//trạng thái đang chờ/đợi
        public const int Block = 1002;//trạng thái bị khóa
        public const int Deleteted = 1003;//trạng thái bị khóa
        #endregion
        #region Các enum nhóm dành cho check các thông báo lỗi...
        public const int LoginFail = 404;//Đăng nhập thất bại
        public const int LoginSuccess = 202;//Đăng nhập thành công
        public const int EmailFailure = 403;//Sai email
        public const int AccountBlocked = 405; // Lỗi trả về khi tk bị khóa hoặc banned.
        #endregion
        #region Các enum nhóm quyền user

        public static int Administrator = 1;
        public static int Moderator = 2;
        public static int Customer = 3;
        public static int UserTemp = 4;

        #endregion
    }
}
