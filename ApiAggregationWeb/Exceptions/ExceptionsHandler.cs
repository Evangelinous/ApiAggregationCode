using ApiAggregation.Enums;

namespace ApiAggregation.Exceptions
{
    public static class ExceptionsHandler
    {
        public static void ThrowValidationErrorException(ErrorCodes errorCode, string ModuleIdentifier, string ExtraMessage = "")
        {
            throw new ValidationErrorException(errorCode, ExtraMessage);
        }

        public static void ThrowBusinessErrorException(ErrorCodes errorCode, string ModuleIdentifier, string ExtraMessage = "")
        {
            throw new BusinessErrorException(errorCode, ExtraMessage);
        }

        public static void ThrowSystemErrorException(ErrorCodes errorCode, string ModuleIdentifier, string ExtraMessage = "")
        {
            throw new SystemErrorException(errorCode, ExtraMessage);
        }

        public static void ThrowAuthErrorException(ErrorCodes errorCode, string ModuleIdentifier, string ExtraMessage = "")
        {
            throw new AuthErrorException(errorCode, ExtraMessage);
        }

        public static void ThrowModuleNotActiveErrorException()
        {
            throw new ModuleNotActiveErrorException();
        }
    }

}
