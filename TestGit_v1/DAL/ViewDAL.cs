using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestGit_v1.DBConnection;

namespace TestGit_v1.DAL
{
    internal class ViewDAL
    {

        /// <summary>
        /// Lấy danh sách điểm trung bình của sinh viên từ view vw_DiemTrungBinhSinhVien.
        /// </summary>
        /// <returns>
        /// Một bảng chứa thông tin về điểm trung bình của sinh viên gồm các cột:
        /// <br>- MaSinhVien</br>
        /// <br>- HoVaTen</br>
        /// <br>- DiemTrungBinh</br>
        /// </returns>
        /// <exception cref="SqlException">
        /// Ném ra khi có lỗi xảy ra trong quá trình kết nối hoặc truy vấn cơ sở dữ liệu.
        /// </exception>
        /// <exception cref="Exception">
        /// Ném ra khi ngoại lệ mặc định khác xảy ra.
        /// </exception>
        public DataTable GetViewDiemTrungBinhSinhVien()
        {
            try
            {
                DataTable danhSachDiemTrungBinh = new DataTable();

                using (SqlConnection connection = new SqlConnection(QLDSVCNTTConnection.connectionString))
                {
                    connection.Open();
                    string query = @"SELECT MaSinhVien, HoVaTen, DiemTrungBinh 
                             FROM vw_DiemTrungBinhSinhVien";

                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                        {
                            adapter.Fill(danhSachDiemTrungBinh);
                        }
                    }
                }

                return danhSachDiemTrungBinh;
            }
            catch (SqlException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new Exception($"Ngoại lệ mặc định: {ex.Message}");
            }
        }
    }
}
