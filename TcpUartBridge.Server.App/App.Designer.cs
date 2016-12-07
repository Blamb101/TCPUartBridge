namespace TcpUartBridge.Server.App
{
    partial class App
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.bStart = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // logWriter
            // 
            this.logWriter.Location = new System.Drawing.Point(0, 245);
            this.logWriter.Size = new System.Drawing.Size(641, 173);
            // 
            // bStart
            // 
            this.bStart.Location = new System.Drawing.Point(118, 70);
            this.bStart.Name = "bStart";
            this.bStart.Size = new System.Drawing.Size(380, 113);
            this.bStart.TabIndex = 2;
            this.bStart.Text = "ПУСК!";
            this.bStart.UseVisualStyleBackColor = true;
            this.bStart.Click += new System.EventHandler(this.bStart_Click);
            // 
            // App
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(627, 414);
            this.Controls.Add(this.bStart);
            this.Name = "App";
            this.Text = "TcpUartBridge Server";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Controls.SetChildIndex(this.logWriter, 0);
            this.Controls.SetChildIndex(this.bStart, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bStart;
    }
}

