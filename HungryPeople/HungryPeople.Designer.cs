
namespace HungryPeople
{
    partial class HungryPeople
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            lblDay = new Label();
            pbCustomer = new ProgressBar();
            label2 = new Label();
            lblQueue = new Label();
            label3 = new Label();
            lblCustomerServed = new Label();
            label4 = new Label();
            lblHandItem = new Label();
            label5 = new Label();
            label6 = new Label();
            btnTableInteract = new Button();
            label7 = new Label();
            lblTableOrder = new Label();
            lblTableItemPlaced = new Label();
            label8 = new Label();
            label9 = new Label();
            lblStoveSlot = new Label();
            label13 = new Label();
            btnStove = new Button();
            btnSteakFridge = new Button();
            pbStove = new ProgressBar();
            label10 = new Label();
            lblCounterTop = new Label();
            btnCounterTop = new Button();
            label11 = new Label();
            btnPlateRack = new Button();
            lblPlateRack = new Label();
            label14 = new Label();
            label12 = new Label();
            lblSink = new Label();
            btnSinkInteract = new Button();
            btnSinkClean = new Button();
            pbSink = new ProgressBar();
            pbTable = new ProgressBar();
            btnCounterTop2 = new Button();
            lblCounterTop2 = new Label();
            label16 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(38, 20);
            label1.TabIndex = 0;
            label1.Text = "Day:";
            // 
            // lblDay
            // 
            lblDay.AutoSize = true;
            lblDay.Location = new Point(56, 9);
            lblDay.Name = "lblDay";
            lblDay.Size = new Size(0, 20);
            lblDay.TabIndex = 1;
            // 
            // pbCustomer
            // 
            pbCustomer.Location = new Point(12, 92);
            pbCustomer.Name = "pbCustomer";
            pbCustomer.Size = new Size(157, 14);
            pbCustomer.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 69);
            label2.Name = "label2";
            label2.Size = new Size(144, 20);
            label2.TabIndex = 3;
            label2.Text = "Customers in Queue:";
            // 
            // lblQueue
            // 
            lblQueue.AutoSize = true;
            lblQueue.Location = new Point(152, 69);
            lblQueue.Name = "lblQueue";
            lblQueue.Size = new Size(17, 20);
            lblQueue.TabIndex = 4;
            lblQueue.Text = "0";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 29);
            label3.Name = "label3";
            label3.Size = new Size(134, 20);
            label3.TabIndex = 5;
            label3.Text = "Customers Served: ";
            // 
            // lblCustomerServed
            // 
            lblCustomerServed.AutoSize = true;
            lblCustomerServed.Location = new Point(152, 29);
            lblCustomerServed.Name = "lblCustomerServed";
            lblCustomerServed.Size = new Size(17, 20);
            lblCustomerServed.TabIndex = 6;
            lblCustomerServed.Text = "0";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(959, 9);
            label4.Name = "label4";
            label4.Size = new Size(48, 20);
            label4.TabIndex = 7;
            label4.Text = "Hand:";
            // 
            // lblHandItem
            // 
            lblHandItem.AutoSize = true;
            lblHandItem.Location = new Point(959, 29);
            lblHandItem.Name = "lblHandItem";
            lblHandItem.Size = new Size(15, 20);
            lblHandItem.TabIndex = 8;
            lblHandItem.Text = "-";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(56, 171);
            label5.Name = "label5";
            label5.Size = new Size(44, 20);
            label5.TabIndex = 9;
            label5.Text = "Table";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(12, 191);
            label6.Name = "label6";
            label6.Size = new Size(50, 20);
            label6.TabIndex = 10;
            label6.Text = "Order:";
            // 
            // btnTableInteract
            // 
            btnTableInteract.Location = new Point(35, 256);
            btnTableInteract.Name = "btnTableInteract";
            btnTableInteract.Size = new Size(94, 29);
            btnTableInteract.TabIndex = 11;
            btnTableInteract.Text = "Interact";
            btnTableInteract.UseVisualStyleBackColor = true;
            btnTableInteract.Click += btnTableInteract_Click;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(12, 217);
            label7.Name = "label7";
            label7.Size = new Size(56, 20);
            label7.TabIndex = 12;
            label7.Text = "Placed:";
            // 
            // lblTableOrder
            // 
            lblTableOrder.AutoSize = true;
            lblTableOrder.Location = new Point(106, 191);
            lblTableOrder.Name = "lblTableOrder";
            lblTableOrder.Size = new Size(50, 20);
            lblTableOrder.TabIndex = 13;
            lblTableOrder.Text = "label8";
            // 
            // lblTableItemPlaced
            // 
            lblTableItemPlaced.AutoSize = true;
            lblTableItemPlaced.Location = new Point(106, 217);
            lblTableItemPlaced.Name = "lblTableItemPlaced";
            lblTableItemPlaced.Size = new Size(50, 20);
            lblTableItemPlaced.TabIndex = 14;
            lblTableItemPlaced.Text = "label9";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(954, 69);
            label8.Name = "label8";
            label8.Size = new Size(46, 20);
            label8.TabIndex = 15;
            label8.Text = "Stove";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(905, 92);
            label9.Name = "label9";
            label9.Size = new Size(38, 20);
            label9.TabIndex = 16;
            label9.Text = "Slot:";
            // 
            // lblStoveSlot
            // 
            lblStoveSlot.AutoSize = true;
            lblStoveSlot.Location = new Point(999, 92);
            lblStoveSlot.Name = "lblStoveSlot";
            lblStoveSlot.Size = new Size(58, 20);
            lblStoveSlot.TabIndex = 17;
            lblStoveSlot.Text = "label10";
            lblStoveSlot.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(938, 191);
            label13.Name = "label13";
            label13.Size = new Size(91, 20);
            label13.TabIndex = 20;
            label13.Text = "Steak Fridge";
            // 
            // btnStove
            // 
            btnStove.Location = new Point(935, 138);
            btnStove.Name = "btnStove";
            btnStove.Size = new Size(94, 29);
            btnStove.TabIndex = 22;
            btnStove.Text = "Interact";
            btnStove.UseVisualStyleBackColor = true;
            btnStove.Click += btnStove_Click;
            // 
            // btnSteakFridge
            // 
            btnSteakFridge.Location = new Point(935, 213);
            btnSteakFridge.Name = "btnSteakFridge";
            btnSteakFridge.Size = new Size(94, 29);
            btnSteakFridge.TabIndex = 23;
            btnSteakFridge.Text = "Interact";
            btnSteakFridge.UseVisualStyleBackColor = true;
            btnSteakFridge.Click += btnSteakFridge_Click;
            // 
            // pbStove
            // 
            pbStove.Location = new Point(905, 115);
            pbStove.Name = "pbStove";
            pbStove.Size = new Size(152, 17);
            pbStove.TabIndex = 24;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(939, 255);
            label10.Name = "label10";
            label10.Size = new Size(90, 20);
            label10.TabIndex = 25;
            label10.Text = "Counter Top";
            // 
            // lblCounterTop
            // 
            lblCounterTop.AutoSize = true;
            lblCounterTop.Location = new Point(954, 310);
            lblCounterTop.Name = "lblCounterTop";
            lblCounterTop.Size = new Size(58, 20);
            lblCounterTop.TabIndex = 26;
            lblCounterTop.Text = "label11";
            // 
            // btnCounterTop
            // 
            btnCounterTop.Location = new Point(935, 278);
            btnCounterTop.Name = "btnCounterTop";
            btnCounterTop.Size = new Size(94, 29);
            btnCounterTop.TabIndex = 27;
            btnCounterTop.Text = "Interact";
            btnCounterTop.UseVisualStyleBackColor = true;
            btnCounterTop.Click += btnCounterTop_Click;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(948, 336);
            label11.Name = "label11";
            label11.Size = new Size(77, 20);
            label11.TabIndex = 28;
            label11.Text = "Plate Rack";
            // 
            // btnPlateRack
            // 
            btnPlateRack.Location = new Point(938, 377);
            btnPlateRack.Name = "btnPlateRack";
            btnPlateRack.Size = new Size(94, 29);
            btnPlateRack.TabIndex = 29;
            btnPlateRack.Text = "Interact";
            btnPlateRack.UseVisualStyleBackColor = true;
            btnPlateRack.Click += btnPlateRack_Click;
            // 
            // lblPlateRack
            // 
            lblPlateRack.AutoSize = true;
            lblPlateRack.Location = new Point(997, 356);
            lblPlateRack.Name = "lblPlateRack";
            lblPlateRack.Size = new Size(47, 20);
            lblPlateRack.TabIndex = 30;
            lblPlateRack.Text = "10/10";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new Point(930, 356);
            label14.Name = "label14";
            label14.Size = new Size(61, 20);
            label14.TabIndex = 31;
            label14.Text = "Capcity:";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(969, 419);
            label12.Name = "label12";
            label12.Size = new Size(36, 20);
            label12.TabIndex = 32;
            label12.Text = "Sink";
            // 
            // lblSink
            // 
            lblSink.AutoSize = true;
            lblSink.Location = new Point(959, 439);
            lblSink.Name = "lblSink";
            lblSink.Size = new Size(58, 20);
            lblSink.TabIndex = 33;
            lblSink.Text = "label15";
            // 
            // btnSinkInteract
            // 
            btnSinkInteract.Location = new Point(939, 462);
            btnSinkInteract.Name = "btnSinkInteract";
            btnSinkInteract.Size = new Size(94, 29);
            btnSinkInteract.TabIndex = 34;
            btnSinkInteract.Text = "Interact";
            btnSinkInteract.UseVisualStyleBackColor = true;
            btnSinkInteract.Click += btnSinkInteract_Click;
            // 
            // btnSinkClean
            // 
            btnSinkClean.Location = new Point(939, 497);
            btnSinkClean.Name = "btnSinkClean";
            btnSinkClean.Size = new Size(94, 29);
            btnSinkClean.TabIndex = 35;
            btnSinkClean.Text = "Clean";
            btnSinkClean.UseVisualStyleBackColor = true;
            // 
            // pbSink
            // 
            pbSink.Location = new Point(905, 532);
            pbSink.Name = "pbSink";
            pbSink.Size = new Size(152, 17);
            pbSink.TabIndex = 36;
            // 
            // pbTable
            // 
            pbTable.Location = new Point(12, 240);
            pbTable.Name = "pbTable";
            pbTable.Size = new Size(144, 10);
            pbTable.TabIndex = 37;
            // 
            // btnCounterTop2
            // 
            btnCounterTop2.Location = new Point(695, 278);
            btnCounterTop2.Name = "btnCounterTop2";
            btnCounterTop2.Size = new Size(94, 29);
            btnCounterTop2.TabIndex = 40;
            btnCounterTop2.Text = "Interact";
            btnCounterTop2.UseVisualStyleBackColor = true;
            btnCounterTop2.Click += btnCounterTop2_Click;
            // 
            // lblCounterTop2
            // 
            lblCounterTop2.AutoSize = true;
            lblCounterTop2.Location = new Point(714, 310);
            lblCounterTop2.Name = "lblCounterTop2";
            lblCounterTop2.Size = new Size(58, 20);
            lblCounterTop2.TabIndex = 39;
            lblCounterTop2.Text = "label11";
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Location = new Point(699, 255);
            label16.Name = "label16";
            label16.Size = new Size(90, 20);
            label16.TabIndex = 38;
            label16.Text = "Counter Top";
            // 
            // HungryPeople
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1085, 570);
            Controls.Add(btnCounterTop2);
            Controls.Add(lblCounterTop2);
            Controls.Add(label16);
            Controls.Add(pbTable);
            Controls.Add(pbSink);
            Controls.Add(btnSinkClean);
            Controls.Add(btnSinkInteract);
            Controls.Add(lblSink);
            Controls.Add(label12);
            Controls.Add(label14);
            Controls.Add(lblPlateRack);
            Controls.Add(btnPlateRack);
            Controls.Add(label11);
            Controls.Add(btnCounterTop);
            Controls.Add(lblCounterTop);
            Controls.Add(label10);
            Controls.Add(pbStove);
            Controls.Add(btnSteakFridge);
            Controls.Add(btnStove);
            Controls.Add(label13);
            Controls.Add(lblStoveSlot);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(lblTableItemPlaced);
            Controls.Add(lblTableOrder);
            Controls.Add(label7);
            Controls.Add(btnTableInteract);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(lblHandItem);
            Controls.Add(label4);
            Controls.Add(lblCustomerServed);
            Controls.Add(label3);
            Controls.Add(lblQueue);
            Controls.Add(label2);
            Controls.Add(pbCustomer);
            Controls.Add(lblDay);
            Controls.Add(label1);
            Name = "HungryPeople";
            Text = "HungryPeople";
            Load += HungryPeople_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label lblDay;

        private ProgressBar pbCustomer;
        private Label label2;
        private Label lblQueue;
        private Label label3;
        private Label lblCustomerServed;
        private Label label4;
        private Label lblHandItem;
        private Label label5;
        private Label label6;
        private Button btnTableInteract;
        private Label label7;
        private Label lblTableOrder;
        private Label lblTableItemPlaced;
        private Label label8;
        private Label label9;
        private Label lblStoveSlot;
        private Label label13;
        private Button btnStove;
        private Button btnSteakFridge;
        private ProgressBar pbStove;
        private Label label10;
        private Label lblCounterTop;
        private Button btnCounterTop;
        private Label label11;
        private Button btnPlateRack;
        private Label lblPlateRack;
        private Label label14;
        private Label label12;
        private Label lblSink;
        private Button btnSinkInteract;
        private Button btnSinkClean;
        private ProgressBar pbSink;
        private ProgressBar pbTable;
        private Button btnCounterTop2;
        private Label lblCounterTop2;
        private Label label16;
    }
}
