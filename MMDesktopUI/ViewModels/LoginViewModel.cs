using Caliburn.Micro;
using MMDesktopUI.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMDesktopUI.ViewModels
{
    public class LoginViewModel: Screen  //, IHandle<object>  //, IHandleWithTask<object>
    {
        #region -- Properties --
        private string _userName;
        private string _password;
        private string _errorMessage;

        public string UserName
        {
            get { return _userName; }
            set
            {
                _userName = value;
                NotifyOfPropertyChange(() => UserName);
                NotifyOfPropertyChange(() => CanLogIn);
            }
        }
        
        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
                NotifyOfPropertyChange(() => Password);
                NotifyOfPropertyChange(() => CanLogIn);
            }
        }
        
        public bool IsErrorVisible
        {
            get
            {
                return ErrorMessage?.Length > 0;
            }
        }

        public string ErrorMessage
        {
            get { return _errorMessage; }
            set
            {
                _errorMessage = value;
                NotifyOfPropertyChange(() => ErrorMessage);
                NotifyOfPropertyChange(() => IsErrorVisible);
            }
        }

        private readonly IEventAggregator _eventAggregator;
        private IAPIHelper _aPIHelper;
        #endregion

        #region -- Constructor --
        public LoginViewModel(IAPIHelper aPIHelper, IEventAggregator eventAggregator)
        {
            _aPIHelper = aPIHelper;
            _eventAggregator = eventAggregator;

            _eventAggregator.Subscribe(this);
        }
        #endregion

        #region -- Methodes --
        public bool CanLogIn
        {
            get
            {
                return UserName?.Length > 0 && Password?.Length > 0;
            }
        }

        /*
         * Pour démarrer 2 projets dans la même solution en même temps
         * Click droit sur la solution 'StartUp Project'
         * */
        public async Task LogIn()
        {
            try
            {
                //var result = _aPIHelper.Authenticate(UserName, Password);
                //var de = 2 / 0;
                ;
                //var de = result.Result.Acces_Token;
                //ErrorMessage = "exception.Message result.Result.Acces_Token result.Result.Acces_Token";

            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                ErrorMessage = exception.Message;
                throw;
            }

        }
        #endregion
    }
}
