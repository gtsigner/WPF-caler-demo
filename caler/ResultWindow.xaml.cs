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
using System.Windows.Shapes;

namespace caler
{
    /// <summary>
    /// Result.xaml 的交互逻辑
    /// </summary> n
    public partial class ResultWindow : Window
    {

        private String _resultCode = "";
        public String ResultCode
        {
            get { return this._resultCode; }
            set { this._resultCode = value; }
        }


        public ResultWindow()
        {
            InitializeComponent();
            this._initListen();
        }

       

        private void _initListen() {
           


        }

        private void Result_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            this.title.Text ="恭喜"+ this._resultCode+"号竞买人竞买成功";
        }
    }
}
