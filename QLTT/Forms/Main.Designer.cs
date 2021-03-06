﻿namespace QLTT.Forms
{
    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.tàiKhoảnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thayĐổiThôngTinToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.đăngXuấtToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quảnLýKhoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quảnLýNhàCungCấpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quảnLýKháchHàngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quảnLýHóaĐơnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnAddSP = new System.Windows.Forms.Button();
            this.dvgSanpham = new System.Windows.Forms.DataGridView();
            this.MaSP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenSP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GiaBan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CongDungSP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoLuongTaiCuaHang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.delete = new System.Windows.Forms.DataGridViewButtonColumn();
            this.edit = new System.Windows.Forms.DataGridViewButtonColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.btnPXuat = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dvgSanpham)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.menuStrip1.Font = new System.Drawing.Font("Arial Narrow", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tàiKhoảnToolStripMenuItem,
            this.quảnLýKhoToolStripMenuItem,
            this.quảnLýNhàCungCấpToolStripMenuItem,
            this.quảnLýKháchHàngToolStripMenuItem,
            this.quảnLýHóaĐơnToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1176, 30);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "Tài khoản";
            // 
            // tàiKhoảnToolStripMenuItem
            // 
            this.tàiKhoảnToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.thayĐổiThôngTinToolStripMenuItem,
            this.đăngXuấtToolStripMenuItem});
            this.tàiKhoảnToolStripMenuItem.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tàiKhoảnToolStripMenuItem.Name = "tàiKhoảnToolStripMenuItem";
            this.tàiKhoảnToolStripMenuItem.Size = new System.Drawing.Size(109, 26);
            this.tàiKhoảnToolStripMenuItem.Text = "Tài Khoản";
            // 
            // thayĐổiThôngTinToolStripMenuItem
            // 
            this.thayĐổiThôngTinToolStripMenuItem.Name = "thayĐổiThôngTinToolStripMenuItem";
            this.thayĐổiThôngTinToolStripMenuItem.Size = new System.Drawing.Size(242, 26);
            this.thayĐổiThôngTinToolStripMenuItem.Text = "Thay đổi thông tin";
            this.thayĐổiThôngTinToolStripMenuItem.Click += new System.EventHandler(this.thayĐổiThôngTinToolStripMenuItem_Click);
            // 
            // đăngXuấtToolStripMenuItem
            // 
            this.đăngXuấtToolStripMenuItem.Name = "đăngXuấtToolStripMenuItem";
            this.đăngXuấtToolStripMenuItem.Size = new System.Drawing.Size(242, 26);
            this.đăngXuấtToolStripMenuItem.Text = "Đăng xuất";
            this.đăngXuấtToolStripMenuItem.Click += new System.EventHandler(this.đăngXuấtToolStripMenuItem_Click);
            // 
            // quảnLýKhoToolStripMenuItem
            // 
            this.quảnLýKhoToolStripMenuItem.Font = new System.Drawing.Font("Arial", 10.8F);
            this.quảnLýKhoToolStripMenuItem.Name = "quảnLýKhoToolStripMenuItem";
            this.quảnLýKhoToolStripMenuItem.Size = new System.Drawing.Size(122, 26);
            this.quảnLýKhoToolStripMenuItem.Text = "Quản lý kho";
            this.quảnLýKhoToolStripMenuItem.Click += new System.EventHandler(this.quảnLýKhoToolStripMenuItem_Click);
            // 
            // quảnLýNhàCungCấpToolStripMenuItem
            // 
            this.quảnLýNhàCungCấpToolStripMenuItem.Font = new System.Drawing.Font("Arial", 10.8F);
            this.quảnLýNhàCungCấpToolStripMenuItem.Name = "quảnLýNhàCungCấpToolStripMenuItem";
            this.quảnLýNhàCungCấpToolStripMenuItem.Size = new System.Drawing.Size(204, 26);
            this.quảnLýNhàCungCấpToolStripMenuItem.Text = "Quản lý nhà cung cấp";
            this.quảnLýNhàCungCấpToolStripMenuItem.Click += new System.EventHandler(this.quảnLýNhàCungCấpToolStripMenuItem_Click);
            // 
            // quảnLýKháchHàngToolStripMenuItem
            // 
            this.quảnLýKháchHàngToolStripMenuItem.Font = new System.Drawing.Font("Arial", 10.8F);
            this.quảnLýKháchHàngToolStripMenuItem.Name = "quảnLýKháchHàngToolStripMenuItem";
            this.quảnLýKháchHàngToolStripMenuItem.Size = new System.Drawing.Size(187, 26);
            this.quảnLýKháchHàngToolStripMenuItem.Text = "Quản lý khách hàng";
            this.quảnLýKháchHàngToolStripMenuItem.Click += new System.EventHandler(this.quảnLýKháchHàngToolStripMenuItem_Click);
            // 
            // quảnLýHóaĐơnToolStripMenuItem
            // 
            this.quảnLýHóaĐơnToolStripMenuItem.Font = new System.Drawing.Font("Arial", 10.8F);
            this.quảnLýHóaĐơnToolStripMenuItem.Name = "quảnLýHóaĐơnToolStripMenuItem";
            this.quảnLýHóaĐơnToolStripMenuItem.Size = new System.Drawing.Size(161, 26);
            this.quảnLýHóaĐơnToolStripMenuItem.Text = "Quản lý hóa đơn";
            this.quảnLýHóaĐơnToolStripMenuItem.Click += new System.EventHandler(this.quảnLýHóaĐơnToolStripMenuItem_Click);
            // 
            // btnAddSP
            // 
            this.btnAddSP.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(123)))), ((int)(((byte)(255)))));
            this.btnAddSP.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddSP.FlatAppearance.BorderSize = 0;
            this.btnAddSP.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddSP.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddSP.ForeColor = System.Drawing.Color.White;
            this.btnAddSP.Location = new System.Drawing.Point(12, 139);
            this.btnAddSP.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAddSP.Name = "btnAddSP";
            this.btnAddSP.Size = new System.Drawing.Size(148, 52);
            this.btnAddSP.TabIndex = 4;
            this.btnAddSP.Text = "Thêm mới";
            this.btnAddSP.UseVisualStyleBackColor = false;
            this.btnAddSP.Click += new System.EventHandler(this.btnAddSP_Click);
            // 
            // dvgSanpham
            // 
            this.dvgSanpham.AllowUserToAddRows = false;
            this.dvgSanpham.AllowUserToDeleteRows = false;
            this.dvgSanpham.AllowUserToResizeColumns = false;
            this.dvgSanpham.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dvgSanpham.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.dvgSanpham.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dvgSanpham.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dvgSanpham.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaSP,
            this.TenSP,
            this.GiaBan,
            this.CongDungSP,
            this.SoLuongTaiCuaHang,
            this.delete,
            this.edit});
            this.dvgSanpham.Location = new System.Drawing.Point(12, 197);
            this.dvgSanpham.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dvgSanpham.Name = "dvgSanpham";
            this.dvgSanpham.ReadOnly = true;
            this.dvgSanpham.RowHeadersWidth = 51;
            this.dvgSanpham.RowTemplate.Height = 24;
            this.dvgSanpham.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dvgSanpham.ShowEditingIcon = false;
            this.dvgSanpham.Size = new System.Drawing.Size(1152, 390);
            this.dvgSanpham.TabIndex = 2;
            this.dvgSanpham.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dvgSanpham_CellClick);
            // 
            // MaSP
            // 
            this.MaSP.HeaderText = "Mã sản phẩm";
            this.MaSP.MinimumWidth = 6;
            this.MaSP.Name = "MaSP";
            this.MaSP.ReadOnly = true;
            // 
            // TenSP
            // 
            this.TenSP.HeaderText = "Tên sản phẩm";
            this.TenSP.MinimumWidth = 6;
            this.TenSP.Name = "TenSP";
            this.TenSP.ReadOnly = true;
            // 
            // GiaBan
            // 
            this.GiaBan.HeaderText = "Công dụng sản phẩm";
            this.GiaBan.MinimumWidth = 6;
            this.GiaBan.Name = "GiaBan";
            this.GiaBan.ReadOnly = true;
            // 
            // CongDungSP
            // 
            this.CongDungSP.HeaderText = "Giá bán";
            this.CongDungSP.MinimumWidth = 6;
            this.CongDungSP.Name = "CongDungSP";
            this.CongDungSP.ReadOnly = true;
            // 
            // SoLuongTaiCuaHang
            // 
            this.SoLuongTaiCuaHang.HeaderText = "Số lượng tải của hàng";
            this.SoLuongTaiCuaHang.MinimumWidth = 6;
            this.SoLuongTaiCuaHang.Name = "SoLuongTaiCuaHang";
            this.SoLuongTaiCuaHang.ReadOnly = true;
            // 
            // delete
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.delete.DefaultCellStyle = dataGridViewCellStyle1;
            this.delete.HeaderText = "";
            this.delete.MinimumWidth = 6;
            this.delete.Name = "delete";
            this.delete.ReadOnly = true;
            this.delete.Text = "Sửa";
            this.delete.UseColumnTextForButtonValue = true;
            // 
            // edit
            // 
            this.edit.HeaderText = "";
            this.edit.MinimumWidth = 6;
            this.edit.Name = "edit";
            this.edit.ReadOnly = true;
            this.edit.Text = "Xóa";
            this.edit.UseColumnTextForButtonValue = true;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Arial", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(0, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1176, 62);
            this.label1.TabIndex = 5;
            this.label1.Text = "Sản Phẩm";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnPXuat
            // 
            this.btnPXuat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(123)))), ((int)(((byte)(255)))));
            this.btnPXuat.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPXuat.FlatAppearance.BorderSize = 0;
            this.btnPXuat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPXuat.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPXuat.ForeColor = System.Drawing.Color.White;
            this.btnPXuat.Location = new System.Drawing.Point(182, 139);
            this.btnPXuat.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnPXuat.Name = "btnPXuat";
            this.btnPXuat.Size = new System.Drawing.Size(225, 52);
            this.btnPXuat.TabIndex = 6;
            this.btnPXuat.Text = "Tạo phiếu xuất";
            this.btnPXuat.UseVisualStyleBackColor = false;
            this.btnPXuat.Click += new System.EventHandler(this.btnPXuat_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(123)))), ((int)(((byte)(255)))));
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(451, 139);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(299, 52);
            this.button1.TabIndex = 7;
            this.button1.Text = "Quán lý phiếu xuất";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(123)))), ((int)(((byte)(255)))));
            this.button2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(789, 139);
            this.button2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(148, 52);
            this.button2.TabIndex = 4;
            this.button2.Text = "Tải lại";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1176, 597);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnPXuat);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btnAddSP);
            this.Controls.Add(this.dvgSanpham);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1194, 644);
            this.MinimumSize = new System.Drawing.Size(1194, 644);
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dvgSanpham)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tàiKhoảnToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem thayĐổiThôngTinToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem đăngXuấtToolStripMenuItem;
        private System.Windows.Forms.Button btnAddSP;
        private System.Windows.Forms.DataGridView dvgSanpham;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripMenuItem quảnLýKhoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quảnLýNhàCungCấpToolStripMenuItem;
        private System.Windows.Forms.Button btnPXuat;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaSP;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenSP;
        private System.Windows.Forms.DataGridViewTextBoxColumn GiaBan;
        private System.Windows.Forms.DataGridViewTextBoxColumn CongDungSP;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoLuongTaiCuaHang;
        private System.Windows.Forms.DataGridViewButtonColumn delete;
        private System.Windows.Forms.DataGridViewButtonColumn edit;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ToolStripMenuItem quảnLýKháchHàngToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quảnLýHóaĐơnToolStripMenuItem;
    }
}