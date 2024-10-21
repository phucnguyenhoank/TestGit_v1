using System.Data.SqlClient;
using TestGit_v1.DAL;
using TestGit_v1.DBConnection;

namespace TestGit_v1
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            try
            {
                if (QLDSVCNTTConnection.TestConnection() == 0)
                {
                    MessageBox.Show("Kết nối thành công", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Kết nối thất bại", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (SqlException sqlEx)
            {
                MessageBox.Show(sqlEx.Message, "Lỗi từ SQL Server btnConnect_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi btnConnect_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGet_Click(object sender, EventArgs e)
        {
            try
            {
                ViewDAL viewDAL = new ViewDAL();
                dgvGotData.DataSource = viewDAL.GetViewDiemTrungBinhSinhVien();
            }
            catch (SqlException sqlEx)
            {
                MessageBox.Show(sqlEx.Message, "Lỗi từ SQL Server btnGet_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi btnGet_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
