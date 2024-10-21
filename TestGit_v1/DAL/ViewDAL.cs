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
        public DataTable GetViewDiemTrungBinhSinhVien()
        {
            // git @github.com: phucnguyenhoank / TestGit_v1.git
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
            catch (Exception ex)
            {
                throw new Exception($"Ngoại lệ mặc định: {ex.Message}");
            }
        }
    }
}
