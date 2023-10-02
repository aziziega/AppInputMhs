using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AplikasiInputDataMahasiswa
{
    
    
    public partial class Form1 : Form
    {
        private List<Mahasiswa> list = new List<Mahasiswa>();
        public Form1()
        {
            InitializeComponent();
            InisialisasiListView();
        }
        private void TampilkanData()
        {
            // kosongkan data listview
            lvwMahasiswa.Items.Clear();
            foreach(var mhs in list)
            {
                var noUrut = lvwMahasiswa.Items.Count + 1;

                var item = new ListViewItem(noUrut.ToString());
                item.SubItems.Add(mhs.Nim);
                item.SubItems.Add(mhs.Nama);
                item.SubItems.Add(mhs.Kelas);
                item.SubItems.Add(mhs.Nilai.ToString());
                item.SubItems.Add(mhs.NilaiHuruf);

                lvwMahasiswa.Items.Add(item);
            }
        }

        private void InisialisasiListView()
        {
            lvwMahasiswa.View = View.Details;
            lvwMahasiswa.FullRowSelect = true;
            lvwMahasiswa.GridLines = true;

            lvwMahasiswa.Columns.Add("No ", 30, HorizontalAlignment.Center);
            lvwMahasiswa.Columns.Add("Nim ", 91, HorizontalAlignment.Center);
            lvwMahasiswa.Columns.Add("Nama", 200, HorizontalAlignment.Center);
            lvwMahasiswa.Columns.Add("Kelas", 70, HorizontalAlignment.Center);
            lvwMahasiswa.Columns.Add("Nilai", 50, HorizontalAlignment.Center);
            lvwMahasiswa.Columns.Add("Huruf", 50, HorizontalAlignment.Center);
        }
        private void ResetForm()
        {
            txtNim.Clear();
            txtNama.Clear();
            txtKelas.Clear();
            txtNilai.Text = "0";
            txtNim.Focus();
        }
        private bool NumericOnly(KeyPressEventArgs e)
        {
            var strValid = "0123456789";
            if(!(e.KeyChar == Convert.ToChar(Keys.Back)))
            {
                // inputan selain angka
                if(strValid.IndexOf(e.KeyChar) < 0)
                {
                    return true;
                }
                return false;
            } 
            else 
                return false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            // membuat objek Mahasiswa
            Mahasiswa mhs = new Mahasiswa();
            mhs.Nim = txtNim.Text;
            mhs.Nama = txtNama.Text;
            mhs.Kelas = txtKelas.Text;  
            mhs.Nilai = int.Parse(txtNilai.Text);

            if (mhs.Nilai >= 81)
            {
                mhs.NilaiHuruf = "A";
            }
            else if (mhs.Nilai > 60)
            {
                mhs.NilaiHuruf = "B";
            }
            else if (mhs.Nilai > 40)
            {
                mhs.NilaiHuruf = "C";
            }
            else if (mhs.Nilai > 20)
            {
                mhs.NilaiHuruf = "D";
            }
            else
            {
                mhs.NilaiHuruf = "E";
            }


            list.Add(mhs);
            var msg = "Data Mahasiswa berhasil di simpan.";

            MessageBox.Show(msg, "informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ResetForm();
        }

        private void lvwMahasiswa_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ResetForm();
        }

        private void txtNilai_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = NumericOnly(e);
        }

        private void btnTampilkanData_Click(object sender, EventArgs e)
        {
            TampilkanData();
        }

        private void btnHapus_Click(object sender, EventArgs e)
        {
            if(lvwMahasiswa.SelectedItems.Count > 0)
            {
                var konfirmasi = MessageBox.Show("Apakah data Mahasiswa ingin dihapus?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                if(konfirmasi == DialogResult.Yes)
                {
                    var index = lvwMahasiswa.SelectedIndices[0];

                    list.RemoveAt(index);

                    TampilkanData();
                }
            }
            else
            {
                MessageBox.Show("Data Mahasiswa belum dipilih !!!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void txtNilai_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
