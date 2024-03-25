
namespace lab1_T5
{
    partial class Form1
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
            this.Transparency = new System.Windows.Forms.Button();
            this.BackgroundColor = new System.Windows.Forms.Button();
            this.HelloWorld = new System.Windows.Forms.Button();
            this.SuperMegaButton = new System.Windows.Forms.Button();
            this.CheckboxTransparency = new System.Windows.Forms.CheckBox();
            this.CheckboxBackgroundColor = new System.Windows.Forms.CheckBox();
            this.CheckboxHelloWorld = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // Transparency
            // 
            this.Transparency.Location = new System.Drawing.Point(12, 12);
            this.Transparency.Name = "Transparency";
            this.Transparency.Size = new System.Drawing.Size(79, 35);
            this.Transparency.TabIndex = 0;
            this.Transparency.Text = "Прозорість";
            this.Transparency.UseVisualStyleBackColor = true;
            this.Transparency.Click += new System.EventHandler(this.Transparency_Click);
            // 
            // BackgroundColor
            // 
            this.BackgroundColor.Location = new System.Drawing.Point(97, 12);
            this.BackgroundColor.Name = "BackgroundColor";
            this.BackgroundColor.Size = new System.Drawing.Size(57, 35);
            this.BackgroundColor.TabIndex = 1;
            this.BackgroundColor.Text = "Колір тіла";
            this.BackgroundColor.UseVisualStyleBackColor = true;
            this.BackgroundColor.Click += new System.EventHandler(this.BackgroundColor_Click);
            // 
            // HelloWorld
            // 
            this.HelloWorld.Location = new System.Drawing.Point(160, 12);
            this.HelloWorld.Name = "HelloWorld";
            this.HelloWorld.Size = new System.Drawing.Size(76, 35);
            this.HelloWorld.TabIndex = 2;
            this.HelloWorld.Text = "Hello World!";
            this.HelloWorld.UseVisualStyleBackColor = true;
            this.HelloWorld.Click += new System.EventHandler(this.HelloWorld_Click);
            // 
            // SuperMegaButton
            // 
            this.SuperMegaButton.Location = new System.Drawing.Point(12, 53);
            this.SuperMegaButton.Name = "SuperMegaButton";
            this.SuperMegaButton.Size = new System.Drawing.Size(224, 20);
            this.SuperMegaButton.TabIndex = 3;
            this.SuperMegaButton.Text = "СуперМегаКнопка";
            this.SuperMegaButton.UseVisualStyleBackColor = true;
            this.SuperMegaButton.Click += new System.EventHandler(this.SuperMegaButton_Click);
            // 
            // CheckboxTransparency
            // 
            this.CheckboxTransparency.AutoSize = true;
            this.CheckboxTransparency.Location = new System.Drawing.Point(12, 94);
            this.CheckboxTransparency.Name = "CheckboxTransparency";
            this.CheckboxTransparency.Size = new System.Drawing.Size(237, 17);
            this.CheckboxTransparency.TabIndex = 4;
            this.CheckboxTransparency.Text = "\"СуперМегаКнопка\" поглинає прозорість";
            this.CheckboxTransparency.UseVisualStyleBackColor = true;
            this.CheckboxTransparency.CheckedChanged += new System.EventHandler(this.CheckboxTransparency_CheckedChanged);
            // 
            // CheckboxBackgroundColor
            // 
            this.CheckboxBackgroundColor.AutoSize = true;
            this.CheckboxBackgroundColor.Location = new System.Drawing.Point(12, 117);
            this.CheckboxBackgroundColor.Name = "CheckboxBackgroundColor";
            this.CheckboxBackgroundColor.Size = new System.Drawing.Size(230, 17);
            this.CheckboxBackgroundColor.TabIndex = 5;
            this.CheckboxBackgroundColor.Text = "\"СуперМегаКнопка\" поглинає колір тіла";
            this.CheckboxBackgroundColor.UseVisualStyleBackColor = true;
            this.CheckboxBackgroundColor.CheckedChanged += new System.EventHandler(this.CheckboxBackgroundColor_CheckedChanged);
            // 
            // CheckboxHelloWorld
            // 
            this.CheckboxHelloWorld.AutoSize = true;
            this.CheckboxHelloWorld.Location = new System.Drawing.Point(12, 140);
            this.CheckboxHelloWorld.Name = "CheckboxHelloWorld";
            this.CheckboxHelloWorld.Size = new System.Drawing.Size(243, 17);
            this.CheckboxHelloWorld.TabIndex = 6;
            this.CheckboxHelloWorld.Text = "\"СуперМегаКнопка\" поглинає хелоу ворлд";
            this.CheckboxHelloWorld.UseVisualStyleBackColor = true;
            this.CheckboxHelloWorld.CheckedChanged += new System.EventHandler(this.CheckboxHelloWorld_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(256, 168);
            this.Controls.Add(this.CheckboxHelloWorld);
            this.Controls.Add(this.CheckboxBackgroundColor);
            this.Controls.Add(this.CheckboxTransparency);
            this.Controls.Add(this.SuperMegaButton);
            this.Controls.Add(this.HelloWorld);
            this.Controls.Add(this.BackgroundColor);
            this.Controls.Add(this.Transparency);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Transparency;
        private System.Windows.Forms.Button BackgroundColor;
        private System.Windows.Forms.Button HelloWorld;
        private System.Windows.Forms.Button SuperMegaButton;
        private System.Windows.Forms.CheckBox CheckboxTransparency;
        private System.Windows.Forms.CheckBox CheckboxBackgroundColor;
        private System.Windows.Forms.CheckBox CheckboxHelloWorld;
    }
}

