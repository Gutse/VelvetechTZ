namespace VelvetechTZ.Contract.Errors
{
    public struct AppErrors
    {
        public static readonly ServiceError ValidationError = new ServiceError { Code = 1, Description = "Validation error" };
        public static readonly ServiceError ArgumentError = new ServiceError { Code = 2, Description = "One or more arguments are invalid" };
        public static readonly ServiceError PasswordMismatch = new ServiceError{ Code = 3, Description = "Password mismatch" };
        public static readonly ServiceError EntityDoesNotExists = new ServiceError { Code = 4, Description = "Entity does not exist" };
        public static readonly ServiceError BadLoginError = new ServiceError { Code = 9, Description = "Login or password incorrect" };
        public static readonly ServiceError UserAlreadyExists = new ServiceError { Code = 10, Description = "User already exists" };
        public static readonly ServiceError UserIdentityAlreadyExists = new ServiceError { Code = 11, Description = "User identity already exists" };
    }
}