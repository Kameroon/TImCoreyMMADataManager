using Caliburn.Micro;
using MMDesktopUI.TestsDependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMDesktopUI.ViewModels
{
    public class ShellViewModel: Conductor<object>
    {
        /*
        * Pour démarrer 2 projets dans la même solution en même temps
        * Click droit sur la solution 'StartUp Project'
        * */

        #region -- Properties --
        public ICalculations _calculator;
        private LoginViewModel _loginViewModel;
        #endregion

        #region --  --

        #endregion

        #region --  --
        public ShellViewModel(ICalculations calculator, LoginViewModel loginViewModel)
        {
            _calculator = calculator;
            _loginViewModel = loginViewModel;

            // -- Pour activer le formulaire de connexion --
            ActivateItem(_loginViewModel);
        }
        #endregion

        #region -- Methodes --

        #endregion
    }
}
