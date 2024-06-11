using System;
namespace Design_Patterns.Creational.FactoryPattern
{
    // Product interface
    interface IAuthenticationHandler
    {
        void Authenticate();
    }

    // Concrete products
    class UsernamePasswordAuthenticationHandler : IAuthenticationHandler
    {
        public void Authenticate()
        {
            // Perform username/password authentication
        }
    }

    class SocialMediaAuthenticationHandler : IAuthenticationHandler
    {
        public void Authenticate()
        {
            // Perform social media authentication
        }
    }

    class BiometricAuthenticationHandler : IAuthenticationHandler
    {
        public void Authenticate()
        {
            // Perform biometric authentication
        }
    }

    // Factory interface
    interface IAuthenticationHandlerFactory
    {
        IAuthenticationHandler CreateAuthenticationHandler(AuthenticationMethod method);
    }

    // Concrete factory
    class AuthenticationHandlerFactory : IAuthenticationHandlerFactory
    {
        public IAuthenticationHandler CreateAuthenticationHandler(AuthenticationMethod method)
        {
            switch (method)
            {
                case AuthenticationMethod.UsernamePassword:
                    return new UsernamePasswordAuthenticationHandler();
                case AuthenticationMethod.SocialMedia:
                    return new SocialMediaAuthenticationHandler();
                case AuthenticationMethod.Biometric:
                    return new BiometricAuthenticationHandler();
                default:
                    throw new NotSupportedException($"Authentication method '{method}' is not supported.");
            }
        }
    }

    enum AuthenticationMethod
    {
        UsernamePassword,
        SocialMedia,
        Biometric
    }

    //class Program
    //{
    //    static void Main(string[] args)
    //    {
    //        IAuthenticationHandlerFactory authenticationHandlerFactory = new AuthenticationHandlerFactory();

    //        IAuthenticationHandler usernamePasswordHandler = authenticationHandlerFactory.CreateAuthenticationHandler(AuthenticationMethod.UsernamePassword);
    //        usernamePasswordHandler.Authenticate();

    //        IAuthenticationHandler biometricHandler = authenticationHandlerFactory.CreateAuthenticationHandler(AuthenticationMethod.Biometric);
    //        biometricHandler.Authenticate();
    //    }
    //}

}

