﻿using BussinessLayer;
using DataAccessLayer;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quanlyhocsinh
{
    public partial class formTrinhDo : DevExpress.XtraEditors.XtraForm
    {
        public formTrinhDo()
        {
            InitializeComponent();
        }
        bool them;
        TrinhDo trinhDo;
        int id = 0;
        void LoadData()
        {
            trinhDo = new TrinhDo();
            gcDanhSach.DataSource = trinhDo.getList();
            gvDanhSach.OptionsBehavior.Editable = false;
        }
        void ShowHide(bool kt)
        {
            btnLuu.Enabled = !kt;
            btnHuy.Enabled = !kt;
            btnThem.Enabled = kt;
            btnSua.Enabled = kt;
            btnXoa.Enabled = kt;
            btnDong.Enabled = kt;
            btnIn.Enabled = kt;
            txtTenTD.Enabled = !kt;
        }
        void SaveData()
        {
            if (them)
            {
                tbl_TrinhDo td = new tbl_TrinhDo();
                td.TenTD = txtTenTD.Text;
                trinhDo.Add(td);
            }
            else
            {
                tbl_TrinhDo td = trinhDo.getItem(id);
                td.TenTD = txtTenTD.Text;
                trinhDo.Update(td);
            }
        }
       
        private void gvDanhSach_Click(object sender, EventArgs e)
        {
            if (gvDanhSach.RowCount > 0)
            {
                id = int.Parse(gvDanhSach.GetFocusedRowCellValue("MaTD").ToString());
                txtTenTD.Text = gvDanhSach.GetFocusedRowCellValue("TenTD").ToString();

            }
        }
        private void gvDanhSach_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.Column.Name == "DeletedBy" && e.CellValue != null)
            {
                Image img = Properties.Resources.Cancel_16x16;

                e.Graphics.DrawImage(img, e.Bounds.X, e.Bounds.Y);
                e.Handled = true;
            }
        }
        private void formTrinhDo_Load(object sender, EventArgs e)
        {
            ShowHide(true);
            trinhDo = new TrinhDo();
            LoadData();
        }
        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ShowHide(false);
            them = true;
        }

        private void btnSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ShowHide(false);
            them = false;
        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (MessageBox.Show("Bạn chắc chắn có muốn xoá không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                trinhDo.Delete(id, Common.UserStatic.UID);
            }
            LoadData();
        }

        private void btnLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SaveData();
            LoadData();
            ShowHide(true);
        }

        private void btnHuy_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ShowHide(true);
        }

        private void btnIn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void btnDong_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }
       

    }
}