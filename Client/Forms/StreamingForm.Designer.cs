namespace Client.Forms
{
    partial class StreamingForm
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
            this.pb_stream = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pb_stream)).BeginInit();
            this.SuspendLayout();
            // 
            // pb_stream
            // 
            this.pb_stream.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pb_stream.Location = new System.Drawing.Point(0, 0);
            this.pb_stream.Name = "pb_stream";
            this.pb_stream.Size = new System.Drawing.Size(800, 450);
            this.pb_stream.TabIndex = 0;
            this.pb_stream.TabStop = false;
            // 
            // StreamingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pb_stream);
            this.Name = "StreamingForm";
            this.Text = "StreamingForm";
            ((System.ComponentModel.ISupportInitialize)(this.pb_stream)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.PictureBox pb_stream;
    }
}