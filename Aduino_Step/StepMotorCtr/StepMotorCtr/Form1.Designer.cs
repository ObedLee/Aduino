namespace StepMotorCtr
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.btnCon = new System.Windows.Forms.Button();
            this.tbLog = new System.Windows.Forms.TextBox();
            this.tbData = new System.Windows.Forms.TextBox();
            this.btnDiscon = new System.Windows.Forms.Button();
            this.btnSend = new System.Windows.Forms.Button();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbSpeed = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnCon
            // 
            this.btnCon.Location = new System.Drawing.Point(380, 12);
            this.btnCon.Name = "btnCon";
            this.btnCon.Size = new System.Drawing.Size(109, 55);
            this.btnCon.TabIndex = 0;
            this.btnCon.Text = "Connect";
            this.btnCon.UseVisualStyleBackColor = true;
            this.btnCon.Click += new System.EventHandler(this.btnCon_Click);
            // 
            // tbLog
            // 
            this.tbLog.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.tbLog.Location = new System.Drawing.Point(12, 13);
            this.tbLog.Multiline = true;
            this.tbLog.Name = "tbLog";
            this.tbLog.ReadOnly = true;
            this.tbLog.Size = new System.Drawing.Size(342, 425);
            this.tbLog.TabIndex = 1;
            // 
            // tbData
            // 
            this.tbData.Location = new System.Drawing.Point(506, 121);
            this.tbData.Name = "tbData";
            this.tbData.Size = new System.Drawing.Size(109, 25);
            this.tbData.TabIndex = 2;
            // 
            // btnDiscon
            // 
            this.btnDiscon.Location = new System.Drawing.Point(506, 12);
            this.btnDiscon.Name = "btnDiscon";
            this.btnDiscon.Size = new System.Drawing.Size(109, 55);
            this.btnDiscon.TabIndex = 3;
            this.btnDiscon.Text = "Disconnect";
            this.btnDiscon.UseVisualStyleBackColor = true;
            this.btnDiscon.Click += new System.EventHandler(this.btnDiscon_Click);
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(431, 243);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(109, 25);
            this.btnSend.TabIndex = 4;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // serialPort1
            // 
            this.serialPort1.PortName = "COM5";
            this.serialPort1.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort1_DataReceived);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(503, 103);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 15);
            this.label1.TabIndex = 5;
            this.label1.Text = "Angle";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(377, 103);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 15);
            this.label2.TabIndex = 7;
            this.label2.Text = "Speed";
            // 
            // tbSpeed
            // 
            this.tbSpeed.Location = new System.Drawing.Point(380, 121);
            this.tbSpeed.Name = "tbSpeed";
            this.tbSpeed.Size = new System.Drawing.Size(109, 25);
            this.tbSpeed.TabIndex = 6;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(642, 450);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbSpeed);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.btnDiscon);
            this.Controls.Add(this.tbData);
            this.Controls.Add(this.tbLog);
            this.Controls.Add(this.btnCon);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCon;
        private System.Windows.Forms.TextBox tbLog;
        private System.Windows.Forms.TextBox tbData;
        private System.Windows.Forms.Button btnDiscon;
        private System.Windows.Forms.Button btnSend;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbSpeed;
    }
}

