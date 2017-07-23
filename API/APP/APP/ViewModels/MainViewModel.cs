using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APP.ViewModels
{
    public class MainViewModel
    {
        public LoginViewModel Login { set; get; }

        #region Constructor
        public MainViewModel()
        {
            Login = new LoginViewModel();
        }
        #endregion
    }
}
