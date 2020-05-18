using OxyPlot;
using OxyPlot.Series;
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using ZedGraph;


namespace Population
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RungeKutt runge = new RungeKutt();
            runge.alpha1 = double.Parse(textBox1.Text); 
           // runge.alpha1 = 1;
            runge.alpha2 = double.Parse(textBox1.Text);
            runge.omega1 = double.Parse(textBox2.Text);
            runge.omega2 = double.Parse(textBox3.Text);
            runge.beta1 = double.Parse(textBox4.Text);
            runge.beta2 = double.Parse(textBox5.Text);
            runge.gamma1 = double.Parse(textBox6.Text);
            runge.gamma2 = double.Parse(textBox7.Text);
            int nPoints = int.Parse(textBox9.Text);
            double t = double.Parse(textBox11.Text);
            double h = double.Parse(textBox10.Text);
            double u1 = double.Parse(textBox12.Text);
            double u2 = double.Parse(textBox13.Text);
            double u3 = double.Parse(textBox14.Text);
            double scale = double.Parse(textBox15.Text);

            //DataGridView1 create columns
            dataGridView1.Visible = true;
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();
            dataGridView1.ColumnCount = 5;
            dataGridView1.Columns[0].HeaderText = "i (номер шага)";
            dataGridView1.Columns[1].HeaderText = "t (время)";
            dataGridView1.Columns[2].HeaderText = "h (шаг)";
            dataGridView1.Columns[3].HeaderText = "U(t)";
            dataGridView1.Columns[4].HeaderText = "|S| (модуль ОЛП)";
            //DataGridView2 create columns
            dataGridView2.Visible = true;
            dataGridView2.Rows.Clear();
            dataGridView2.Columns.Clear();
            dataGridView2.ColumnCount = 5;
            dataGridView2.Columns[0].HeaderText = "i (номер шага)";
            dataGridView2.Columns[1].HeaderText = "t (время)";
            dataGridView2.Columns[2].HeaderText = "h (шаг)";
            dataGridView2.Columns[3].HeaderText = "U(t)";
            dataGridView2.Columns[4].HeaderText = "|S| (модуль ОЛП)";
            //DataGridView3 create columns
            dataGridView3.Visible = true;
            dataGridView3.Rows.Clear();
            dataGridView3.Columns.Clear();
            dataGridView3.ColumnCount = 5;
            dataGridView3.Columns[0].HeaderText = "i (номер шага)";
            dataGridView3.Columns[1].HeaderText = "t (время)";
            dataGridView3.Columns[2].HeaderText = "h (шаг)";
            dataGridView3.Columns[3].HeaderText = "U(t)";
            dataGridView3.Columns[4].HeaderText = "|S| (модуль ОЛП)";
            //create 0 row DGV1
            dataGridView1.Rows.Add();
            dataGridView1.Rows[0].Cells[0].Value = 0;
            dataGridView1.Rows[0].Cells[1].Value = t;
            dataGridView1.Rows[0].Cells[2].Value = h;
            dataGridView1.Rows[0].Cells[3].Value = u1;
            dataGridView1.Rows[0].Cells[4].Value = 0;
            //create 0 row DGV2
            dataGridView2.Rows.Add();
            dataGridView2.Rows[0].Cells[0].Value = 0;
            dataGridView2.Rows[0].Cells[1].Value = t;
            dataGridView2.Rows[0].Cells[2].Value = h;
            dataGridView2.Rows[0].Cells[3].Value = u2;
            dataGridView2.Rows[0].Cells[4].Value = 0;
            //create 0 row DGV2
            dataGridView3.Rows.Add();
            dataGridView3.Rows[0].Cells[0].Value = 0;
            dataGridView3.Rows[0].Cells[1].Value = t;
            dataGridView3.Rows[0].Cells[2].Value = h;
            dataGridView3.Rows[0].Cells[3].Value = u3;
            dataGridView3.Rows[0].Cells[4].Value = 0;



            chart1.Series[0].BorderWidth = 3;  // толщина линии
            chart2.Series[0].BorderWidth = 3;  // толщина линии
            chart3.Series[0].BorderWidth = 3;  // толщина линии
            
            chart1.Series[0].Points.AddXY(t, u1);
            chart2.Series[0].Points.AddXY(t, u2);
            chart3.Series[0].Points.AddXY(t, u3);
            GraphPane pane = zedGraphControl1.GraphPane;

            // Очистим список кривых на тот случай, если до этого сигналы уже были нарисованы
            pane.CurveList.Clear();

            // Создадим список точек
            PointPairList list = new PointPairList();
            for (int i = 0; i < nPoints; i++) 
            {
                runge.rk4(t,u1,u2,u3,h);
                t += h;
                u1  = runge.U1;
                u2 = runge.U2;
                u3 = runge.U3;
               

                chart1.Series[0].Points.AddXY(t, u1);
                chart2.Series[0].Points.AddXY(t, u2);
                chart3.Series[0].Points.AddXY(t, u3);
                
                list.Add(t, u3);
                //Fill rows DGV1
                dataGridView1.Rows.Add();
                dataGridView1.Rows[i].Cells[0].Value = i;
                dataGridView1.Rows[i].Cells[1].Value = t;
                dataGridView1.Rows[i].Cells[2].Value = h;
                dataGridView1.Rows[i].Cells[3].Value = u1;
                dataGridView1.Rows[i].Cells[4].Value = 0;
                //Fill rows DGV2
                dataGridView2.Rows.Add();
                dataGridView2.Rows[i].Cells[0].Value = i;
                dataGridView2.Rows[i].Cells[1].Value = t;
                dataGridView2.Rows[i].Cells[2].Value = h;
                dataGridView2.Rows[i].Cells[3].Value = u2;
                dataGridView2.Rows[i].Cells[4].Value = 0;
                //Fill rows DGV3
                dataGridView3.Rows.Add();
                dataGridView3.Rows[i].Cells[0].Value = i;
                dataGridView3.Rows[i].Cells[1].Value = t;
                dataGridView3.Rows[i].Cells[2].Value = h;
                dataGridView3.Rows[i].Cells[3].Value = u3;
                dataGridView3.Rows[i].Cells[4].Value = 0;
            }
            LineItem myCurve = pane.AddCurve("u2", list, Color.Blue, SymbolType.None);

            zedGraphControl1.AxisChange();
            // Обновляем график
            //zedGraphControl1.Invalidate();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void zedGraphControl1_Load(object sender, EventArgs e)
        {
           
        }

        private void chart2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
        }
    }
}
