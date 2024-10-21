using System.Data.SqlClient;
using TestGit_v1.DBConnection;

namespace TestGit_v1
{
    public partial class Form1 : Form
    {
        public Form1()
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
    }
}
