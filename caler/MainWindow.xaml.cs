using caler.MModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace caler
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        private CompModel cpModel = new CompModel();


        private int focusInInput = 0;
        private TextBox[] tbs = new TextBox[4];
        private decimal m2p = CompModel.P2M;

        public MainWindow()
        {
            this.DataContext = this.cpModel;
            InitializeComponent();
            InitComps();

        }


        private void ResetDataComps()
        {

            //宗地编号
            this.tb_zdbh.Text = "";
            this.tb_pfm.Text = "0";
            this.tb_m.Text = "0";
            this.tb_lhl.Text = "≥";
            this.tb_tdyt.Text = "";
            this.tb_rjl.Text = "1";
            this.tb_jzmd.Text = "≤";
            this.tb_lhl.Text = "≥";


            //下面
            this.tb_qsj.Text = "0";
            this.tb_mmddj.Text = "0";
            this.tb_mpfmdj.Text = "0";
            this.tb_lmdj.Text = "0";
            this.tb_dqzdbj.Text = "0";

            //初始化
            this.tbs[0] = tb_mmddj;
            this.tbs[1] = tb_mpfmdj;
            this.tbs[2] = tb_lmdj;
            this.tbs[3] = tb_dqzdbj;

            this.dt.SelectedDate = DateTime.Now;
        }

        private void InitComps()
        {
            this.ResetDataComps();



        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {



        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CalButtonClick(object sender, RoutedEventArgs e)
        {
            //计算
            Decimal price = 0;
            TextBox tb = this.tbs[this.focusInInput];
            if (!Decimal.TryParse(tb.Text, out price))
            {
                tb.Text = "0";
            }
            price = Decimal.Parse(tb.Text);


            decimal zdbj = 0;

            //每亩多少钱
            if (this.focusInInput == 0)
            {
                decimal mpfmbj = price * 10000 / this.m2p;
                this.cpModel.Mpfmdj = mpfmbj;
                this.cpModel.Lmdj = cpModel.Mpfmdj / cpModel.Rjl;   //计算宗地报价
                this.cpModel.Dqzddj = cpModel.MmdDj * cpModel.M;
             
            }
            if (this.focusInInput == 1)
            {
                this.cpModel.MmdDj = price * m2p / 10000;
                this.cpModel.Lmdj = cpModel.Mpfmdj / cpModel.Rjl;   //计算宗地报价
                this.cpModel.dqzddj = cpModel.mmdDj * cpModel.M;
            }

            if (this.focusInInput == 2)
            {
                decimal mpfmdj = price * cpModel.Rjl;
                this.cpModel.MmdDj = mpfmdj * m2p / 10000;
                this.cpModel.Mpfmdj = mpfmdj;
                this.cpModel.Dqzddj = cpModel.mmdDj * cpModel.M;
            }

            if (this.focusInInput == 3)
            {
                //判断宗地面积
                if (this.cpModel.M <= 0)
                {
                    MessageBox.Show("宗地面积不能小于或者等于0");
                    return;
                }
                //计算方式比较简单1.计算出单价
                decimal mmdj = price / this.cpModel.M;//每亩单价
                decimal mpfmbj = mmdj * 10000 / this.m2p;
                this.cpModel.MmdDj = mmdj;
                this.cpModel.Mpfmdj = mpfmbj;
                this.cpModel.Lmdj = cpModel.Mpfmdj / cpModel.Rjl;   //计算宗地报价
            }
            //计算结果



            Console.WriteLine("计算结果:%s,%s,%s,%s", this.cpModel.Mpfmdj.ToString(), this.cpModel.Mpfmdj, this.cpModel.Lmdj, this.cpModel.Dqzddj);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SuccessButtonClick(object sender, RoutedEventArgs e)
        {
            //  MessageBox.Show("Success");
            ResultWindow resultWindow = new ResultWindow
            {
                ResultCode = cpModel.Yjhp
            };
            resultWindow.Show();
        }

        private void Tb_pfm_change(object sender, object e)
        {
            TextBox tb = (TextBox)sender;
            Decimal val = 0;
            if (Decimal.TryParse(tb.Text, out val))
            {
                if (cpModel.Pfm == val)
                {
                    return;
                }
                this.cpModel.Pfm = val;
                this.cpModel.RaisePropertyChanged("M");
            }
            Console.WriteLine("Pfm Change", val);
        }
        private void Tb_m_change(object sender, object e)
        {
            TextBox tb = (TextBox)sender;
            Decimal val = 0;
            if (Decimal.TryParse(tb.Text, out val))
            {
                if (cpModel.M == val)
                {
                    return;
                }
                this.cpModel.M = val;
                this.cpModel.RaisePropertyChanged("Pfm");
            }
            Console.WriteLine("M Change " + val);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="idx"></param>
        private void SetFocusInBox(int idx)
        {
            int len = 4;
            if (idx < 0 || idx >= len)
            {
                throw new Exception("有问题喔");
            }
            this.focusInInput = idx;
        }





        private void Tb_mmddj_GotFocus(object sender, RoutedEventArgs e)
        {
            this.SetFocusInBox(0);
        }

        private void Tb_mpfmdj_GotFocus(object sender, RoutedEventArgs e)
        {
            this.SetFocusInBox(1);
        }

        private void Tb_lmdj_GotFocus(object sender, RoutedEventArgs e)
        {
            this.SetFocusInBox(2);
        }

        private void Tb_dqzdbj_GotFocus(object sender, RoutedEventArgs e)
        {
            this.SetFocusInBox(3);
        }

        private void Tb_m_TextInput(object sender, TextCompositionEventArgs e)
        {
            Console.Write("123");
        }
    }
}
