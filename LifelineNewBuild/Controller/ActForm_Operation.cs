using System;
using System.Windows.Forms;

namespace LifelineNewBuild
{
    public partial class ActForm : Form
    {
        private void TambahData()
        {
            // act user id (dummy)
            string act_user_id = currentUser;
            string act_name = tbNama.Text;
            DateTime act_date_datetime = clTanggal.Value.Date;
            string act_date_string = act_date_datetime.ToString("dd-MM-yyyy");
            string act_desc = tbDesk.Text;

            con.Open();
            cmd.Connection = con;
            cmd.CommandText = string.Format(
                "INSERT INTO activity(act_user_id, act_name, act_desc, act_date)" +
                "VALUES ('{0}', '{1}', '{2}', '{3}');", act_user_id, act_name, act_desc, act_date_string);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        private void EditData()
        {
            string act_name = tbNama.Text;
            DateTime act_date_datetime = clTanggal.Value.Date;
            string act_date_string = act_date_datetime.ToString("dd-MM-yyyy");
            string act_desc = tbDesk.Text;

            con.Open();
            cmd.Connection = con;
            cmd.CommandText = string.Format(
                "UPDATE activity " +
                "SET act_name = '{0}', act_date = '{1}', act_desc = '{2}' " +
                "WHERE act_id = '{3}'",
                act_name, act_date_string, act_desc, currentAct);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        private void DeleteData()
        {
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = string.Format(
                "DELETE FROM activity " +
                "WHERE act_id = '{0}'", currentAct);
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}
